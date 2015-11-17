namespace EventsSystem.WindowsFormsClient.Forms.Event
{
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Windows.Forms;

    public partial class DeleteEventForm : Form
    {
        private Uri DELETE_EVENT;
        private MainForm parent;

        public DeleteEventForm()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DeleteAnEvent();
        }

        private async void DeleteAnEvent()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", this.parent.Bearer));

                    using (var response = await client.DeleteAsync(this.DELETE_EVENT.ToString() + "/" + this.numericId.Value))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("The event was deleted.");
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

        private void CreateEventForm_Load(object sender, EventArgs e)
        {
            this.parent = (MainForm)this.MdiParent;
            this.DELETE_EVENT = new Uri(this.parent.BaseLink + "api/events");
        }
    }
}
