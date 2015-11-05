using EventsSystem.Common.Constants;
using EventsSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventsSystem.WindowsFormsClient.Forms.Event
{
    public partial class InsertEventForm : Form
    {
        public InsertEventForm()
        {
            this.InitializeComponent();
        }

        private void Initialize()
        {
            this.eventNameInput.MaxLength = ValidationConstants.MaxEventName;
            this.shortDescriptionInput.MaxLength = ValidationConstants.MaxEventShortDescription;
            this.longDescriptionInput.MaxLength = ValidationConstants.MaxEventLongDescription;

            Array values = Enum.GetValues(typeof(EventState));

            foreach (var item in values)
            {
                //MessageBox.Show(String.Format("{0}: {1}", Enum.GetName(typeof(EventState), item), item));
                ComboboxItem comboboxItem = new ComboboxItem();
                comboboxItem.Text = Enum.GetName(typeof(EventState), item);
                comboboxItem.Value = item;
                this.eventStateComboBox.Items.Add(comboboxItem);
            }

            //TODO: Populate Categories

            //TODO: Populate Towns
        }

        private class ComboboxItem
        {
            public string Text { get; set; }

            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void InsertEventForm_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        private void selectEventPictureButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "bmp files (*.bmp)|*.bmp";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //PictureBox PictureBox1 = new PictureBox();

                    // Create a new Bitmap object from the picture file on disk,
                    // and assign that to the PictureBox.Image property
                    this.eventPictureBox.Image = new Bitmap(dlg.FileName);
                }
            }
        }
    }
}
