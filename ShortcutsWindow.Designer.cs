namespace Shortcut_App
{
    partial class ShortcutsWindow
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.NewShortcutButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.ShortCutListView = new System.Windows.Forms.ListView();
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.KeysColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CommandColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.Controls.Add(this.NewShortcutButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.DeleteButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.EditButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.OKButton, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.ShortCutListView, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(738, 262);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // NewShortcutButton
            // 
            this.NewShortcutButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NewShortcutButton.Location = new System.Drawing.Point(633, 6);
            this.NewShortcutButton.Name = "NewShortcutButton";
            this.NewShortcutButton.Size = new System.Drawing.Size(100, 23);
            this.NewShortcutButton.TabIndex = 0;
            this.NewShortcutButton.Text = "New Shortcut";
            this.NewShortcutButton.UseVisualStyleBackColor = true;
            this.NewShortcutButton.Click += new System.EventHandler(this.NewShortcutButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DeleteButton.Location = new System.Drawing.Point(633, 41);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(100, 23);
            this.DeleteButton.TabIndex = 1;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EditButton.Location = new System.Drawing.Point(633, 76);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(100, 23);
            this.EditButton.TabIndex = 3;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OKButton.Location = new System.Drawing.Point(633, 233);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(100, 23);
            this.OKButton.TabIndex = 4;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // ShortCutListView
            // 
            this.ShortCutListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameColumn,
            this.KeysColumn,
            this.CommandColumn});
            this.ShortCutListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShortCutListView.FullRowSelect = true;
            this.ShortCutListView.GridLines = true;
            this.ShortCutListView.HideSelection = false;
            this.ShortCutListView.Location = new System.Drawing.Point(3, 3);
            this.ShortCutListView.MultiSelect = false;
            this.ShortCutListView.Name = "ShortCutListView";
            this.tableLayoutPanel1.SetRowSpan(this.ShortCutListView, 5);
            this.ShortCutListView.Size = new System.Drawing.Size(622, 256);
            this.ShortCutListView.TabIndex = 5;
            this.ShortCutListView.UseCompatibleStateImageBehavior = false;
            this.ShortCutListView.View = System.Windows.Forms.View.Details;
            this.ShortCutListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ShortCutListView_ColumnClick);
            this.ShortCutListView.DoubleClick += new System.EventHandler(this.ShortCutListView_DoubleClick);
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Name";
            this.NameColumn.Width = 150;
            // 
            // KeysColumn
            // 
            this.KeysColumn.Text = "Key";
            this.KeysColumn.Width = 150;
            // 
            // CommandColumn
            // 
            this.CommandColumn.Text = "Command";
            this.CommandColumn.Width = 300;
            // 
            // ShortcutsWindow
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 262);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ShortcutsWindow";
            this.Text = "Shortcuts";
            this.TopMost = true;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button NewShortcutButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.ListView ShortCutListView;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader KeysColumn;
        private System.Windows.Forms.ColumnHeader CommandColumn;
    }
}