using CommunityToolkit.Mvvm.Messaging;
using ShowCaseViewModel.Library;
using ShowCaseViewModel.Messages.Universal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_Database.LibraryDatabase
{
    public partial class LibraryMain : Form, IRecipient<ExceptionMessage>
    {
        LibraryMainCheckoutViewModel viewModel;

        public LibraryMain()
        {
            InitializeComponent();
            viewModel = new LibraryMainCheckoutViewModel();
            libraryMainCheckoutViewModelBindingSource.DataSource = viewModel;
        }

        public void Receive(ExceptionMessage message)
        {
            if (message.Value.GetType() == typeof(Exception))
            {
                StatusBarLabel.Text = message.Value.Message;
                return;
            }
            MessageBox.Show(message.Value.Message, "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void borrowedBooksListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            viewModel.SelectedBorrowedBook = borrowedBooksListBox.SelectedIndex;
        }

        private void patronListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            viewModel.SelectedPatron = patronListBox.SelectedIndex;
        }

        private void booksListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            viewModel.SelectedBook = booksListBox.SelectedIndex;
        }

        private void AuthorButton_Click(object sender, EventArgs e)
        {
            LibraryAuthor libraryAuthor = new LibraryAuthor();
            libraryAuthor.Show();
        }

        private void BookButton_Click(object sender, EventArgs e)
        {
            LibraryBooks libraryBooks = new LibraryBooks();
            libraryBooks.Show();
        }

        private void PatronButton_Click(object sender, EventArgs e)
        {
            LibraryPatron libraryPatron = new LibraryPatron();
            libraryPatron.Show();
        }

        private void PublisherButton_Click(object sender, EventArgs e)
        {
            LibraryPublisher libraryPublisher = new LibraryPublisher();
            libraryPublisher.Show();
        }
    }
}
