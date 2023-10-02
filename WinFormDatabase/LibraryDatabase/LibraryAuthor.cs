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
    public partial class LibraryAuthor : Form, IRecipient<LibraryAddItem>, IRecipient<LibraryGetItem>, IRecipient<LibraryRemoveItem>, IRecipient<LibraryUpdateItem>, IRecipient<ExceptionMessage>
    {
        private LibraryAuthorViewModel _viewModel;

        public LibraryAuthor()
        {
            InitializeComponent();
            _viewModel = new LibraryAuthorViewModel();
            libraryAuthorViewModelBindingSource.DataSource = _viewModel;
            WeakReferenceMessenger.Default.RegisterAll(this);
        }

        public void Receive(LibraryAddItem message)
        {
            AuthorStatus.Text = "Author has been added";
        }

        public void Receive(LibraryGetItem message)
        {
            AuthorStatus.Text = "Author has been retrieved";
        }

        public void Receive(LibraryRemoveItem message)
        {
            AuthorStatus.Text = "Author has been removed";
        }

        public void Receive(LibraryUpdateItem message)
        {
            AuthorStatus.Text = "Author has been updated";
        }

        public void Receive(ExceptionMessage message)
        {
            if (message.Value.GetType() == typeof(Exception))
            {
                AuthorStatus.Text = message.Value.Message;
                return;
            }
            MessageBox.Show(message.Value.Message, "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void AuthorListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AuthorListBox.SelectedValue is int)
            {
                _viewModel.SelectedAuthorID = (int)AuthorListBox.SelectedValue;
            }
        }

        private void NewAuthor_Click(object sender, EventArgs e)
        {
            _viewModel.SelectedAuthorID = -1;
        }
    }
}
