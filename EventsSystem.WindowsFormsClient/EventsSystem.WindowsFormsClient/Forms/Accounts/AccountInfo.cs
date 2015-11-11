using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventsSystem.WindowsFormsClient.Forms.Accounts
{
    public partial class AccountInfo : Form
    {
        private readonly Uri USER_INFO;
        private readonly string LABEL = "in user info";
        private MainForm parent;

        public AccountInfo()
        {
            InitializeComponent();
            USER_INFO = new Uri("http://localhost:58368/api/Account/UserInfo");
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
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could\'t pull and populate data!", "Error");
            }
        }
    }
}
