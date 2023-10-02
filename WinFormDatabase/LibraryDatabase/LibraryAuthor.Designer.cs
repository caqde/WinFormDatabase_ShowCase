namespace WinForm_Database.LibraryDatabase
{
    partial class LibraryAuthor
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
            components = new System.ComponentModel.Container();
            AuthorListBox = new ListBox();
            authorListBindingSource = new BindingSource(components);
            libraryAuthorViewModelBindingSource = new BindingSource(components);
            AuthorsBookList = new ListBox();
            authorBookListBindingSource = new BindingSource(components);
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            AuthorName = new TextBox();
            AuthorBiography = new RichTextBox();
            AddAuthor = new Button();
            GetAuthor = new Button();
            UpdateAuthor = new Button();
            RemoveAuthor = new Button();
            statusStrip1 = new StatusStrip();
            AuthorStatus = new ToolStripStatusLabel();
            NewAuthor = new Button();
            ((System.ComponentModel.ISupportInitialize)authorListBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)libraryAuthorViewModelBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)authorBookListBindingSource).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // AuthorListBox
            // 
            AuthorListBox.DataSource = authorListBindingSource;
            AuthorListBox.DisplayMember = "Name";
            AuthorListBox.FormattingEnabled = true;
            AuthorListBox.ItemHeight = 15;
            AuthorListBox.Location = new Point(12, 31);
            AuthorListBox.Name = "AuthorListBox";
            AuthorListBox.Size = new Size(237, 349);
            AuthorListBox.TabIndex = 0;
            AuthorListBox.ValueMember = "Id";
            AuthorListBox.SelectedIndexChanged += AuthorListBox_SelectedIndexChanged;
            // 
            // authorListBindingSource
            // 
            authorListBindingSource.DataMember = "AuthorList";
            authorListBindingSource.DataSource = libraryAuthorViewModelBindingSource;
            // 
            // libraryAuthorViewModelBindingSource
            // 
            libraryAuthorViewModelBindingSource.DataSource = typeof(ShowCaseViewModel.Library.LibraryAuthorViewModel);
            // 
            // AuthorsBookList
            // 
            AuthorsBookList.DataSource = authorBookListBindingSource;
            AuthorsBookList.DisplayMember = "Title";
            AuthorsBookList.FormattingEnabled = true;
            AuthorsBookList.ItemHeight = 15;
            AuthorsBookList.Location = new Point(601, 31);
            AuthorsBookList.Name = "AuthorsBookList";
            AuthorsBookList.Size = new Size(187, 199);
            AuthorsBookList.TabIndex = 1;
            // 
            // authorBookListBindingSource
            // 
            authorBookListBindingSource.DataMember = "AuthorBookList";
            authorBookListBindingSource.DataSource = libraryAuthorViewModelBindingSource;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(86, 9);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 2;
            label1.Text = "Authors";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(667, 9);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 3;
            label2.Text = "Book List";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(274, 31);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 4;
            label3.Text = "Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(318, 114);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 5;
            label4.Text = "Biography";
            // 
            // AuthorName
            // 
            AuthorName.DataBindings.Add(new Binding("Text", libraryAuthorViewModelBindingSource, "AuthorName", true));
            AuthorName.DataBindings.Add(new Binding("DataContext", libraryAuthorViewModelBindingSource, "AuthorName", true));
            AuthorName.Location = new Point(318, 28);
            AuthorName.Name = "AuthorName";
            AuthorName.Size = new Size(258, 23);
            AuthorName.TabIndex = 6;
            // 
            // AuthorBiography
            // 
            AuthorBiography.DataBindings.Add(new Binding("Text", libraryAuthorViewModelBindingSource, "AuthorBiography", true));
            AuthorBiography.DataBindings.Add(new Binding("DataContext", libraryAuthorViewModelBindingSource, "AuthorBiography", true));
            AuthorBiography.Location = new Point(318, 132);
            AuthorBiography.Name = "AuthorBiography";
            AuthorBiography.Size = new Size(258, 219);
            AuthorBiography.TabIndex = 7;
            AuthorBiography.Text = "";
            // 
            // AddAuthor
            // 
            AddAuthor.DataBindings.Add(new Binding("Command", libraryAuthorViewModelBindingSource, "addAuthorCommand", true));
            AddAuthor.Location = new Point(318, 357);
            AddAuthor.Name = "AddAuthor";
            AddAuthor.Size = new Size(75, 23);
            AddAuthor.TabIndex = 8;
            AddAuthor.Text = "Add";
            AddAuthor.UseVisualStyleBackColor = true;
            // 
            // GetAuthor
            // 
            GetAuthor.DataBindings.Add(new Binding("Command", libraryAuthorViewModelBindingSource, "getAuthorCommand", true));
            GetAuthor.Location = new Point(93, 386);
            GetAuthor.Name = "GetAuthor";
            GetAuthor.Size = new Size(75, 23);
            GetAuthor.TabIndex = 9;
            GetAuthor.Text = "Get";
            GetAuthor.UseVisualStyleBackColor = true;
            // 
            // UpdateAuthor
            // 
            UpdateAuthor.DataBindings.Add(new Binding("Command", libraryAuthorViewModelBindingSource, "updateAuthorCommand", true));
            UpdateAuthor.Location = new Point(399, 357);
            UpdateAuthor.Name = "UpdateAuthor";
            UpdateAuthor.Size = new Size(75, 23);
            UpdateAuthor.TabIndex = 10;
            UpdateAuthor.Text = "Update";
            UpdateAuthor.UseVisualStyleBackColor = true;
            // 
            // RemoveAuthor
            // 
            RemoveAuthor.DataBindings.Add(new Binding("Command", libraryAuthorViewModelBindingSource, "removeAuthorCommand", true));
            RemoveAuthor.Location = new Point(174, 386);
            RemoveAuthor.Name = "RemoveAuthor";
            RemoveAuthor.Size = new Size(75, 23);
            RemoveAuthor.TabIndex = 11;
            RemoveAuthor.Text = "Remove";
            RemoveAuthor.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { AuthorStatus });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 12;
            statusStrip1.Text = "statusStrip1";
            // 
            // AuthorStatus
            // 
            AuthorStatus.Name = "AuthorStatus";
            AuthorStatus.Size = new Size(0, 17);
            // 
            // NewAuthor
            // 
            NewAuthor.Location = new Point(12, 386);
            NewAuthor.Name = "NewAuthor";
            NewAuthor.Size = new Size(75, 23);
            NewAuthor.TabIndex = 13;
            NewAuthor.Text = "New";
            NewAuthor.UseVisualStyleBackColor = true;
            NewAuthor.Click += NewAuthor_Click;
            // 
            // LibraryAuthor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(NewAuthor);
            Controls.Add(statusStrip1);
            Controls.Add(RemoveAuthor);
            Controls.Add(UpdateAuthor);
            Controls.Add(GetAuthor);
            Controls.Add(AddAuthor);
            Controls.Add(AuthorBiography);
            Controls.Add(AuthorName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(AuthorsBookList);
            Controls.Add(AuthorListBox);
            Name = "LibraryAuthor";
            Text = "LibraryAuthor";
            ((System.ComponentModel.ISupportInitialize)authorListBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)libraryAuthorViewModelBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)authorBookListBindingSource).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox AuthorListBox;
        private BindingSource authorListBindingSource;
        private BindingSource libraryAuthorViewModelBindingSource;
        private ListBox AuthorsBookList;
        private BindingSource authorBookListBindingSource;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox AuthorName;
        private RichTextBox AuthorBiography;
        private Button AddAuthor;
        private Button GetAuthor;
        private Button UpdateAuthor;
        private Button RemoveAuthor;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel AuthorStatus;
        private Button NewAuthor;
    }
}