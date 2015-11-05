﻿namespace EventsSystem.WindowsFormsClient.Forms.Event
{
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Windows.Forms;
    using Data.Models;

    public partial class eventForm : Form
    {
        private readonly Uri WEB_API_ACCESS_POINT = new Uri("PROVIDE_HTTP_HERE");
        private readonly string LABEL = "in Events";
        private MainForm parent;

        public eventForm()
        {
            this.InitializeComponent();
        }

        private void EventForm_Load(object sender, EventArgs e)
        {
            this.parent = (MainForm)this.MdiParent;
            this.parent.StatusLabel = this.LABEL;
        }

        private void getAllEvents_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void GetAllEvents()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync(this.WEB_API_ACCESS_POINT))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var pulledEvents = await response.Content.ReadAsStringAsync();

                            dataGridView.DataSource = JsonConvert.DeserializeObject<Event[]>(pulledEvents).ToList();

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
