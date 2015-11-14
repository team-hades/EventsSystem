namespace EventsSystem.WindowsFormsClient
{
    using Forms.Accounts;
    using Forms;
    using Forms.Event;
    using System;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        private readonly string DEFAULT_USER = "N/A";
        private readonly string DEFAULT_STATUS_PATTERN = "{0}";

        private bool isLogged = false;

        private AllEventsForm allEventsForm = null;
        private LoginForm loginView = null;
        private CreateAccountForm createAccountForm = null;
        private AccountInfoForm accountInfoForm = null;
        private SelectedEventForm selectedEventForm = null;
        private EventsByPageForm eventByPageForm = null;
        private SelectEventByCategoryForm selectEventByCategoryForm = null;
        private SelectEventByCategoryAndTownForm selectEventsByCategoryAndTownForm = null;
        private UpdateEventForm updateEventForm = null;
        public CreateEventForm createEventForm = null;

        private string bearer = null;

        public MainForm()
        {
            this.InitializeComponent();
        }

        public void Initialize()
        {
            this.StatusLabel = string.Format(this.DEFAULT_STATUS_PATTERN, this.DEFAULT_USER);
            this.ToggleControls();
        }

        public string Bearer
        {
            get { return this.bearer; }
            set { this.bearer = value; }
        }

        private void ToggleControls()
        {
            this.eventsToolStripMenuItem.Enabled = this.isLogged;
            this.userInfoToolStripMenuItem.Enabled = this.isLogged;
        }

        public string StatusLabel
        {
            get { return this.status_strip_label.Text; }
            set { this.status_strip_label.Text = string.Format(this.DEFAULT_STATUS_PATTERN, value); }
        }

        public bool SetAvailability
        {
            get { return this.isLogged; }
            set {
                this.isLogged = value;
                this.ToggleControls();
            }
        }

        private void eventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.allEventsForm == null)
            {
                this.allEventsForm = new AllEventsForm();
                this.allEventsForm.MdiParent = this;
                this.allEventsForm.FormClosed += new FormClosedEventHandler(this.eventForm_FormClosed);
                this.allEventsForm.Show();
            }
            else
            {
                this.allEventsForm.Activate();
            }
        }

        private void eventForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.allEventsForm = null;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Initialize();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.loginView == null)
            {
                this.loginView = new LoginForm();
                this.loginView.MdiParent = this;
                this.loginView.FormClosed += new FormClosedEventHandler(this.loginForm_FormClosed);
                this.loginView.Show();
            }
            else
            {
                this.allEventsForm.Activate();
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

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.createAccountForm == null)
            {
                this.createAccountForm = new CreateAccountForm();
                this.createAccountForm.MdiParent = this;
                this.createAccountForm.FormClosed += new FormClosedEventHandler(this.createForm_FormClosed);
                this.createAccountForm.Show();
            }
            else
            {
                this.createAccountForm.Activate();
            }
        }

        private void createForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.createAccountForm = null;
        }

        private void userInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.accountInfoForm == null)
            {
                this.accountInfoForm = new AccountInfoForm();
                this.accountInfoForm.MdiParent = this;
                this.accountInfoForm.FormClosed += new FormClosedEventHandler(this.accountInfo_FormClosed);
                this.accountInfoForm.Show();
            }
            else
            {
                this.accountInfoForm.Activate();
            }
        }

        private void accountInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.accountInfoForm = null;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Bearer = null;
            this.isLogged = false;
            this.ToggleControls();
        }

        private void selectedEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.selectedEventForm == null)
            {
                this.selectedEventForm = new SelectedEventForm();
                this.selectedEventForm.MdiParent = this;
                this.selectedEventForm.FormClosed += new FormClosedEventHandler(this.selectedEventForm_FormClosed);
                this.selectedEventForm.Show();
            }
            else
            {
                this.selectedEventForm.Activate();
            }
        }

        private void selectedEventForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.selectedEventForm = null;
        }

        private void eventsByPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.eventByPageForm == null)
            {
                this.eventByPageForm = new EventsByPageForm();
                this.eventByPageForm.MdiParent = this;
                this.eventByPageForm.FormClosed += new FormClosedEventHandler(this.eventbyPageFormm_FormClosed);
                this.eventByPageForm.Show();
            }
            else
            {
                this.eventByPageForm.Activate();
            }
        }

        private void eventbyPageFormm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.eventByPageForm = null;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.selectEventByCategoryForm == null)
            {
                this.selectEventByCategoryForm = new SelectEventByCategoryForm();
                this.selectEventByCategoryForm.MdiParent = this;
                this.selectEventByCategoryForm.FormClosed += new FormClosedEventHandler(this.selectEventsByCategory_FormClosed);
                this.selectEventByCategoryForm.Show();
            }
            else
            {
                this.selectEventByCategoryForm.Activate();
            }
        }

        private void selectEventsByCategory_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.selectEventByCategoryForm = null;
        }

        private void eventsByCategoryAndTownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.selectEventsByCategoryAndTownForm == null)
            {
                this.selectEventsByCategoryAndTownForm = new SelectEventByCategoryAndTownForm();
                this.selectEventsByCategoryAndTownForm.MdiParent = this;
                this.selectEventsByCategoryAndTownForm.FormClosed += new FormClosedEventHandler(this.selectEventsByCategoryAndTown_FormClosed);
                this.selectEventsByCategoryAndTownForm.Show();
            }
            else
            {
                this.selectEventsByCategoryAndTownForm.Activate();
            }
        }

        private void selectEventsByCategoryAndTown_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.selectEventsByCategoryAndTownForm = null;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.selectEventsByCategoryAndTownForm == null)
            {
                this.updateEventForm = new UpdateEventForm();
                this.updateEventForm.MdiParent = this;
                this.updateEventForm.FormClosed += new FormClosedEventHandler(this.updateEvent_FormClosed);
                this.updateEventForm.Show();
            }
            else
            {
                this.updateEventForm.Activate();
            }
        }

        private void updateEvent_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.updateEventForm = null;
        }

        private void eventsCreateAnEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.selectEventsByCategoryAndTownForm == null)
            {
                this.createEventForm = new CreateEventForm();
                this.createEventForm.MdiParent = this;
                this.createEventForm.FormClosed += new FormClosedEventHandler(this.createEventForm_FormClosed);
                this.createEventForm.Show();
            }
            else
            {
                this.createEventForm.Activate();
            }
        }

        private void createEventForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.createEventForm = null;
        }
    }
}