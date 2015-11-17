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
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void SelectedEventForm_Load(object sender, EventArgs e)
        {
            this.parent = (MainForm)this.MdiParent;
            this.URI_GET_EVENT_BY_ID = new Uri(this.parent.BaseLink + "api/Events");
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
    }
}
