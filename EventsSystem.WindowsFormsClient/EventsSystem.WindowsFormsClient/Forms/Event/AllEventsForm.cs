namespace EventsSystem.WindowsFormsClient.Forms.Event
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Windows.Forms;
    using Data.Models;
    using Newtonsoft.Json;
    using System.Data;

    public partial class AllEventsForm : Form
    {
        private Uri URI_EVENTS;
        private MainForm parent;

        public AllEventsForm()
        {
            this.InitializeComponent();
        }

        private void EventForm_Load(object sender, EventArgs e)
        {
            this.parent = (MainForm)this.MdiParent;
            //this.parent.StatusLabel = this.LABEL;
            this.URI_EVENTS = new Uri(this.parent.BaseLink + "api/Events");
        }

        private void getAllEvents_Click(object sender, EventArgs e)
        {
            this.getAllEvents.Enabled = false;
            this.GetAllEvents();
            this.getAllEvents.Enabled = true;
        }

        private async void GetAllEvents()
        {
            this.dataGridView.AutoGenerateColumns = true;

            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync(this.URI_EVENTS))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var pulledEvents = await response.Content.ReadAsStringAsync();
                            dataGridView.DataSource = JsonConvert.DeserializeObject(pulledEvents);
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
