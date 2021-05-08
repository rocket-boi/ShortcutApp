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
    public partial class QueryEntryForm : Form
    {

        public string aug;

        public QueryEntryForm()
        {
            InitializeComponent();
        }

        public void SetLabel(string querylabel)
        {
            QueryLabel.Text = querylabel;
        }

        public void ClearTextbox()
        {
            QueryTextBox.Text = "";
        }

        private void QueryTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                aug = "";
                DialogResult = DialogResult.Cancel;
                Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                aug = QueryTextBox.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
