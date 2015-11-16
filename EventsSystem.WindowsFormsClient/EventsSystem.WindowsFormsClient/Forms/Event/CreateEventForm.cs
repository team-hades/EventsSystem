namespace EventsSystem.WindowsFormsClient.Forms.Event
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Windows.Forms;

    public partial class CreateEventForm : Form
    {
        private Uri POST_EVENT;
        private Uri URI_GET_CATEGORIES;
        private Uri URI_GET_TOWNS;
        private MainForm parent;

        public CreateEventForm()
        {
            this.InitializeComponent();
            this.POST_EVENT = new Uri("http://localhost:58368/api/events");
            this.URI_GET_CATEGORIES = new Uri("http://localhost:58368/api/categories");
            this.URI_GET_TOWNS = new Uri("http://localhost:58368/api/towns");
            this.GetTowns();
            this.GetCategories();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.PostAnEvent();
        }

        private async void PostAnEvent()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", this.parent.Bearer));

                    var raw = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("Name", this.nameTextBox.Text.ToString()),
                        new KeyValuePair<string, string>("ShortDescrtiption", this.shortDescriptionTextBox.Text.ToString()),
                        new KeyValuePair<string, string>("IsPrivate", this.isPrivateCheckBox.Checked.ToString()),
                        new KeyValuePair<string, string>("StartDate", this.startDateTimePicker.Value.ToString()),
                        new KeyValuePair<string, string>("EndDate", this.endDateTimePicker.Value.ToString()),
                        new KeyValuePair<string, string>("Town", (string)this.comboBoxTowns.SelectedItem),
                        new KeyValuePair<string, string>("Category", (string)this.comboBoxCategory.SelectedItem),
                        new KeyValuePair<string, string>("CommentsCount", this.commentsNumeric.Value.ToString())
                    };

                    var content = new FormUrlEncodedContent(raw);
                    //
                    using (var response = await client.PostAsync(this.POST_EVENT.ToString(), content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("The event was created.");
                        }
                        else
                        {
                            MessageBox.Show("Something happened!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could\'t pull and populate data!", "Error");
            }
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
                                this.comboBoxTowns.Items.Add(catName);
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

        private void CreateEventForm_Load(object sender, EventArgs e)
        {
            this.parent = (MainForm)this.MdiParent;
        }
    }
}
