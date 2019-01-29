namespace PlathosysController
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIconHeadset = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemAppName = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHeadset = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSpeaker = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTraining = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemAutostart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIconSpeaker = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconTraining = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIconHeadset
            // 
            this.notifyIconHeadset.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIconHeadset.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconHeadset.Icon")));
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
            this.notifyIconSpeaker.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconSpeaker.Icon")));
            this.notifyIconSpeaker.Text = "Speaker";
            this.notifyIconSpeaker.Visible = true;
            this.notifyIconSpeaker.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconSpeaker_MouseClick);
            // 
            // notifyIconTraining
            // 
            this.notifyIconTraining.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIconTraining.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconTraining.Icon")));
            this.notifyIconTraining.Text = "Training";
            this.notifyIconTraining.Visible = true;
            this.notifyIconTraining.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconTraining_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIconHeadset;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.NotifyIcon notifyIconSpeaker;
        private System.Windows.Forms.NotifyIcon notifyIconTraining;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAppName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClose;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOptions;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHeadset;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSpeaker;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTraining;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAutostart;
    }
}

