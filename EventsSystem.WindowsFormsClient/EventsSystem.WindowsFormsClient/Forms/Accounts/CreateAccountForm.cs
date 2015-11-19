namespace EventsSystem.WindowsFormsClient.Forms.Accounts
{
    using Data.Models;
    using Api.Models;
    using Newtonsoft.Json;
    using System;
    using System.Drawing;
    using System.Net.Http;
    using System.Text;
    using System.Windows.Forms;
    using Api.Models.Accounts;
    using Data.Dropbox;
    using System.ComponentModel;
    using System.Threading;

    public partial class CreateAccountForm : Form
    {
        private Uri URI_CREATE_ACCOUNT;
        private MainForm parent;

        public CreateAccountForm()
        {
            this.InitializeComponent();
        }

        private class ComboboxItem
        {
            public string Text { get; set; }

            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        //private void Initialise()
        //{
            //Array values = Enum.GetValues(typeof(UserRole));

            //foreach (var item in values)
            //{
            //    ComboboxItem comboboxItem = new ComboboxItem();
            //    comboboxItem.Text = Enum.GetName(typeof(UserRole), item);
            //    comboboxItem.Value = item;
            //    this.userTypeComboBox.Items.Add(comboboxItem);
            //}
        //}

        private void CreateForm_Load(object sender, EventArgs e)
        {
            this.parent = (MainForm)this.MdiParent;
            this.URI_CREATE_ACCOUNT = new Uri(this.parent.BaseLink + "api/Account/Register");
        }

        private async void createAccount_Click(object sender, EventArgs e)
        {
            RegisterBindingModel newUser = new RegisterBindingModel();
            newUser.Email = this.textBoxEmail.Text;
            newUser.Password = this.textBoxPassword.Text;
            newUser.ConfirmPassword = this.textBoxConfirmPassword.Text;

            using (var client = new HttpClient())
            {
                var serializedProduct = JsonConvert.SerializeObject(newUser);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(this.URI_CREATE_ACCOUNT, content);
                if ((int)result.StatusCode == 200)
                {
                    MessageBox.Show(string.Format("{0} was created.", newUser.Email), "Registration");
                    this.textBoxEmail.Clear();
                    this.textBoxPassword.Clear();
                    this.textBoxConfirmPassword.Clear();
                }
                else
                {
                    MessageBox.Show(string.Format("Error while creating{0}! Details: {1}", newUser.Email, result.ReasonPhrase));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.openFileDialog.Title = "Select an avatar.";
            this.openFileDialog.FileName = "";
            this.openFileDialog.Filter = "PNG Images|*.png|JPEG Images|*.jpg|GIF Images|*.gif|BITMAPS|*.bmp";

            bool toUpload = false;
            string imageLocation = string.Empty;

            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imageLocation = this.openFileDialog.FileName;

                using (var fs = new System.IO.FileStream(imageLocation, System.IO.FileMode.Open))
                {
                    var bmp = new Bitmap(fs);
                    this.pictureBox.Image = (Bitmap)bmp.Clone();
                    toUpload = true;
                }
                
            }
            this.openFileDialog.Dispose();

            if (toUpload)
            {
                DropboxHelper dh = new DropboxHelper();

                BackgroundWorker bgw = new BackgroundWorker();
                bgw.DoWork += delegate
                {
                    dh.Run().Wait();
                    dh.UploadProfilePicture(imageLocation).Wait();
                    MessageBox.Show("Uploaded pic to dropbox.", "Success");
                };

                bgw.RunWorkerAsync();
            }
        }
    }
}