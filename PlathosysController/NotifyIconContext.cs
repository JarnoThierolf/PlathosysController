using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace PlathosysController
{
    class NotifyIconContext : ApplicationContext
    {
        // State of accessories
        private bool _headsetActive = false;
        private bool _speakerActive = false;
        private bool _trainingActive = false;

        // The path to the key where Windows looks for startup applications
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        // Instances
        private PlathosysController _plathosysController;

        //Component declarations
        private NotifyIcon notifyIconHeadset;
        private ContextMenuStrip contextMenuStrip;
        private NotifyIcon notifyIconSpeaker;
        private NotifyIcon notifyIconTraining;
        private ToolStripMenuItem toolStripMenuItemAppName;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripMenuItem toolStripMenuItemClose;
        private ToolStripMenuItem toolStripMenuItemOptions;
        private ToolStripMenuItem toolStripMenuItemHeadset;
        private ToolStripMenuItem toolStripMenuItemSpeaker;
        private ToolStripMenuItem toolStripMenuItemTraining;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItemAutostart;

        public NotifyIconContext()
        {
            // Prevent application from running twice
            Process[] result = Process.GetProcessesByName("PlathosysController");
            if (result.Length > 1)
            {
                MessageBox.Show("There is already an instance of \"PlathosysController\" running.", "Information");
                Environment.Exit(0);
            }

            _plathosysController = new PlathosysController(this);
            _plathosysController.HookChanged += OnHookChanged;
            _plathosysController.PlathosysDeviceReady += OnPlathosysDeviceReady;
            _plathosysController.NoDeviceFound += OnNoDeviceFound;

            Application.ApplicationExit += new EventHandler(OnApplicationExit);

            InitializeComponent();
            LoadSettings();
        }

        /// <summary>
        /// Load settings and set checkboxes and icon visibility
        /// </summary>
        private void LoadSettings()
        {
            // Show / hide icons
            notifyIconHeadset.Visible = Properties.Settings.Default.HeadsetIconVisible;
            notifyIconSpeaker.Visible = Properties.Settings.Default.SpeakerIconVisible;
            notifyIconTraining.Visible = Properties.Settings.Default.TrainingIconVisible;

            // Set checkbox in menu
            toolStripMenuItemHeadset.Checked = Properties.Settings.Default.HeadsetIconVisible;
            toolStripMenuItemSpeaker.Checked = Properties.Settings.Default.SpeakerIconVisible;
            toolStripMenuItemTraining.Checked = Properties.Settings.Default.TrainingIconVisible;

            // Set "Start with Windows" checkbox according to registry
            if (rkApp.GetValue("PlathosysController") == null)
                toolStripMenuItemAutostart.Checked = false;
            else
                toolStripMenuItemAutostart.Checked = true;
        }

        /// <summary>
        /// If hook status changes, change symbol to speakerOff
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnHookChanged(object sender, HookEventArgs e)
        {
            notifyIconSpeaker.Icon = Properties.Resources.speakerOff;
            _speakerActive = false;
        }

        /// <summary>
        /// Setup the NotifyIcons
        /// </summary>
        private void InitializeComponent()
        {
            //
            // create instances
            //
            notifyIconHeadset = new NotifyIcon();
            contextMenuStrip = new ContextMenuStrip();
            toolStripMenuItemAppName = new ToolStripMenuItem();
            toolStripMenuItemOptions = new ToolStripMenuItem();
            toolStripMenuItemHeadset = new ToolStripMenuItem();
            toolStripMenuItemSpeaker = new ToolStripMenuItem();
            toolStripMenuItemTraining = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItemAutostart = new ToolStripMenuItem();
            toolStripSeparator = new ToolStripSeparator();
            toolStripMenuItemClose = new ToolStripMenuItem();
            notifyIconSpeaker = new NotifyIcon();
            notifyIconTraining = new NotifyIcon();
            contextMenuStrip.SuspendLayout();
            // 
            // notifyIconHeadset
            // 
            this.notifyIconHeadset.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIconHeadset.Icon = Properties.Resources.HP_ball;
            this.notifyIconHeadset.Text = "Headset";
            this.notifyIconHeadset.Visible = true;
            this.notifyIconHeadset.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconHeadset_MouseClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAppName,
            this.toolStripMenuItemOptions,
            this.toolStripSeparator,
            this.toolStripMenuItemClose});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.ShowImageMargin = false;
            this.contextMenuStrip.Size = new System.Drawing.Size(178, 98);
            // 
            // toolStripMenuItemAppName
            // 
            this.toolStripMenuItemAppName.Name = "toolStripMenuItemAppName";
            this.toolStripMenuItemAppName.Size = new System.Drawing.Size(177, 22);
            this.toolStripMenuItemAppName.Text = "PlathosysController V1.0";
            // 
            // toolStripMenuItemOptions
            // 
            this.toolStripMenuItemOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemHeadset,
            this.toolStripMenuItemSpeaker,
            this.toolStripMenuItemTraining,
            this.toolStripSeparator1,
            this.toolStripMenuItemAutostart});
            this.toolStripMenuItemOptions.Name = "toolStripMenuItemOptions";
            this.toolStripMenuItemOptions.Size = new System.Drawing.Size(177, 22);
            this.toolStripMenuItemOptions.Text = "Options";
            // 
            // toolStripMenuItemHeadset
            // 
            this.toolStripMenuItemHeadset.Checked = true;
            this.toolStripMenuItemHeadset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemHeadset.Name = "toolStripMenuItemHeadset";
            this.toolStripMenuItemHeadset.Size = new System.Drawing.Size(189, 22);
            this.toolStripMenuItemHeadset.Text = "Activate Headset Icon";
            this.toolStripMenuItemHeadset.Click += new System.EventHandler(this.toolStripMenuItemHeadset_Click);
            // 
            // toolStripMenuItemSpeaker
            // 
            this.toolStripMenuItemSpeaker.Checked = true;
            this.toolStripMenuItemSpeaker.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemSpeaker.Name = "toolStripMenuItemSpeaker";
            this.toolStripMenuItemSpeaker.Size = new System.Drawing.Size(189, 22);
            this.toolStripMenuItemSpeaker.Text = "Activate Speaker Icon";
            this.toolStripMenuItemSpeaker.Click += new System.EventHandler(this.toolStripMenuItemSpeaker_Click);
            // 
            // toolStripMenuItemTraining
            // 
            this.toolStripMenuItemTraining.Checked = true;
            this.toolStripMenuItemTraining.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemTraining.Name = "toolStripMenuItemTraining";
            this.toolStripMenuItemTraining.Size = new System.Drawing.Size(189, 22);
            this.toolStripMenuItemTraining.Text = "Activate Training Icon";
            this.toolStripMenuItemTraining.Click += new System.EventHandler(this.toolStripMenuItemTraining_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(186, 6);
            // 
            // toolStripMenuItemAutostart
            // 
            this.toolStripMenuItemAutostart.Checked = true;
            this.toolStripMenuItemAutostart.CheckOnClick = true;
            this.toolStripMenuItemAutostart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemAutostart.Name = "toolStripMenuItemAutostart";
            this.toolStripMenuItemAutostart.Size = new System.Drawing.Size(189, 22);
            this.toolStripMenuItemAutostart.Text = "Start with Windows";
            this.toolStripMenuItemAutostart.Click += new System.EventHandler(this.toolStripMenuItemAutostart_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(174, 6);
            // 
            // toolStripMenuItemClose
            // 
            this.toolStripMenuItemClose.Name = "toolStripMenuItemClose";
            this.toolStripMenuItemClose.Size = new System.Drawing.Size(177, 22);
            this.toolStripMenuItemClose.Text = "Quit Application";
            this.toolStripMenuItemClose.Click += new System.EventHandler(this.toolStripMenuItemClose_Click);
            // 
            // notifyIconSpeaker
            // 
            this.notifyIconSpeaker.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIconSpeaker.Icon = Properties.Resources.HP_ball;
            this.notifyIconSpeaker.Text = "Speaker";
            this.notifyIconSpeaker.Visible = true;
            this.notifyIconSpeaker.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconSpeaker_MouseClick);
            // 
            // notifyIconTraining
            // 
            this.notifyIconTraining.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIconTraining.Icon = Properties.Resources.HP_ball;
            this.notifyIconTraining.Text = "Training";
            this.notifyIconTraining.Visible = true;
            this.notifyIconTraining.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconTraining_MouseClick);
            // 
            this.contextMenuStrip.ResumeLayout(false);
        }

        /// <summary>
        /// Reset all NotifyIcons to HP_ball and set accessoires not active, if no device is found
        /// </summary>
        public void OnNoDeviceFound(object sender, EventArgs e)
        {
            notifyIconHeadset.Icon = Properties.Resources.HP_ball;
            notifyIconSpeaker.Icon = Properties.Resources.HP_ball;
            notifyIconTraining.Icon = Properties.Resources.HP_ball;

            _headsetActive = false;
            _speakerActive = false;
            _trainingActive = false;
        }

        /// <summary>
        /// Set all NotifyIcons to their off symbols when Plathosys device is ready
        /// </summary>
        public void OnPlathosysDeviceReady(object sender, EventArgs e)
        {
            notifyIconHeadset.Icon = Properties.Resources.headsetOff;
            notifyIconSpeaker.Icon = Properties.Resources.speakerOff;
            notifyIconTraining.Icon = Properties.Resources.headsetEarOff;
        }

        /// <summary>
        /// Close Application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Show / hide headset icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemHeadset_Click(object sender, EventArgs e)
        {
            // Prevent of closing all icons, so that the app couldn't be controlled
            if (!toolStripMenuItemSpeaker.Checked && !toolStripMenuItemTraining.Checked)
                return;

            ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;
            notifyIconHeadset.Visible = ((ToolStripMenuItem)sender).Checked;
            Properties.Settings.Default.HeadsetIconVisible = notifyIconHeadset.Visible;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Show / hide speaker icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemSpeaker_Click(object sender, EventArgs e)
        {
            // Prevent of closing all icons, so that the app couldn't be controlled
            if (!toolStripMenuItemHeadset.Checked && !toolStripMenuItemTraining.Checked)
                return;

            ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;
            notifyIconSpeaker.Visible = ((ToolStripMenuItem)sender).Checked;
            Properties.Settings.Default.SpeakerIconVisible = notifyIconSpeaker.Visible;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Show / hide training icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemTraining_Click(object sender, EventArgs e)
        {
            // Prevent of closing all icons, so that the app couldn't be controlled
            if (!toolStripMenuItemHeadset.Checked && !toolStripMenuItemSpeaker.Checked)
                return;

            ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;
            notifyIconTraining.Visible = ((ToolStripMenuItem)sender).Checked;
            Properties.Settings.Default.TrainingIconVisible = notifyIconTraining.Visible;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Acivate or deactivate autostart of this application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Toggle headset state and change NotifyIcon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIconHeadset_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    if (_headsetActive)
                    {
                        _plathosysController.SetHeadset(false);
                        notifyIconHeadset.Icon = Properties.Resources.headsetOff;
                        _headsetActive = false;
                    }
                    else
                    {
                        notifyIconTraining.Icon = Properties.Resources.headsetEarOff;
                        _trainingActive = false;
                        _plathosysController.SetHeadset(true);
                        notifyIconHeadset.Icon = Properties.Resources.headsetOn;
                        _headsetActive = true;
                    }
                }
                catch (Exception ex)
                {
                    _headsetActive = false;
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Toggle speaker state and change NotifyIcon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIconSpeaker_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    if (_speakerActive)
                    {
                        _plathosysController.SetSpeaker(false);
                        notifyIconSpeaker.Icon = Properties.Resources.speakerOff;
                        _speakerActive = false;
                    }
                    else
                    {
                        _plathosysController.SetSpeaker(true);
                        notifyIconSpeaker.Icon = Properties.Resources.speakerOn;
                        _speakerActive = true;
                    }
                }
                catch (Exception ex)
                {
                    _speakerActive = false;
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Toggle training state and change NotifyIcon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIconTraining_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    if (_trainingActive)
                    {
                        _plathosysController.SetTraining(false);
                        notifyIconTraining.Icon = Properties.Resources.headsetEarOff;
                        _trainingActive = false;
                    }
                    else
                    {
                        notifyIconHeadset.Icon = Properties.Resources.headsetOff;
                        _headsetActive = false;
                        _plathosysController.SetTraining(true);
                        notifyIconTraining.Icon = Properties.Resources.headsetEarOn;
                        _trainingActive = true;
                    }
                }
                catch (Exception ex)
                {
                    _trainingActive = false;
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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