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

namespace EventsSystem.WindowsFormsClient.Forms.Event
{
    public partial class EventsByPageForm : Form
    {
        private Uri URI_GET_EVENT_BY_PAGE;
        private MainForm parent;
        private int lastPage = 0;

        public EventsByPageForm()
        {
            InitializeComponent();
            this.URI_GET_EVENT_BY_PAGE = new Uri("http://localhost:58368/api/events?page=");
        }

        private void EventsByPageForm_Load(object sender, EventArgs e)
        {
            this.parent = (MainForm)this.MdiParent;
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
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could\'t pull and populate data!", "Error");
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