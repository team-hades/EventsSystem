﻿namespace EventsSystem.WindowsFormsClient
{
    using System;
    using System.Windows.Forms;

    static class Startup
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}