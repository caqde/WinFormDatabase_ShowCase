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
            ((System.ComponentModel.ISupportInitialize)libraryMainCheckoutViewModelBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bookListBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)patronListBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)borrowedBookListBindingSource).BeginInit();
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
            booksListBox.Location = new Point(12, 12);
            booksListBox.Name = "booksListBox";
            booksListBox.Size = new Size(143, 289);
            booksListBox.TabIndex = 0;
            booksListBox.ValueMember = "Id";
            // 
            // patronListBox
            // 
            patronListBox.DataSource = patronListBindingSource;
            patronListBox.DisplayMember = "Name";
            patronListBox.FormattingEnabled = true;
            patronListBox.ItemHeight = 15;
            patronListBox.Location = new Point(161, 12);
            patronListBox.Name = "patronListBox";
            patronListBox.Size = new Size(144, 289);
            patronListBox.TabIndex = 1;
            patronListBox.ValueMember = "Id";
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
            borrowedBooksListBox.Location = new Point(581, 12);
            borrowedBooksListBox.Name = "borrowedBooksListBox";
            borrowedBooksListBox.Size = new Size(207, 289);
            borrowedBooksListBox.TabIndex = 2;
            borrowedBooksListBox.ValueMember = "Id";
            // 
            // borrowedBookListBindingSource
            // 
            borrowedBookListBindingSource.DataMember = "BorrowedBookList";
            borrowedBookListBindingSource.DataSource = libraryMainCheckoutViewModelBindingSource;
            // 
            // LibraryMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(borrowedBooksListBox);
            Controls.Add(patronListBox);
            Controls.Add(booksListBox);
            Name = "LibraryMain";
            Text = "LibraryMain";
            ((System.ComponentModel.ISupportInitialize)libraryMainCheckoutViewModelBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)bookListBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)patronListBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)borrowedBookListBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private BindingSource bookListBindingSource;
        private BindingSource libraryMainCheckoutViewModelBindingSource;
        private ListBox booksListBox;
        private ListBox patronListBox;
        private BindingSource patronListBindingSource;
        private ListBox borrowedBooksListBox;
        private BindingSource borrowedBookListBindingSource;
    }
}