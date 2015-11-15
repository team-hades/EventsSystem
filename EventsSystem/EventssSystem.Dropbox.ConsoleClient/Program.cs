namespace EventssSystem.Dropbox.ConsoleClient
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Windows;
    using System.Drawing;

    using global::Dropbox.Api;
    using global::Dropbox.Api.Files;

    using EventsSystem.Data.Dropbox;
    using static System.Net.Mime.MediaTypeNames;
    using System.IO;

    public class Program
    {
        // Add an ApiKey (from https://www.dropbox.com/developers/apps) here
        private const string ApiKey = "zLuxucgFyAAAAAAAAAAABqeYhqrlvdfzqSoIZUCyu_M02hjUozkAgW8aV2fTXsVu";

        private DropboxClient client;

        [STAThread]
        static void Main(string[] args)
        {
            var instance = new Program();

            var task = Task.Run((Func<Task<int>>)instance.Run);

            task.Wait();

            //return task.Result;
        }

        private async Task<int> Run()
        {
            InitializeCertPinning();

            var accessToken = ApiKey;
            if (string.IsNullOrEmpty(accessToken))
            {
                return 1;
            }

            // Specify socket level timeout which decides maximum waiting time when on bytes are
            // received by the socket.
            var httpClient = new HttpClient(new WebRequestHandler { ReadWriteTimeout = 10 * 1000 })
            {
                // Specify request level timeout which decides maximum time taht can be spent on
                // download/upload files.
                Timeout = TimeSpan.FromMinutes(20)
            };

            this.client = new DropboxClient(accessToken, userAgent: "SimpleTestApp", httpClient: httpClient);

            try
            {
                await GetCurrentAccount();

                var folder = "/profiles";
                var list = await ListFolder(folder);

                var firstFile = list.Entries.FirstOrDefault(i => i.IsFile);
                if (firstFile != null)
                {
                    await Download(folder, firstFile.AsFile);
                }

                await Upload(folder, "upload.bmp");

            }
            catch (HttpException e)
            {
                Console.WriteLine("Exception reported from RPC layer");
                Console.WriteLine("    Status code: {0}", e.StatusCode);
                Console.WriteLine("    Message    : {0}", e.Message);
                if (e.RequestUri != null)
                {
                    Console.WriteLine("    Request uri: {0}", e.RequestUri);
                }
            }

            return 0;
        }

        /// <summary>
        /// Initializes ssl certificate pinning.
        /// </summary>
        private void InitializeCertPinning()
        {
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
            {
                var root = chain.ChainElements[chain.ChainElements.Count - 1];
                var publicKey = root.Certificate.GetPublicKeyString();

                return DropboxCertHelper.IsKnownRootCertPublicKey(publicKey);
            };
        }

        /// <summary>
        /// Gets information about the currently authorized account.
        /// <para>
        /// This demonstrates calling a simple rpc style api from the Users namespace.
        /// </para>
        /// </summary>
        /// <returns>An asynchronous task.</returns>
        private async Task GetCurrentAccount()
        {
            var full = await this.client.Users.GetCurrentAccountAsync();

            Console.WriteLine("Account id    : {0}", full.AccountId);
            Console.WriteLine("Country       : {0}", full.Country);
            Console.WriteLine("Email         : {0}", full.Email);
            Console.WriteLine("Is paired     : {0}", full.IsPaired ? "Yes" : "No");
            Console.WriteLine("Locale        : {0}", full.Locale);
            Console.WriteLine("Name");
            Console.WriteLine("  Display  : {0}", full.Name.DisplayName);
            Console.WriteLine("  Familiar : {0}", full.Name.FamiliarName);
            Console.WriteLine("  Given    : {0}", full.Name.GivenName);
            Console.WriteLine("  Surname  : {0}", full.Name.Surname);
            Console.WriteLine("Referral link : {0}", full.ReferralLink);

            if (full.Team != null)
            {
                Console.WriteLine("Team");
                Console.WriteLine("  Id   : {0}", full.Team.Id);
                Console.WriteLine("  Name : {0}", full.Team.Name);
            }
            else
            {
                Console.WriteLine("Team - None");
            }
        }

        /// <summary>
        /// Lists the items within a folder.
        /// </summary>
        /// <remarks>This is a demonstrates calling an rpc style api in the Files namespace.</remarks>
        /// <param name="path">The path to list.</param>
        /// <returns>The result from the ListFolderAsync call.</returns>
        private async Task<ListFolderResult> ListFolder(string path)
        {
            Console.WriteLine("--- Files ---");
            var list = await this.client.Files.ListFolderAsync(path);

            // show folders then files
            foreach (var item in list.Entries.Where(i => i.IsFolder))
            {
                Console.WriteLine("D  {0}/", item.Name);
            }

            foreach (var item in list.Entries.Where(i => i.IsFile))
            {
                var file = item.AsFile;

                Console.WriteLine("F{0,8} {1}",
                    file.Size,
                    item.Name);
            }

            if (list.HasMore)
            {
                Console.WriteLine("   ...");
            }
            return list;
        }

        /// <summary>
        /// Downloads a file.
        /// </summary>
        /// <remarks>This demonstrates calling a download style api in the Files namespace.</remarks>
        /// <param name="folder">The folder path in which the file should be found.</param>
        /// <param name="file">The file to download within <paramref name="folder"/>.</param>
        /// <returns></returns>
        private async Task Download(string folder, FileMetadata file)
        {
            Console.WriteLine("Download file...");

            using (var response = await this.client.Files.DownloadAsync(folder + "/" + file.Name))
            {
                Console.WriteLine("Downloaded {0} Rev {1}", response.Response.Name, response.Response.Rev);
                Console.WriteLine("------------------------------");
                try
                {
                    var contentAsByteArray = await response.GetContentAsByteArrayAsync();
                    var bitmap = byteArrayToImage(contentAsByteArray);
                    bitmap.Save(response.Response.Name);
                    Console.WriteLine("File {0} saved", response.Response.Name);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("File {0} not saved", response.Response.Name);
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("------------------------------");
            }
        }

        private async Task Upload(string folder, string fileName)
        {
            Console.WriteLine("Uploading file...");
            Console.WriteLine("------------------------------");

            try
            {
                CommitInfo commmitInfo = new CommitInfo(folder + "/" + fileName, null, true);

                var fileStream = new FileStream(fileName, FileMode.Open);

                await this.client.Files.UploadAsync(commmitInfo, fileStream);

                Console.WriteLine("File {0} uploaded", fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("File {0} not uploaded", fileName);
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("------------------------------");
        }


        private byte[] imageToByteArray(Bitmap imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public Bitmap byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            var returnImage = Bitmap.FromStream(ms);
            return (Bitmap)returnImage;
        }
    }
}
