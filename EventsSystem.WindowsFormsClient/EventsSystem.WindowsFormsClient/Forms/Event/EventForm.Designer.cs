namespace EventsSystem.WindowsFormsClient.Forms.Event
{
    partial class eventForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(eventForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.deleteEvent = new System.Windows.Forms.Button();
            this.updateEvent = new System.Windows.Forms.Button();
            this.insertEvent = new System.Windows.Forms.Button();
            this.getAllEvents = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.status_strip = new System.Windows.Forms.StatusStrip();
            this.status_strip_label = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.status_strip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.deleteEvent);
            this.groupBox1.Controls.Add(this.updateEvent);
            this.groupBox1.Controls.Add(this.insertEvent);
            this.groupBox1.Controls.Add(this.getAllEvents);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(608, 57);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Events manager";
            // 
            // deleteEvent
            // 
            this.deleteEvent.Location = new System.Drawing.Point(467, 19);
            this.deleteEvent.Name = "deleteEvent";
            this.deleteEvent.Size = new System.Drawing.Size(135, 25);
            this.deleteEvent.TabIndex = 3;
            this.deleteEvent.Text = "Delete An Event";
            this.deleteEvent.UseVisualStyleBackColor = true;
            this.deleteEvent.Click += new System.EventHandler(this.deleteEvent_Click);
            // 
            // updateEvent
            // 
            this.updateEvent.Location = new System.Drawing.Point(312, 19);
            this.updateEvent.Name = "updateEvent";
            this.updateEvent.Size = new System.Drawing.Size(135, 25);
            this.updateEvent.TabIndex = 2;
            this.updateEvent.Text = "Update An Event";
            this.updateEvent.UseVisualStyleBackColor = true;
            this.updateEvent.Click += new System.EventHandler(this.updateEvent_Click);
            // 
            // insertEvent
            // 
            this.insertEvent.Location = new System.Drawing.Point(161, 19);
            this.insertEvent.Name = "insertEvent";
            this.insertEvent.Size = new System.Drawing.Size(135, 25);
            this.insertEvent.TabIndex = 1;
            this.insertEvent.Text = "Insert An Event";
            this.insertEvent.UseVisualStyleBackColor = true;
            this.insertEvent.Click += new System.EventHandler(this.insertEvent_Click);
            // 
            // getAllEvents
            // 
            this.getAllEvents.Location = new System.Drawing.Point(6, 19);
            this.getAllEvents.Name = "getAllEvents";
            this.getAllEvents.Size = new System.Drawing.Size(135, 25);
            this.getAllEvents.TabIndex = 0;
            this.getAllEvents.Text = "Get All Events";
            this.getAllEvents.UseVisualStyleBackColor = true;
            this.getAllEvents.Click += new System.EventHandler(this.getAllEvents_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(12, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(608, 352);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Events data";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(595, 326);
            this.dataGridView1.TabIndex = 0;
            // 
            // status_strip
            // 
            this.status_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_strip_label});
            this.status_strip.Location = new System.Drawing.Point(0, 431);
            this.status_strip.Name = "status_strip";
            this.status_strip.Size = new System.Drawing.Size(632, 22);
            this.status_strip.TabIndex = 3;
            this.status_strip.Text = "status_strip";
            // 
            // status_strip_label
            // 
            this.status_strip_label.Name = "status_strip_label";
            this.status_strip_label.Size = new System.Drawing.Size(138, 17);
            this.status_strip_label.Text = "Events: 0 available entries.";
            // 
            // eventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.status_strip);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "eventForm";
            this.Text = "Events";
            this.Load += new System.EventHandler(this.EventForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.status_strip.ResumeLayout(false);
            this.status_strip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button deleteEvent;
        private System.Windows.Forms.Button updateEvent;
        private System.Windows.Forms.Button insertEvent;
        private System.Windows.Forms.Button getAllEvents;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.StatusStrip status_strip;
        private System.Windows.Forms.ToolStripStatusLabel status_strip_label;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}