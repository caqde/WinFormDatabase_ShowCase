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
    public partial class LibraryPublisher : Form, IRecipient<LibraryAddItem>, IRecipient<LibraryGetItem>, IRecipient<LibraryRemoveItem>, IRecipient<LibraryUpdateItem>, IRecipient<ExceptionMessage>
    {
        private LibraryPublisherViewModel viewModel;

        public LibraryPublisher()
        {
            InitializeComponent();
            viewModel = new LibraryPublisherViewModel();
            libraryPublisherViewModelBindingSource.DataSource = viewModel;
            WeakReferenceMessenger.Default.RegisterAll(this);
            viewModel.SelectedPublisherID = -1;
        }

        public void Receive(LibraryAddItem message)
        {
            PublisherStatus.Text = "Publisher successfully added";
        }

        public void Receive(LibraryGetItem message)
        {
            PublisherStatus.Text = "Publisher successfully retrieved";
        }

        public void Receive(LibraryRemoveItem message)
        {
            PublisherStatus.Text = "Publisher successfully removed";
        }

        public void Receive(LibraryUpdateItem message)
        {
            PublisherStatus.Text = "Publisher successfully updated";
        }

        public void Receive(ExceptionMessage message)
        {
            if (message.Value.GetType() == typeof(Exception))
            {
                PublisherStatus.Text = message.Value.Message;
                return;
            }
            MessageBox.Show(message.Value.Message, "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void PublisherList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PublisherList.SelectedValue is int)
            {
                viewModel.SelectedPublisherID = (int)PublisherList.SelectedValue;
            }
        }

        private void NewPublisher_Click(object sender, EventArgs e)
        {
            viewModel.SelectedPublisherID = -1;
        }
    }
}
