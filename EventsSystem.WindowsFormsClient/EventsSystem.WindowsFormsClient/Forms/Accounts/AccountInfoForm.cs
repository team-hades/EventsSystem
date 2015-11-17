namespace EventsSystem.WindowsFormsClient.Forms.Accounts
{
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Windows.Forms;

    public partial class AccountInfoForm : Form
    {
        private Uri USER_INFO;
        private readonly string LABEL = "in user info";
        private MainForm parent;

        public AccountInfoForm()
        {
            InitializeComponent();
        }

        private void getUserInfoButton_Click(object sender, EventArgs e)
        {
            this.getUserInfoButton.Enabled = false;
            this.GetUserInfo();
            this.getUserInfoButton.Enabled = true;
        }

        private void AccountInfo_Load(object sender, EventArgs e)
        {
            this.parent = (MainForm)this.MdiParent;
            this.parent.StatusLabel = this.LABEL;
            USER_INFO = new Uri(this.parent.BaseLink + "api/Account/UserInfo");
        }

        private async void GetUserInfo()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", this.parent.Bearer));
                    //client.DefaultRequestHeaders.Add("Accept", "application/json");
                    using (var response = await client.GetAsync(this.USER_INFO))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var pulledInfo = await response.Content.ReadAsStringAsync();
                            dynamic parsed = JsonConvert.DeserializeObject(pulledInfo);

                            listBox.Items.Add(Convert.ToString(parsed));
                        }
                        else
                        {
                            MessageBox.Show(response.ReasonPhrase, "Error");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
