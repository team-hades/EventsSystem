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
    public partial class SelectEventByCategoryForm : Form
    {
        private Uri URI_GET_EVENT_BY_CATEGORY;
        private Uri URI_GET_CATEGORIES;
        private MainForm parent;

        public SelectEventByCategoryForm()
        {
            this.InitializeComponent();
            this.URI_GET_EVENT_BY_CATEGORY = new Uri("http://localhost:58368/api/events?page=");
            this.URI_GET_CATEGORIES = new Uri("http://localhost:58368/api/categories");
        }

    }
}
