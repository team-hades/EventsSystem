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

	public partial class CreateForm : Form
    {
        private readonly Uri URI_CREATE_ACCOUNT;

        public CreateForm()
        {
            this.InitializeComponent();
            this.URI_CREATE_ACCOUNT = new Uri("http://localhost:58368/api/Account/Register");
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

        private void Initialise()
        {
            //Array values = Enum.GetValues(typeof(UserRole));

            //foreach (var item in values)
            //{
            //    ComboboxItem comboboxItem = new ComboboxItem();
            //    comboboxItem.Text = Enum.GetName(typeof(UserRole), item);
            //    comboboxItem.Value = item;
            //    this.userTypeComboBox.Items.Add(comboboxItem);
            //}
        }

        private void CreateForm_Load(object sender, EventArgs e)
        {
            this.Initialise();
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
                    MessageBox.Show(string.Format("{0} was created.", newUser.Email));
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
    }
}