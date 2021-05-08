namespace Shortcut_App
{
    partial class MainPage
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.TaskTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TaskTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editShortcutsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TaskTrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TaskTrayIcon
            // 
            this.TaskTrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TaskTrayIcon.BalloonTipText = "WOW";
            this.TaskTrayIcon.BalloonTipTitle = "LMAO";
            this.TaskTrayIcon.ContextMenuStrip = this.TaskTrayMenu;
            this.TaskTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TaskTrayIcon.Icon")));
            this.TaskTrayIcon.Text = "Shortcut App";
            this.TaskTrayIcon.Visible = true;
            this.TaskTrayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TaskTrayIcon_MouseClick);
            this.TaskTrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TaskTrayIcon_MouseDoubleClick);
            // 
            // TaskTrayMenu
            // 
            this.TaskTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editShortcutsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.donateToolStripMenuItem,
            this.QuitMenuItem});
            this.TaskTrayMenu.Name = "TaskTrayMenu";
            this.TaskTrayMenu.Size = new System.Drawing.Size(148, 92);
            // 
            // editShortcutsToolStripMenuItem
            // 
            this.editShortcutsToolStripMenuItem.Name = "editShortcutsToolStripMenuItem";
            this.editShortcutsToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.editShortcutsToolStripMenuItem.Text = "Edit Shortcuts";
            this.editShortcutsToolStripMenuItem.Click += new System.EventHandler(this.editShortcutsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.donateToolStripMenuItem.Text = "Donate";
            this.donateToolStripMenuItem.Click += new System.EventHandler(this.donateToolStripMenuItem_Click);
            // 
            // QuitMenuItem
            // 
            this.QuitMenuItem.Name = "QuitMenuItem";
            this.QuitMenuItem.Size = new System.Drawing.Size(147, 22);
            this.QuitMenuItem.Text = "Quit";
            this.QuitMenuItem.Click += new System.EventHandler(this.QuitMenuItem_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1, 1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "MainPage";
            this.ShowInTaskbar = false;
            this.Text = "Press Key!";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainPage_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainPage_KeyDown);
            this.TaskTrayMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon TaskTrayIcon;
        private System.Windows.Forms.ContextMenuStrip TaskTrayMenu;
        private System.Windows.Forms.ToolStripMenuItem QuitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editShortcutsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem donateToolStripMenuItem;
    }
}

