using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shortcut_App
{
    public partial class CommandListWindow : Form
    {
        public CommandListWindow()
        {
            InitializeComponent();
        }

        public void SetText(string listwindowtext)
        {
            listtext.Text = listwindowtext;
        }


        private void CommandListWindow_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
