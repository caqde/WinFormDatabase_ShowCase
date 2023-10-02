namespace WinForm_Database.LibraryDatabase
{
    partial class LibraryBooks
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
            BookList = new ListBox();
            booksBindingSource = new BindingSource(components);
            libraryBookViewModelBindingSource = new BindingSource(components);
            PublisherSelection = new ComboBox();
            publishersBindingSource = new BindingSource(components);
            AuthorSelection = new ComboBox();
            authorsBindingSource = new BindingSource(components);
            BookISBN = new TextBox();
            textBox2 = new TextBox();
            BookDescription = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            BookBorrowed = new CheckBox();
            GetBook = new Button();
            AddBook = new Button();
            UpdateBook = new Button();
            RemoveBook = new Button();
            statusStrip1 = new StatusStrip();
            BookStatus = new ToolStripStatusLabel();
            NewBook = new Button();
            ((System.ComponentModel.ISupportInitialize)booksBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)libraryBookViewModelBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)publishersBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)authorsBindingSource).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // BookList
            // 
            BookList.DataSource = booksBindingSource;
            BookList.DisplayMember = "Title";
            BookList.FormattingEnabled = true;
            BookList.ItemHeight = 15;
            BookList.Location = new Point(12, 35);
            BookList.Name = "BookList";
            BookList.Size = new Size(237, 334);
            BookList.TabIndex = 0;
            BookList.SelectedIndexChanged += BookList_SelectedIndexChanged;
            // 
            // booksBindingSource
            // 
            booksBindingSource.DataMember = "Books";
            booksBindingSource.DataSource = libraryBookViewModelBindingSource;
            // 
            // libraryBookViewModelBindingSource
            // 
            libraryBookViewModelBindingSource.DataSource = typeof(ShowCaseViewModel.Library.LibraryBookViewModel);
            // 
            // PublisherSelection
            // 
            PublisherSelection.DataSource = publishersBindingSource;
            PublisherSelection.DisplayMember = "Name";
            PublisherSelection.FormattingEnabled = true;
            PublisherSelection.Location = new Point(364, 122);
            PublisherSelection.Name = "PublisherSelection";
            PublisherSelection.Size = new Size(182, 23);
            PublisherSelection.TabIndex = 1;
            PublisherSelection.ValueMember = "Id";
            PublisherSelection.SelectedIndexChanged += PublisherSelection_SelectedIndexChanged;
            // 
            // publishersBindingSource
            // 
            publishersBindingSource.DataMember = "Publishers";
            publishersBindingSource.DataSource = libraryBookViewModelBindingSource;
            // 
            // AuthorSelection
            // 
            AuthorSelection.DataSource = authorsBindingSource;
            AuthorSelection.DisplayMember = "Name";
            AuthorSelection.FormattingEnabled = true;
            AuthorSelection.Location = new Point(364, 93);
            AuthorSelection.Name = "AuthorSelection";
            AuthorSelection.Size = new Size(182, 23);
            AuthorSelection.TabIndex = 2;
            AuthorSelection.ValueMember = "Id";
            AuthorSelection.SelectedIndexChanged += AuthorSelection_SelectedIndexChanged;
            // 
            // authorsBindingSource
            // 
            authorsBindingSource.DataMember = "Authors";
            authorsBindingSource.DataSource = libraryBookViewModelBindingSource;
            // 
            // BookISBN
            // 
            BookISBN.DataBindings.Add(new Binding("Text", libraryBookViewModelBindingSource, "ISBN", true));
            BookISBN.Location = new Point(364, 64);
            BookISBN.Name = "BookISBN";
            BookISBN.Size = new Size(182, 23);
            BookISBN.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.DataBindings.Add(new Binding("Text", libraryBookViewModelBindingSource, "Title", true));
            textBox2.Location = new Point(364, 35);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(182, 23);
            textBox2.TabIndex = 4;
            // 
            // BookDescription
            // 
            BookDescription.DataBindings.Add(new Binding("Text", libraryBookViewModelBindingSource, "Description", true));
            BookDescription.Location = new Point(266, 181);
            BookDescription.Name = "BookDescription";
            BookDescription.Size = new Size(280, 188);
            BookDescription.TabIndex = 5;
            BookDescription.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(269, 155);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 6;
            label1.Text = "Description";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(304, 43);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 7;
            label2.Text = "Title";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(304, 72);
            label3.Name = "label3";
            label3.Size = new Size(32, 15);
            label3.TabIndex = 8;
            label3.Text = "ISBN";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(304, 101);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 9;
            label4.Text = "Author";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(304, 125);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 10;
            label5.Text = "Publisher";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(81, 9);
            label6.Name = "label6";
            label6.Size = new Size(52, 15);
            label6.TabIndex = 11;
            label6.Text = "BookList";
            // 
            // BookBorrowed
            // 
            BookBorrowed.AutoCheck = false;
            BookBorrowed.AutoSize = true;
            BookBorrowed.CheckAlign = ContentAlignment.MiddleRight;
            BookBorrowed.DataBindings.Add(new Binding("Checked", libraryBookViewModelBindingSource, "BorrowedID", true));
            BookBorrowed.Location = new Point(464, 151);
            BookBorrowed.Name = "BookBorrowed";
            BookBorrowed.Size = new Size(84, 19);
            BookBorrowed.TabIndex = 12;
            BookBorrowed.Text = "IsBorrowed";
            BookBorrowed.UseVisualStyleBackColor = true;
            // 
            // GetBook
            // 
            GetBook.DataBindings.Add(new Binding("Command", libraryBookViewModelBindingSource, "getBookCommand", true));
            GetBook.Location = new Point(93, 375);
            GetBook.Name = "GetBook";
            GetBook.Size = new Size(75, 23);
            GetBook.TabIndex = 13;
            GetBook.Text = "Get";
            GetBook.UseVisualStyleBackColor = true;
            // 
            // AddBook
            // 
            AddBook.DataBindings.Add(new Binding("Command", libraryBookViewModelBindingSource, "addBookCommand", true));
            AddBook.Location = new Point(269, 375);
            AddBook.Name = "AddBook";
            AddBook.Size = new Size(75, 23);
            AddBook.TabIndex = 14;
            AddBook.Text = "Add";
            AddBook.UseVisualStyleBackColor = true;
            // 
            // UpdateBook
            // 
            UpdateBook.DataBindings.Add(new Binding("Command", libraryBookViewModelBindingSource, "updateBookCommand", true));
            UpdateBook.Location = new Point(350, 375);
            UpdateBook.Name = "UpdateBook";
            UpdateBook.Size = new Size(75, 23);
            UpdateBook.TabIndex = 15;
            UpdateBook.Text = "Update";
            UpdateBook.UseVisualStyleBackColor = true;
            // 
            // RemoveBook
            // 
            RemoveBook.DataBindings.Add(new Binding("Command", libraryBookViewModelBindingSource, "removeBookCommand", true));
            RemoveBook.Location = new Point(174, 375);
            RemoveBook.Name = "RemoveBook";
            RemoveBook.Size = new Size(75, 23);
            RemoveBook.TabIndex = 16;
            RemoveBook.Text = "Remove";
            RemoveBook.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { BookStatus });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 17;
            statusStrip1.Text = "statusStrip1";
            // 
            // BookStatus
            // 
            BookStatus.Name = "BookStatus";
            BookStatus.Size = new Size(0, 17);
            // 
            // NewBook
            // 
            NewBook.Location = new Point(12, 375);
            NewBook.Name = "NewBook";
            NewBook.Size = new Size(75, 23);
            NewBook.TabIndex = 18;
            NewBook.Text = "New";
            NewBook.UseVisualStyleBackColor = true;
            NewBook.Click += NewBook_Click;
            // 
            // LibraryBooks
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(NewBook);
            Controls.Add(statusStrip1);
            Controls.Add(RemoveBook);
            Controls.Add(UpdateBook);
            Controls.Add(AddBook);
            Controls.Add(GetBook);
            Controls.Add(BookBorrowed);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(BookDescription);
            Controls.Add(textBox2);
            Controls.Add(BookISBN);
            Controls.Add(AuthorSelection);
            Controls.Add(PublisherSelection);
            Controls.Add(BookList);
            Name = "LibraryBooks";
            Text = "LibraryBooks";
            ((System.ComponentModel.ISupportInitialize)booksBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)libraryBookViewModelBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)publishersBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)authorsBindingSource).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox BookList;
        private ComboBox PublisherSelection;
        private BindingSource publishersBindingSource;
        private BindingSource libraryBookViewModelBindingSource;
        private ComboBox AuthorSelection;
        private BindingSource authorsBindingSource;
        private TextBox BookISBN;
        private TextBox textBox2;
        private RichTextBox BookDescription;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private CheckBox BookBorrowed;
        private BindingSource booksBindingSource;
        private Button GetBook;
        private Button AddBook;
        private Button UpdateBook;
        private Button RemoveBook;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel BookStatus;
        private Button NewBook;
    }
}