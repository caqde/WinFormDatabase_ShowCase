using CommunityToolkit.Mvvm.Messaging;
using ShowCaseViewModel.Library;
using ShowCaseViewModel.Messages.LibraryMessages;
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
    public partial class LibraryBooks : Form, IRecipient<LibraryAddItem>, IRecipient<LibraryRemoveItem>, IRecipient<LibraryUpdateItem>, IRecipient<LibraryGetItem>, IRecipient<ExceptionMessage>
    {
        LibraryBookViewModel libraryBookViewModel;

        public LibraryBooks()
        {
            InitializeComponent();
            libraryBookViewModel = new LibraryBookViewModel();
            libraryBookViewModelBindingSource.DataSource = libraryBookViewModel;
            WeakReferenceMessenger.Default.RegisterAll(this);
        }

        private void AuthorSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            libraryBookViewModel.SelectedAuthorID = AuthorSelection.SelectedIndex;
        }

        private void PublisherSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            libraryBookViewModel.SelectedPublisherID = PublisherSelection.SelectedIndex;
        }

        private void BookList_SelectedIndexChanged(object sender, EventArgs e)
        {
            libraryBookViewModel.SelectedBookID = BookList.SelectedIndex;
        }

        public void Receive(LibraryAddItem message)
        {
            BookStatus.Text = "Book has been added";
        }

        public void Receive(LibraryRemoveItem message)
        {
            BookStatus.Text = "Book has been removed";
        }

        public void Receive(LibraryUpdateItem message)
        {
            BookStatus.Text = "Book has been updated";
        }

        public void Receive(LibraryGetItem message)
        {
            BookStatus.Text = "Book has been retrieved";
        }

        public void Receive(ExceptionMessage message)
        {
            if (message.Value.GetType() == typeof(Exception))
            {
                BookStatus.Text = message.Value.Message;
                return;
            }
            MessageBox.Show(message.Value.Message, "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}
