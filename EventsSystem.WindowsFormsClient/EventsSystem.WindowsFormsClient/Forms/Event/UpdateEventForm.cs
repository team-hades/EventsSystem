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
    public partial class UpdateEventForm : Form
    {
        private Uri URI_PUT_EVENT;
        private Uri URI_GET_CATEGORIES;
        private Uri URI_GET_TOWNS;
        private MainForm parent;

        public UpdateEventForm()
        {
            this.InitializeComponent();
            this.URI_PUT_EVENT = new Uri("http://localhost:58368/api/events/{0}");
            this.URI_GET_CATEGORIES = new Uri("http://localhost:58368/api/categories");
            this.URI_GET_TOWNS = new Uri("http://localhost:58368/api/towns");
            this.GetTowns();
            this.GetCategories();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.UpdateAnEvent();
        }

        private async void UpdateAnEvent()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var raw = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("Name", this.nameTextBox.Text.ToString()),
                        new KeyValuePair<string, string>("ShortDescrtiption", this.shortDescriptionTextBox.Text.ToString()),
                        new KeyValuePair<string, string>("IsPrivate", this.isPrivateCheckBox.Checked.ToString()),
                        new KeyValuePair<string, string>("StartDate", this.startDateTimePicker.ToString()),
                        new KeyValuePair<string, string>("EndDate", this.endDateTimePicker.ToString()),
                        new KeyValuePair<string, string>("Town", (string)this.comboBoxCategory.SelectedItem),
                        new KeyValuePair<string, string>("Category", (string)this.comboBoxTowns.SelectedItem),
                        new KeyValuePair<string, string>("CommentsCount", this.commentsNumeric.Value.ToString())
                    };

                    var content = new FormUrlEncodedContent(raw);
                    //
                    using (var response = await client.PutAsync(string.Format(this.URI_PUT_EVENT.ToString(), this.numericUpDownId.Value.ToString()), content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("The event was updated.");
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
    }
}
