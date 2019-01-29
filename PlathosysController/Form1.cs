using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlathosysController
{
    public partial class Form1 : Form
    {
        // The path to the key where Windows looks for startup applications
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        public Form1()
        {
            // Prevent application from running twice
            Process[] result = Process.GetProcessesByName("PlathosysController");
            if (result.Length > 1)
            {
                MessageBox.Show("There is already an instance of \"PlathosysController\" running.", "Information");
                Environment.Exit(0);
            }

            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            InitializeComponent();

            LoadSettings();
        }

        private void LoadSettings()
        {
            notifyIconHeadset.Visible = Properties.Settings.Default.HeadsetIconVisible;
            notifyIconSpeaker.Visible = Properties.Settings.Default.SpeakerIconVisible;
            notifyIconTraining.Visible = Properties.Settings.Default.TrainingIconVisible;

            toolStripMenuItemHeadset.Checked = Properties.Settings.Default.HeadsetIconVisible;
            toolStripMenuItemSpeaker.Checked = Properties.Settings.Default.SpeakerIconVisible;
            toolStripMenuItemTraining.Checked = Properties.Settings.Default.TrainingIconVisible;

            // Check to see the current state (running at startup or not)
            if (rkApp.GetValue("PlathosysController") == null)
                toolStripMenuItemAutostart.Checked = false;
            else
                toolStripMenuItemAutostart.Checked = true;
        }

        private void toolStripMenuItemClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItemHeadset_Click(object sender, EventArgs e)
        {
            notifyIconHeadset.Visible = ((ToolStripMenuItem)sender).Checked;
            Properties.Settings.Default.HeadsetIconVisible = notifyIconHeadset.Visible;
            Properties.Settings.Default.Save();
        }

        private void toolStripMenuItemSpeaker_Click(object sender, EventArgs e)
        {
            notifyIconSpeaker.Visible = ((ToolStripMenuItem)sender).Checked;
            Properties.Settings.Default.SpeakerIconVisible = notifyIconSpeaker.Visible;
            Properties.Settings.Default.Save();
        }

        private void toolStripMenuItemTraining_Click(object sender, EventArgs e)
        {
            notifyIconTraining.Visible = ((ToolStripMenuItem)sender).Checked;
            Properties.Settings.Default.TrainingIconVisible = notifyIconTraining.Visible;
            Properties.Settings.Default.Save();
        }

        private void toolStripMenuItemAutostart_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Checked)
            {
                // Add the value in the registry so that the application runs at startup
                rkApp.SetValue("PlathosysController", Application.ExecutablePath);
            }
            else
            {
                // Remove the value from the registry so that the application doesn't start
                rkApp.DeleteValue("PlathosysController", false);
            }
        }

        private void notifyIconHeadset_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void notifyIconSpeaker_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void notifyIconTraining_MouseClick(object sender, MouseEventArgs e)
        {

        }

        /// <summary>
        /// Cleanup so that the icons will be removed when the application is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnApplicationExit(object sender, EventArgs e)
        {
            notifyIconHeadset.Dispose();
            notifyIconSpeaker.Dispose();
            notifyIconTraining.Dispose();
        }
    }
}
