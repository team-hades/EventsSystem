namespace EventsSystem.WindowsFormsClient.Forms
{
    using System;
    using System.Windows.Forms;

    public partial class setupIpForm : Form
    {
        private MainForm parent;

        public setupIpForm()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.parent.BaseLink = this.textBoxBaseLink.Text;
        }

        private void setupIpForm_Load(object sender, EventArgs e)
        {
            this.parent = (MainForm)this.MdiParent;
        }
    }
}
