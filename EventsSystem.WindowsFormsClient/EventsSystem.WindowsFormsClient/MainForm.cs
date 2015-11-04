namespace EventsSystem.WindowsFormsClient
{
    using Forms;
    using Forms.Event;
    using System;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        private readonly string DEFAULT_STATUS_LABEL = "Ready";
        private readonly string DEFAULT_STATUS_PATTERN = "Client: {0}.";

        private eventForm eventForm = null;
        private loginForm loginView = null;

        public MainForm()
        {
            this.InitializeComponent();
        }

        public void Initialize()
        {
            this.StatusLabel = string.Format(this.DEFAULT_STATUS_PATTERN, this.DEFAULT_STATUS_LABEL);
        }

        public string StatusLabel
        {
            get { return this.status_strip_label.Text; }
            set { this.status_strip_label.Text = string.Format(this.DEFAULT_STATUS_PATTERN, value); }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void eventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.eventForm == null)
            {
                this.eventForm = new eventForm();
                this.eventForm.MdiParent = this;
                this.eventForm.FormClosed += new FormClosedEventHandler(this.eventForm_FormClosed);
                this.eventForm.Show();
            }
            else
            {
                this.eventForm.Activate();
            }
        }

        private void eventForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.eventForm = null;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Initialize();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.loginView == null)
            {
                this.loginView = new loginForm();
                this.loginView.MdiParent = this;
                this.loginView.FormClosed += new FormClosedEventHandler(this.loginForm_FormClosed);
                this.loginView.Show();
            }
            else
            {
                this.eventForm.Activate();
            }
        }

        private void loginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.loginView = null;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}