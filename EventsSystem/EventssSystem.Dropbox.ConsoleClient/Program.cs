namespace EventssSystem.Dropbox.ConsoleClient
{
    using EventsSystem.Data.Dropbox;
    using global::Dropbox.Api;

    public class Program
    {
        static void Main(string[] args)
        {
            var dropbox = new DropboxConnector();

            dropbox.Run().Wait();

            using (var dbx = new DropboxClient(dropbox.AccessToken))
            {
                dropbox.ListRootFolder(dbx).Wait();

            }

            System.Console.WriteLine("end");
            System.Console.ReadLine();
        }
    }
}
