namespace EventsSystem.WindowsFormsClient.Forms.Event
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Windows.Forms;

    public partial class RateEventForm : Form
    {
        private Uri URI_RATE;
        private MainForm parent;

        public RateEventForm()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.RateAnEvent();
        }

        private async void RateAnEvent()
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

                    string composed_url = string.Format("http://localhost:58368/api/events/rate/{0}/{1}", this.numericId.Value, this.numericRate.Value);
                    using (var response = await client.PostAsync(composed_url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("The event was rated.");
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

        private void RateEventForm_Load(object sender, EventArgs e)
        {
            this.parent = (MainForm)this.MdiParent;
            this.URI_RATE = new Uri(this.parent.BaseLink + "api/events/rate/{0}/{1}");
        }
    }
}