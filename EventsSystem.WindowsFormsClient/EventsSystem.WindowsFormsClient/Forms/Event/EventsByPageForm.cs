﻿namespace EventsSystem.WindowsFormsClient.Forms.Event
{
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Windows.Forms;

    public partial class EventsByPageForm : Form
    {
        private Uri URI_GET_EVENT_BY_PAGE;
        private MainForm parent;
        private int lastPage = 0;

        public EventsByPageForm()
        {
            InitializeComponent();
        }

        private void EventsByPageForm_Load(object sender, EventArgs e)
        {
            this.parent = (MainForm)this.MdiParent;
            this.URI_GET_EVENT_BY_PAGE = new Uri(this.parent.BaseLink + "api/events?page=");
        }

        private async void GetEventsByPage(int id)
        {
            this.dataGridView.AutoGenerateColumns = true;

            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync(string.Format("{0}{1}", this.URI_GET_EVENT_BY_PAGE, id)))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var pulledEvents = await response.Content.ReadAsStringAsync();
                            dataGridView.DataSource = JsonConvert.DeserializeObject(pulledEvents); ;
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

        private void previousButton_Click(object sender, EventArgs e)
        {
            this.previousButton.Enabled = false;
            if (this.lastPage > 0)
            {
                this.lastPage--;
            }

            this.GetEventsByPage(this.lastPage);
            this.previousButton.Enabled = true;
        }

        private void populateButton_Click(object sender, EventArgs e)
        {
            this.populateButton.Enabled = false;
            this.GetEventsByPage(this.lastPage);
            this.previousButton.Enabled = true;
            this.nextButton.Enabled = true;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            this.nextButton.Enabled = false;
            this.lastPage++;
            this.GetEventsByPage(this.lastPage);
            this.nextButton.Enabled = true;
        }
    }
}