namespace WinForm_Database.LibraryDatabase
{
    partial class LibraryMain
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
            libraryMainCheckoutViewModelBindingSource = new BindingSource(components);
            bookListBindingSource = new BindingSource(components);
            booksListBox = new ListBox();
            patronListBox = new ListBox();
            patronListBindingSource = new BindingSource(components);
            borrowedBooksListBox = new ListBox();
            borrowedBookListBindingSource = new BindingSource(components);
            statusStrip1 = new StatusStrip();
            StatusBarLabel = new ToolStripStatusLabel();
            BorrowButton = new Button();
            BookButton = new Button();
            AuthorButton = new Button();
            ReturnButton = new Button();
            ReBorrowButton = new Button();
            PatronButton = new Button();
            PublisherButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)libraryMainCheckoutViewModelBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bookListBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)patronListBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)borrowedBookListBindingSource).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // libraryMainCheckoutViewModelBindingSource
            // 
            libraryMainCheckoutViewModelBindingSource.DataSource = typeof(ShowCaseViewModel.Library.LibraryMainCheckoutViewModel);
            // 
            // bookListBindingSource
            // 
            bookListBindingSource.DataMember = "BookList";
            bookListBindingSource.DataSource = libraryMainCheckoutViewModelBindingSource;
            // 
            // booksListBox
            // 
            booksListBox.DataSource = bookListBindingSource;
            booksListBox.DisplayMember = "Title";
            booksListBox.FormattingEnabled = true;
            booksListBox.ItemHeight = 15;
            booksListBox.Location = new Point(135, 35);
            booksListBox.Name = "booksListBox";
            booksListBox.Size = new Size(143, 289);
            booksListBox.TabIndex = 0;
            booksListBox.ValueMember = "Id";
            booksListBox.SelectedIndexChanged += booksListBox_SelectedIndexChanged;
            // 
            // patronListBox
            // 
            patronListBox.DataSource = patronListBindingSource;
            patronListBox.DisplayMember = "Name";
            patronListBox.FormattingEnabled = true;
            patronListBox.ItemHeight = 15;
            patronListBox.Location = new Point(284, 35);
            patronListBox.Name = "patronListBox";
            patronListBox.Size = new Size(144, 289);
            patronListBox.TabIndex = 1;
            patronListBox.ValueMember = "Id";
            patronListBox.SelectedIndexChanged += patronListBox_SelectedIndexChanged;
            // 
            // patronListBindingSource
            // 
            patronListBindingSource.DataMember = "PatronList";
            patronListBindingSource.DataSource = libraryMainCheckoutViewModelBindingSource;
            // 
            // borrowedBooksListBox
            // 
            borrowedBooksListBox.DataSource = borrowedBookListBindingSource;
            borrowedBooksListBox.DisplayMember = "BorrowedBook";
            borrowedBooksListBox.FormattingEnabled = true;
            borrowedBooksListBox.ItemHeight = 15;
            borrowedBooksListBox.Location = new Point(581, 35);
            borrowedBooksListBox.Name = "borrowedBooksListBox";
            borrowedBooksListBox.Size = new Size(207, 289);
            borrowedBooksListBox.TabIndex = 2;
            borrowedBooksListBox.ValueMember = "Id";
            borrowedBooksListBox.SelectedIndexChanged += borrowedBooksListBox_SelectedIndexChanged;
            // 
            // borrowedBookListBindingSource
            // 
            borrowedBookListBindingSource.DataMember = "BorrowedBookList";
            borrowedBookListBindingSource.DataSource = libraryMainCheckoutViewModelBindingSource;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { StatusBarLabel });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // StatusBarLabel
            // 
            StatusBarLabel.Name = "StatusBarLabel";
            StatusBarLabel.Size = new Size(0, 17);
            // 
            // BorrowButton
            // 
            BorrowButton.DataBindings.Add(new Binding("Command", libraryMainCheckoutViewModelBindingSource, "borrowBookCommand", true));
            BorrowButton.Location = new Point(353, 330);
            BorrowButton.Name = "BorrowButton";
            BorrowButton.Size = new Size(75, 23);
            BorrowButton.TabIndex = 4;
            BorrowButton.Text = "Borrow";
            BorrowButton.UseVisualStyleBackColor = true;
            // 
            // BookButton
            // 
            BookButton.Location = new Point(23, 72);
            BookButton.Name = "BookButton";
            BookButton.Size = new Size(75, 23);
            BookButton.TabIndex = 5;
            BookButton.Text = "Books";
            BookButton.UseVisualStyleBackColor = true;
            BookButton.Click += BookButton_Click;
            // 
            // AuthorButton
            // 
            AuthorButton.Location = new Point(23, 43);
            AuthorButton.Name = "AuthorButton";
            AuthorButton.Size = new Size(75, 23);
            AuthorButton.TabIndex = 6;
            AuthorButton.Text = "Authors";
            AuthorButton.UseVisualStyleBackColor = true;
            AuthorButton.Click += AuthorButton_Click;
            // 
            // ReturnButton
            // 
            ReturnButton.DataBindings.Add(new Binding("Command", libraryMainCheckoutViewModelBindingSource, "returnBookCommand", true));
            ReturnButton.Location = new Point(581, 330);
            ReturnButton.Name = "ReturnButton";
            ReturnButton.Size = new Size(75, 23);
            ReturnButton.TabIndex = 7;
            ReturnButton.Text = "Return";
            ReturnButton.UseVisualStyleBackColor = true;
            // 
            // ReBorrowButton
            // 
            ReBorrowButton.DataBindings.Add(new Binding("Command", libraryMainCheckoutViewModelBindingSource, "reBorrowBookCommand", true));
            ReBorrowButton.Location = new Point(662, 330);
            ReBorrowButton.Name = "ReBorrowButton";
            ReBorrowButton.Size = new Size(75, 23);
            ReBorrowButton.TabIndex = 8;
            ReBorrowButton.Text = "Re-Borrow";
            ReBorrowButton.UseVisualStyleBackColor = true;
            // 
            // PatronButton
            // 
            PatronButton.Location = new Point(23, 101);
            PatronButton.Name = "PatronButton";
            PatronButton.Size = new Size(75, 23);
            PatronButton.TabIndex = 9;
            PatronButton.Text = "Patrons";
            PatronButton.UseVisualStyleBackColor = true;
            PatronButton.Click += PatronButton_Click;
            // 
            // PublisherButton
            // 
            PublisherButton.Location = new Point(23, 130);
            PublisherButton.Name = "PublisherButton";
            PublisherButton.Size = new Size(75, 23);
            PublisherButton.TabIndex = 10;
            PublisherButton.Text = "Publishers";
            PublisherButton.UseVisualStyleBackColor = true;
            PublisherButton.Click += PublisherButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(193, 9);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 11;
            label1.Text = "Books";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(330, 9);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 12;
            label2.Text = "Patrons";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(635, 9);
            label3.Name = "label3";
            label3.Size = new Size(93, 15);
            label3.TabIndex = 13;
            label3.Text = "Borrowed Books";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 9);
            label4.Name = "label4";
            label4.Size = new Size(105, 15);
            label4.TabIndex = 14;
            label4.Text = "Data Management";
            // 
            // LibraryMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(PublisherButton);
            Controls.Add(PatronButton);
            Controls.Add(ReBorrowButton);
            Controls.Add(ReturnButton);
            Controls.Add(AuthorButton);
            Controls.Add(BookButton);
            Controls.Add(BorrowButton);
            Controls.Add(statusStrip1);
            Controls.Add(borrowedBooksListBox);
            Controls.Add(patronListBox);
            Controls.Add(booksListBox);
            Name = "LibraryMain";
            Text = "LibraryMain";
            ((System.ComponentModel.ISupportInitialize)libraryMainCheckoutViewModelBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)bookListBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)patronListBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)borrowedBookListBindingSource).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private BindingSource bookListBindingSource;
        private BindingSource libraryMainCheckoutViewModelBindingSource;
        private ListBox booksListBox;
        private ListBox patronListBox;
        private BindingSource patronListBindingSource;
        private ListBox borrowedBooksListBox;
        private BindingSource borrowedBookListBindingSource;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel StatusBarLabel;
        private Button BorrowButton;
        private Button BookButton;
        private Button AuthorButton;
        private Button ReturnButton;
        private Button ReBorrowButton;
        private Button PatronButton;
        private Button PublisherButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}