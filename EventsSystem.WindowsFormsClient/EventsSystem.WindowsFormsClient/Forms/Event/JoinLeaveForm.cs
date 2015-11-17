namespace EventsSystem.WindowsFormsClient.Forms.Event
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Windows.Forms;

    public partial class JoinLeaveForm : Form
    {
        private Uri URI_JOIN_LEAVE;
        private MainForm parent;

        public JoinLeaveForm()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.JoinAnEvent();
        }

        private async void JoinAnEvent()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", this.parent.Bearer));

                    var raw = new List<KeyValuePair<string, string>>
                    {
                    };

                    var content = new FormUrlEncodedContent(raw);
                    string link = this.URI_JOIN_LEAVE.ToString() + "join/" + this.numericId.Value;
                    using (var response = await client.PostAsync(link, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("The event was joined.");
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

        private async void LeaveAnEvent()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", this.parent.Bearer));

                    var raw = new List<KeyValuePair<string, string>>
                    {
                    };

                    var content = new FormUrlEncodedContent(raw);
                    string link = this.URI_JOIN_LEAVE.ToString() + "leave/" + this.numericId.Value;
                    using (var response = await client.PutAsync(link, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("The event was left.");
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

        private void JoinLeaveForm_Load(object sender, EventArgs e)
        {
            this.parent = (MainForm)this.MdiParent;
            this.URI_JOIN_LEAVE = new Uri(this.parent.BaseLink + "api/events/");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.LeaveAnEvent();
        }
    }
}
