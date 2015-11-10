namespace EventsSystem.WindowsFormsClient.Forms.Event
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Windows.Forms;
    using Data.Models;
    using Newtonsoft.Json;
    using System.Data;

    public partial class eventForm : Form
    {
        private readonly Uri URI_EVENTS;
        private readonly string LABEL = "in Events";
        private MainForm parent;

        public eventForm()
        {
            this.InitializeComponent();
            this.URI_EVENTS = new Uri("http://localhost:58368/api/Events");
        }

        private void EventForm_Load(object sender, EventArgs e)
        {
            this.parent = (MainForm)this.MdiParent;
            this.parent.StatusLabel = this.LABEL;
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
                            dataGridView.DataSource = JsonConvert.DeserializeObject(pulledEvents); ;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could\'t pull and populate data!", "Error");
            }
        }

        private void insertEvent_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void updateEvent_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void deleteEvent_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
