using System;
using System.Linq;
using System.Windows.Forms;

namespace Shortcut_App
{
    public partial class EditShortcutWindow : Form
    {
        public ShortCut CurrentShortCut = new ShortCut();
        private Keys tempkey = new Keys();
        private Keys tempmod = new Keys();
        Keys[] ForbiddenKeyList = { Keys.ControlKey, Keys.Control, Keys.LControlKey, Keys.RControlKey, Keys.Menu, Keys.RMenu, Keys.LMenu, Keys.Shift, Keys.ShiftKey, Keys.LShiftKey, Keys.RShiftKey };

        public EditShortcutWindow()
        {
            InitializeComponent();
        }

        public EditShortcutWindow(ShortCut sc)
        {
            InitializeComponent();
            CurrentShortCut = sc;

            NameTextBox.Text = sc.Name;
            CommandTextBox.Text = sc.Command;
            tempkey = sc.Key;
            tempmod = sc.Augument;
            DisplayKeys();
        }

        private void DisplayKeys()
        {
            if (tempmod == Keys.None) KeyTextBox.Text = tempkey.ToString();
            else if (ForbiddenKeyList.Contains(tempkey)) KeyTextBox.Text = tempmod.ToString() + " + ";
            else KeyTextBox.Text = tempmod.ToString() + " + " + tempkey.ToString();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            bool NoClose = false;
            //check this shit
            if (NameTextBox.Text == "")
            {
                MessageBox.Show("Enter a name for this shortcut.");
                NoClose = true;
            }
            else if (CommandTextBox.Text == "")
            {
                MessageBox.Show("Enter a command for this shortcut.");
                NoClose = true;
            }
            else if (ForbiddenKeyList.Contains(tempkey) | tempkey == Keys.None)
            {
                MessageBox.Show("Enter a key for this shortcut.");
                NoClose = true;
            }

            if (NoClose) return;

            else
            {
                CurrentShortCut.Name = NameTextBox.Text;
                CurrentShortCut.Command = CommandTextBox.Text;
                CurrentShortCut.Key = tempkey;

                CurrentShortCut.Augument = tempmod;

                DialogResult = DialogResult.OK;

                Close();
            }
        }

        private void KeyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            tempkey = e.KeyCode;
            tempmod = e.Modifiers;
            DisplayKeys();
            e.SuppressKeyPress = true;
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (OpenFileDialogBoi.ShowDialog() == DialogResult.OK)
            {
                if(OpenFileDialogBoi.SafeFileName == "-Folder Selection-")
                    CommandTextBox.Text = OpenFileDialogBoi.FileName.Substring(0, OpenFileDialogBoi.FileName.LastIndexOf("-Folder Selection-"));
                else CommandTextBox.Text = OpenFileDialogBoi.FileName;
            }
        }
    }
}
