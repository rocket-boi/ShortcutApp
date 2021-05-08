using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace Shortcut_App
{
    public partial class MainPage : Form
    {
        List<ShortCut> Shortcuts = new List<ShortCut>();
        ToolTip ShortcutToolTip = new ToolTip();
        private GlobalHotkey ghk;
        CommandListWindow clw = new CommandListWindow();
        ShortcutsWindow scwindow = new ShortcutsWindow();
        QueryEntryForm qef = new QueryEntryForm();

        public MainPage()
        {
            Initialize();
        }

        private void Initialize()
        {
            InitializeComponent();
            WindowState = FormWindowState.Minimized;
            Size = new Size(0, 0);
            MaximumSize = new Size(0, 0);
            FormBorderStyle = FormBorderStyle.None;
            if (!UFunc.FileOrDirectoryExists(Global.BaseDirectory)) Directory.CreateDirectory(Global.BaseDirectory);
            LoadShortcuts();

            ghk = new GlobalHotkey(HKConstants.CTRL + HKConstants.ALT, Keys.Space, this);
            if (!ghk.Register()) MessageBox.Show("Failed to register hotkey.");

            Hide();
        }

        private void LoadShortcuts()
        {
            if (UFunc.FileOrDirectoryExists(Path.Combine(Global.BaseDirectory, "Shortcuts.nya"))) Shortcuts = SerializeFunctions.Deserialize<List<ShortCut>>(File.ReadAllText(Path.Combine(Global.BaseDirectory, "Shortcuts.nya")));
            Shortcuts = Shortcuts.OrderBy(x => x.Name).ToList();

        }

        protected override void WndProc(ref Message m)
        {
            if (qef.Visible) return;
            if (m.Msg == HKConstants.WM_HOTKEY_MSG_ID) HandleHotKey();
            base.WndProc(ref m);
        }

        private void HandleHotKey()
        {
            WindowState = FormWindowState.Minimized;
            ShowHelper();
            Show();
            Activate();
        }

        private void ShowHelper()
        {
            string helpertext = "";

            foreach (ShortCut shortcut in Shortcuts)
            {
                string line = string.Format("{0,0}:    {1,0} + {2,0}", shortcut.Name, shortcut.Augument.ToString(), shortcut.Key.ToString());
                if (shortcut.Augument.ToString() == "None")
                    line = string.Format("{0,0}:    {1,0}", shortcut.Name, shortcut.Key.ToString());
                helpertext = helpertext + line + "\n";
            }
            clw.SetText(helpertext);
            clw.Show();
        }
                
        private void MainPage_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (ShortCut shortcut in Shortcuts)
            {
                if (e.Modifiers == shortcut.Augument)
                {
                    if (e.KeyCode == shortcut.Key)
                    {
                        string usecommand = "";
                        if (shortcut.Command.Contains("|"))
                        {
                            qef.SetLabel(shortcut.Name);
                            qef.ClearTextbox();
                            if (qef.ShowDialog() == DialogResult.OK)
                                usecommand = shortcut.Command.Replace("|", qef.aug);
                        }
                        else usecommand = shortcut.Command;
                        UFunc.OpenSomething(usecommand);
                        Hide();
                        break;
                    }
                }
            }
            clw.Hide();
        }

        private void MainPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            ghk.Unregister();
        }

        private void waboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("When life gives you lemons\r\n" +
                "throw that shit in the trash and go buy lemonade\r\n" +
                "                                 -YUOM ~2018");
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("@2018-2021 Manaslu Apps. All rights reserved.");
        }

        private void QuitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UFunc.OpenSomething("https://www.paypal.com/donate?business=manasluapps%40gmail.com&currency_code=USD");
        }

        private void editShortcutsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenShortcutEditor();
        }

        private void TaskTrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenShortcutEditor();
        }

        private void OpenShortcutEditor()
        {
            LoadShortcuts();
            scwindow.LoadShortCuts(Shortcuts);
            if (scwindow.Visible) return;
            if (scwindow.ShowDialog() == DialogResult.OK)
            {
                Shortcuts = scwindow.ShortCutList;
                if (!UFunc.FileOrDirectoryExists(Path.Combine(Global.BaseDirectory, "Shortcuts.nya")))
                {
                    if (!UFunc.FileOrDirectoryExists(Global.BaseDirectory)) Directory.CreateDirectory(Global.BaseDirectory);
                }

                File.WriteAllText(Path.Combine(Global.BaseDirectory, "Shortcuts.nya"), SerializeFunctions.Serialize(Shortcuts));
            }
        }

        private void TaskTrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) TaskTrayMenu.Show();
        }
    }
}
