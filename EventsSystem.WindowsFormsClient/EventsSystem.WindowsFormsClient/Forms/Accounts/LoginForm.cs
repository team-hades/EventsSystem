namespace EventsSystem.WindowsFormsClient.Forms
{
    using Accounts;
    using Data.Dropbox;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Net.Http;
    using System.Text;
    using System.Windows.Forms;

    public partial class LoginForm : Form
    {
        private Uri URI_TOKEN;

        private readonly string LABEL = "in Login";
        private MainForm parent;

        public LoginForm()
        {
            this.InitializeComponent();
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            this.parent = (MainForm)this.MdiParent;
            this.parent.StatusLabel = this.LABEL;
            this.URI_TOKEN = new Uri(this.parent.BaseLink + "Token");

            //Dropbox downloader
            try
            {
                string imageLocation = "avatar.png";

                DropboxHelper dh = new DropboxHelper();

                BackgroundWorker bgw = new BackgroundWorker();
                bgw.DoWork += delegate
                {
                    dh.Run().Wait();
                    dh.Download(imageLocation).Wait();

                    using (var fs = new System.IO.FileStream(imageLocation, System.IO.FileMode.Open))
                    {
                        var bmp = new Bitmap(fs);
                        this.pictureBox.Image = (Bitmap)bmp.Clone();
                    }

                    MessageBox.Show("Downloaded pic from dropbox.", "Success");
                };

                bgw.RunWorkerAsync();
            }
            catch
            {
                //silent excception
            }
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = this.URI_TOKEN;
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", this.textBoxUserName.Text),
                    new KeyValuePair<string, string>("password", this.textBoxPassword.Text),
                    new KeyValuePair<string, string>("grant_type", "password")
                });

                var result = client.PostAsync("/Token", content).Result;

                if (result.IsSuccessStatusCode)
                {
                    string jsonMessage;
                    using (Stream responseStream = await result.Content.ReadAsStreamAsync())
                    {
                        jsonMessage = new StreamReader(responseStream).ReadToEnd();
                    }

                    TokenResponseModel tokenResponse = (TokenResponseModel)JsonConvert.DeserializeObject(jsonMessage, typeof(TokenResponseModel));

                    if (tokenResponse != null)
                    {
                        this.parent.Bearer = tokenResponse.AccessToken;
                        this.parent.StatusLabel = String.Format("Logged user: {0}", this.textBoxUserName.Text);
                        this.parent.SetAvailability = true;
                        MessageBox.Show(String.Format("Welcome, {0}!", this.textBoxUserName.Text), "Login");
                    }
                }
                else
                {
                    MessageBox.Show(result.ReasonPhrase, "Error");
                }
            }
        }
    }
}
