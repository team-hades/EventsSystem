﻿namespace EventsSystem.WindowsFormsClient
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.main_menu_strip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventsByPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.eventsByCategoryAndTownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.eventsCreateAnEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventsDeleteAnEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventsJoinLeaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventsRateAnEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.status_strip = new System.Windows.Forms.StatusStrip();
            this.status_strip_label = new System.Windows.Forms.ToolStripStatusLabel();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverSetupIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_strip.SuspendLayout();
            this.status_strip.SuspendLayout();
            this.SuspendLayout();
            // 
            // main_menu_strip
            // 
            this.main_menu_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.accountsToolStripMenuItem,
            this.eventsToolStripMenuItem,
            this.serverToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.main_menu_strip.Location = new System.Drawing.Point(0, 0);
            this.main_menu_strip.Name = "main_menu_strip";
            this.main_menu_strip.Size = new System.Drawing.Size(794, 24);
            this.main_menu_strip.TabIndex = 0;
            this.main_menu_strip.Text = "Main menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // accountsToolStripMenuItem
            // 
            this.accountsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.createToolStripMenuItem,
            this.userInfoToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
            this.accountsToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.accountsToolStripMenuItem.Text = "Accounts";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.createToolStripMenuItem.Text = "Create";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            // 
            // userInfoToolStripMenuItem
            // 
            this.userInfoToolStripMenuItem.Name = "userInfoToolStripMenuItem";
            this.userInfoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.userInfoToolStripMenuItem.Text = "User Info";
            this.userInfoToolStripMenuItem.Click += new System.EventHandler(this.userInfoToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // eventsToolStripMenuItem
            // 
            this.eventsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.selectedEventToolStripMenuItem,
            this.eventsByPageToolStripMenuItem,
            this.toolStripMenuItem1,
            this.eventsByCategoryAndTownToolStripMenuItem,
            this.toolStripMenuItem2,
            this.eventsCreateAnEventToolStripMenuItem,
            this.eventsDeleteAnEventToolStripMenuItem,
            this.eventsJoinLeaveToolStripMenuItem,
            this.eventsRateAnEventToolStripMenuItem});
            this.eventsToolStripMenuItem.Name = "eventsToolStripMenuItem";
            this.eventsToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.eventsToolStripMenuItem.Text = "Events";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.viewToolStripMenuItem.Text = "Events: All";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.eventsToolStripMenuItem_Click);
            // 
            // selectedEventToolStripMenuItem
            // 
            this.selectedEventToolStripMenuItem.Name = "selectedEventToolStripMenuItem";
            this.selectedEventToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.selectedEventToolStripMenuItem.Text = "Events: by id";
            this.selectedEventToolStripMenuItem.Click += new System.EventHandler(this.selectedEventToolStripMenuItem_Click);
            // 
            // eventsByPageToolStripMenuItem
            // 
            this.eventsByPageToolStripMenuItem.Name = "eventsByPageToolStripMenuItem";
            this.eventsByPageToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.eventsByPageToolStripMenuItem.Text = "Events: by page";
            this.eventsByPageToolStripMenuItem.Click += new System.EventHandler(this.eventsByPageToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(220, 22);
            this.toolStripMenuItem1.Text = "Events: by category";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // eventsByCategoryAndTownToolStripMenuItem
            // 
            this.eventsByCategoryAndTownToolStripMenuItem.Name = "eventsByCategoryAndTownToolStripMenuItem";
            this.eventsByCategoryAndTownToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.eventsByCategoryAndTownToolStripMenuItem.Text = "Events: by category and town";
            this.eventsByCategoryAndTownToolStripMenuItem.Click += new System.EventHandler(this.eventsByCategoryAndTownToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(220, 22);
            this.toolStripMenuItem2.Text = "Events: Update an event";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // eventsCreateAnEventToolStripMenuItem
            // 
            this.eventsCreateAnEventToolStripMenuItem.Name = "eventsCreateAnEventToolStripMenuItem";
            this.eventsCreateAnEventToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.eventsCreateAnEventToolStripMenuItem.Text = "Events: Create an event";
            this.eventsCreateAnEventToolStripMenuItem.Click += new System.EventHandler(this.eventsCreateAnEventToolStripMenuItem_Click);
            // 
            // eventsDeleteAnEventToolStripMenuItem
            // 
            this.eventsDeleteAnEventToolStripMenuItem.Name = "eventsDeleteAnEventToolStripMenuItem";
            this.eventsDeleteAnEventToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.eventsDeleteAnEventToolStripMenuItem.Text = "Events: Delete an event";
            this.eventsDeleteAnEventToolStripMenuItem.Click += new System.EventHandler(this.eventsDeleteAnEventToolStripMenuItem_Click);
            // 
            // eventsJoinLeaveToolStripMenuItem
            // 
            this.eventsJoinLeaveToolStripMenuItem.Name = "eventsJoinLeaveToolStripMenuItem";
            this.eventsJoinLeaveToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.eventsJoinLeaveToolStripMenuItem.Text = "Events: Join/Leave";
            this.eventsJoinLeaveToolStripMenuItem.Click += new System.EventHandler(this.eventsJoinLeaveToolStripMenuItem_Click);
            // 
            // eventsRateAnEventToolStripMenuItem
            // 
            this.eventsRateAnEventToolStripMenuItem.Name = "eventsRateAnEventToolStripMenuItem";
            this.eventsRateAnEventToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.eventsRateAnEventToolStripMenuItem.Text = "Events: Rate an event";
            this.eventsRateAnEventToolStripMenuItem.Click += new System.EventHandler(this.eventsRateAnEventToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // status_strip
            // 
            this.status_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_strip_label});
            this.status_strip.Location = new System.Drawing.Point(0, 553);
            this.status_strip.Name = "status_strip";
            this.status_strip.Size = new System.Drawing.Size(794, 22);
            this.status_strip.TabIndex = 1;
            this.status_strip.Text = "Status strip";
            // 
            // status_strip_label
            // 
            this.status_strip_label.Name = "status_strip_label";
            this.status_strip_label.Size = new System.Drawing.Size(66, 17);
            this.status_strip_label.Text = "Initializing...";
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverSetupIPToolStripMenuItem});
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.serverToolStripMenuItem.Text = "Server";
            // 
            // serverSetupIPToolStripMenuItem
            // 
            this.serverSetupIPToolStripMenuItem.Name = "serverSetupIPToolStripMenuItem";
            this.serverSetupIPToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.serverSetupIPToolStripMenuItem.Text = "Server: setup IP";
            this.serverSetupIPToolStripMenuItem.Click += new System.EventHandler(this.serverSetupIPToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(794, 575);
            this.Controls.Add(this.status_strip);
            this.Controls.Add(this.main_menu_strip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.main_menu_strip;
            this.Name = "MainForm";
            this.Text = "Events client";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.main_menu_strip.ResumeLayout(false);
            this.main_menu_strip.PerformLayout();
            this.status_strip.ResumeLayout(false);
            this.status_strip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip main_menu_strip;
        private System.Windows.Forms.ToolStripMenuItem accountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.StatusStrip status_strip;
        private System.Windows.Forms.ToolStripStatusLabel status_strip_label;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectedEventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventsByPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem eventsByCategoryAndTownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem eventsCreateAnEventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventsDeleteAnEventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventsJoinLeaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventsRateAnEventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverSetupIPToolStripMenuItem;
    }
}

