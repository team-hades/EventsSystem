namespace EventsSystem.WindowsFormsClient.Forms.Event
{
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Windows.Forms;

    public partial class SelectEventByCategoryForm : Form
    {
        private Uri URI_GET_EVENT_BY_CATEGORY;
        private Uri URI_GET_CATEGORIES;
        private MainForm parent;

        public SelectEventByCategoryForm()
        {
            this.InitializeComponent();
            this.URI_GET_EVENT_BY_CATEGORY = new Uri("http://localhost:58368/api/events?category=");
            this.URI_GET_CATEGORIES = new Uri("http://localhost:58368/api/categories");
            this.GetCategories();
        }

        private async void GetCategories()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync(this.URI_GET_CATEGORIES))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var pulledCategories = await response.Content.ReadAsStringAsync();
                            //var stuff = JsonConvert.DeserializeObject< CategoryStruct>(pulledCategories);
                            dynamic dynamicCategories = JsonConvert.DeserializeObject(pulledCategories);
                            foreach (var cat in dynamicCategories)
                            {
                                string catName = (string)cat.Name;
                                this.comboBoxCategory.Items.Add(catName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could\'t pull and populate data!", "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty((string)this.comboBoxCategory.SelectedItem)){
                this.GetEventsByCategory((string)this.comboBoxCategory.SelectedItem);
            }
        }

        private async void GetEventsByCategory(string catId)
        {
            this.dataGridView.AutoGenerateColumns = true;

            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync(string.Format("{0}{1}", this.URI_GET_EVENT_BY_CATEGORY, catId)))
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
