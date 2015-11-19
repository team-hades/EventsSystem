namespace EventsSystem.WindowsFormsClient.Forms.Event
{
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Windows.Forms;

    public partial class SelectEventByCategoryAndTownForm : Form
    {
        private Uri URI_GET_EVENT_BY_CATEGORY;
        private Uri URI_GET_CATEGORIES;
        private Uri URI_GET_TOWNS;
        private MainForm parent;

        public SelectEventByCategoryAndTownForm()
        {
            this.InitializeComponent();
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
                MessageBox.Show("Could\'t pull and populate data!", ex.Message);
            }
        }

        private async void GetTowns()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync(this.URI_GET_TOWNS))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var pulledTowns = await response.Content.ReadAsStringAsync();
                            dynamic dynamicTowns = JsonConvert.DeserializeObject(pulledTowns);
                            foreach (var cat in dynamicTowns)
                            {
                                string catName = (string)cat.Name;
                                this.townCombobox.Items.Add(catName);
                            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty((string)this.comboBoxCategory.SelectedItem)){
                this.GetEventsByCategory((string)this.comboBoxCategory.SelectedItem, (string)this.townCombobox.SelectedItem);
            }
        }

        private async void GetEventsByCategory(string catId, string townId)
        {
            this.dataGridView.AutoGenerateColumns = true;

            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync(string.Format("{0}?category={1}&town={2}", this.URI_GET_EVENT_BY_CATEGORY, catId, townId)))
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

        private void SelectEventByCategoryAndTownForm_Load(object sender, EventArgs e)
        {
            this.parent = (MainForm)this.MdiParent;
            this.URI_GET_EVENT_BY_CATEGORY = new Uri(this.parent.BaseLink + "api/events");
            this.URI_GET_CATEGORIES = new Uri(this.parent.BaseLink + "api/categories");
            this.URI_GET_TOWNS = new Uri(this.parent.BaseLink + "api/towns");
            this.GetCategories();
            this.GetTowns();
        }
    }
}
