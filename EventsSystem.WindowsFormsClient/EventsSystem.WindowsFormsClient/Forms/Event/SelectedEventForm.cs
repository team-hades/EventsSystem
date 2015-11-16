namespace EventsSystem.WindowsFormsClient.Forms.Event
{
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Windows.Forms;

    public partial class SelectedEventForm : Form
    {
        private Uri URI_GET_EVENT_BY_ID;
        private MainForm parent;

        public SelectedEventForm()
        {
            this.InitializeComponent();
            this.URI_GET_EVENT_BY_ID = new Uri("http://localhost:58368/api/Events");
        }

        private void getEventInfoButton_Click(object sender, EventArgs e)
        {
            int userInput = 1;
            try
            {
                userInput = int.Parse(this.idInput.Text);
                this.getEventInfoButton.Enabled = false;
                this.GetSelectedEvent(userInput);
                this.getEventInfoButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ID is invalid! Please enter an integer!");
            }
        }

        private void SelectedEventForm_Load(object sender, EventArgs e)
        {
            this.parent = (MainForm)this.MdiParent;
        }

        private async void GetSelectedEvent(int id)
        {
            this.dataGridView.AutoGenerateColumns = true;

            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync(string.Format("{0}/{1}", this.URI_GET_EVENT_BY_ID, id)))
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
    }
}
