namespace EventsSystem.WindowsFormsClient.Forms.Event
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Windows.Forms;

    public partial class JoinLeaveForm : Form
    {
        private readonly Uri URI_JOIN_LEAVE;
        private MainForm parent;

        public JoinLeaveForm()
        {
            this.InitializeComponent();
            this.URI_JOIN_LEAVE = new Uri("http://localhost:58368/api/events/");
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

                    using (var response = await client.PostAsync(this.URI_JOIN_LEAVE.ToString() + "/" + this.numericId.Value, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("The event was joined.");
                        }
                        else
                        {
                            MessageBox.Show("Something happened!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", "Error");
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

                    using (var response = await client.PutAsync(this.URI_JOIN_LEAVE.ToString() + "/" + this.numericId.Value, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("The event was left.");
                        }
                        else
                        {
                            MessageBox.Show("Something happened!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", "Error");
            }
        }

        private void JoinLeaveForm_Load(object sender, EventArgs e)
        {
            this.parent = (MainForm)this.MdiParent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.LeaveAnEvent();
        }
    }
}
