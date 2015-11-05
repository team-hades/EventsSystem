namespace EventsSystem.WindowsFormsClient.Forms
{
    using System;
    using System.Windows.Forms;

    public partial class loginForm : Form
    {
        private readonly string LABEL = "in Login";
        private MainForm parent;

        public loginForm()
        {
            this.InitializeComponent();
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            this.parent = (MainForm)this.MdiParent;
            this.parent.StatusLabel = this.LABEL;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.parent.SetAvailability = true;
        }
    }
}
