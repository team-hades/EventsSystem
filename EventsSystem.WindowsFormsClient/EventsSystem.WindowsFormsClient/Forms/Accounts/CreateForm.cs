namespace EventsSystem.WindowsFormsClient.Forms.Accounts
{
    using Data.Models;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class CreateForm : Form
    {
        public CreateForm()
        {
            this.InitializeComponent();
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

        private void Initialise()
        {
            Array values = Enum.GetValues(typeof(UserRole));

            foreach (var item in values)
            {
                ComboboxItem comboboxItem = new ComboboxItem();
                comboboxItem.Text = Enum.GetName(typeof(UserRole), item);
                comboboxItem.Value = item;
                this.userTypeComboBox.Items.Add(comboboxItem);
            }
        }

        private void loadPictureButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "bmp files (*.bmp)|*.bmp";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.userPictureBox.Image = new Bitmap(dlg.FileName);
                }
            }
        }

        private void CreateForm_Load(object sender, EventArgs e)
        {
            this.Initialise();
        }
    }
}