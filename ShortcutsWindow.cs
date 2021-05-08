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
    public partial class ShortcutsWindow : Form
    {
        public List<ShortCut> ShortCutList = new List<ShortCut>();
        List<string> ShortcutCommandList = new List<string>();

        private ListViewColumnSorter lvwColumnSorter;

        public ShortcutsWindow()
        {
            InitializeComponent();
        }

        public void LoadShortCuts(List<ShortCut> inlist)
        {
            ShortCutList = inlist;
            lvwColumnSorter = new ListViewColumnSorter();
            ShortCutListView.ListViewItemSorter = lvwColumnSorter;
            RefreshShortCutList();
        }

        private void RefreshShortCutList()
        {
            ShortCutListView.Items.Clear();

            foreach (ShortCut shortcut in ShortCutList)
            {
                string[] scdisplay = new string[3];
                scdisplay[0] = shortcut.Name;
                if (shortcut.Augument == Keys.None) scdisplay[1] = shortcut.Key.ToString();
                else scdisplay[1] = shortcut.Augument.ToString() + " + " + shortcut.Key.ToString();
                scdisplay[2] = shortcut.Command;
                ListViewItem item = new ListViewItem(scdisplay);
                ShortCutListView.Items.Add(item);
            }
        }

        private void NewShortcutButton_Click(object sender, EventArgs e)
        {
            EditShortcutWindow escwindow = new EditShortcutWindow();

            if (escwindow.ShowDialog() == DialogResult.OK)
            {
                ShortCut newboi = escwindow.CurrentShortCut;
                bool duplicate = false;
                foreach (ShortCut shortcut in ShortCutList)
                {
                    if (shortcut.Augument == newboi.Augument && shortcut.Key == newboi.Key)
                    {
                        MessageBox.Show("The specified key combo leads already to something else!");
                        duplicate = true;
                        break;
                    }
                }
                if (!duplicate) ShortCutList.Add(newboi);
                RefreshShortCutList();
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            EditShortCut();
        }

        private void EditShortCut()
        {
            if (ShortCutListView.SelectedItems.Count == 0) return;
            EditShortcutWindow escwindow = new EditShortcutWindow(ShortCutList.FirstOrDefault(sc => sc.Name == (string)ShortCutListView.SelectedItems[0].SubItems[0].Text));
            if (escwindow.ShowDialog() == DialogResult.OK)
            {
                RefreshShortCutList();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (ShortCutListView.SelectedItems.Count == 0) return;
            ShortCutList.Remove(ShortCutList.FirstOrDefault(sc => sc.Name == (string)ShortCutListView.SelectedItems[0].SubItems[0].Text));
            ShortcutCommandList.Remove(ShortcutCommandList.FirstOrDefault(sc => sc == (string)ShortCutListView.SelectedItems[0].SubItems[0].Text));
            RefreshShortCutList();
        }

        private void ShortCutListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.ShortCutListView.Sort();
        }

        private void ShortCutListView_DoubleClick(object sender, EventArgs e)
        {
            EditShortCut();
        }
    }
}
