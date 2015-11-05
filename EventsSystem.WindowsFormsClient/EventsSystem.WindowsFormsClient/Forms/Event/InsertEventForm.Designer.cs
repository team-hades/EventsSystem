namespace EventsSystem.WindowsFormsClient.Forms.Event
{
    partial class InsertEventForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertEventForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.eventStateComboBox = new System.Windows.Forms.ComboBox();
            this.isPrivateEvent = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.longDescriptionInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.shortDescriptionInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.eventNameInput = new System.Windows.Forms.TextBox();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.eventPictureBox = new System.Windows.Forms.PictureBox();
            this.selectEventPictureButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.selectEventPictureButton);
            this.groupBox1.Controls.Add(this.eventPictureBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dateTimePickerEnd);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dateTimePickerStart);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.eventStateComboBox);
            this.groupBox1.Controls.Add(this.isPrivateEvent);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.longDescriptionInput);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.shortDescriptionInput);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.eventNameInput);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(497, 308);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Event insertion manager";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "State";
            // 
            // eventStateComboBox
            // 
            this.eventStateComboBox.FormattingEnabled = true;
            this.eventStateComboBox.Location = new System.Drawing.Point(119, 175);
            this.eventStateComboBox.Name = "eventStateComboBox";
            this.eventStateComboBox.Size = new System.Drawing.Size(121, 21);
            this.eventStateComboBox.TabIndex = 7;
            // 
            // isPrivateEvent
            // 
            this.isPrivateEvent.AutoSize = true;
            this.isPrivateEvent.Location = new System.Drawing.Point(246, 177);
            this.isPrivateEvent.Name = "isPrivateEvent";
            this.isPrivateEvent.Size = new System.Drawing.Size(59, 17);
            this.isPrivateEvent.TabIndex = 6;
            this.isPrivateEvent.Text = "Private";
            this.isPrivateEvent.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Long description";
            // 
            // longDescriptionInput
            // 
            this.longDescriptionInput.Location = new System.Drawing.Point(119, 73);
            this.longDescriptionInput.Multiline = true;
            this.longDescriptionInput.Name = "longDescriptionInput";
            this.longDescriptionInput.Size = new System.Drawing.Size(200, 96);
            this.longDescriptionInput.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Short description";
            // 
            // shortDescriptionInput
            // 
            this.shortDescriptionInput.Location = new System.Drawing.Point(119, 46);
            this.shortDescriptionInput.Name = "shortDescriptionInput";
            this.shortDescriptionInput.Size = new System.Drawing.Size(200, 20);
            this.shortDescriptionInput.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // eventNameInput
            // 
            this.eventNameInput.Location = new System.Drawing.Point(119, 19);
            this.eventNameInput.Name = "eventNameInput";
            this.eventNameInput.Size = new System.Drawing.Size(200, 20);
            this.eventNameInput.TabIndex = 0;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(119, 202);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerStart.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Start";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(119, 228);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerEnd.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "End";
            // 
            // eventPictureBox
            // 
            this.eventPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eventPictureBox.Location = new System.Drawing.Point(325, 19);
            this.eventPictureBox.Name = "eventPictureBox";
            this.eventPictureBox.Size = new System.Drawing.Size(160, 120);
            this.eventPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.eventPictureBox.TabIndex = 13;
            this.eventPictureBox.TabStop = false;
            // 
            // selectEventPictureButton
            // 
            this.selectEventPictureButton.Location = new System.Drawing.Point(326, 146);
            this.selectEventPictureButton.Name = "selectEventPictureButton";
            this.selectEventPictureButton.Size = new System.Drawing.Size(159, 23);
            this.selectEventPictureButton.TabIndex = 14;
            this.selectEventPictureButton.Text = "Select event image";
            this.selectEventPictureButton.UseVisualStyleBackColor = true;
            this.selectEventPictureButton.Click += new System.EventHandler(this.selectEventPictureButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(119, 255);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 15;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(119, 283);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 263);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Category";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 291);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Town";
            // 
            // InsertEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 333);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InsertEventForm";
            this.Text = "Insert an event";
            this.Load += new System.EventHandler(this.InsertEventForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox eventNameInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox shortDescriptionInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox longDescriptionInput;
        private System.Windows.Forms.CheckBox isPrivateEvent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox eventStateComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.PictureBox eventPictureBox;
        private System.Windows.Forms.Button selectEventPictureButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}