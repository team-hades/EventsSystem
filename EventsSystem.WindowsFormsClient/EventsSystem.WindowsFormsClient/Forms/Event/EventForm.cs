namespace EventsSystem.WindowsFormsClient.Forms.Event
{
    using System;
    using System.Windows.Forms;

    public partial class eventForm : Form
    {
        private readonly string LABEL = "in Events";
        private MainForm parent;

        public eventForm()
        {
            this.InitializeComponent();
        }

        private void EventForm_Load(object sender, EventArgs e)
        {
            this.parent = (MainForm)this.MdiParent;
            this.parent.StatusLabel = this.LABEL;
        }

        private void getAllEvents_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void insertEvent_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void updateEvent_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void deleteEvent_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
