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
    public partial class LibraryPatron : Form, IRecipient<LibraryAddItem>, IRecipient<LibraryGetItem>, IRecipient<LibraryRemoveItem>, IRecipient<LibraryUpdateItem>, IRecipient<ExceptionMessage>
    {
        LibraryPatronViewModel model;

        public LibraryPatron()
        {
            InitializeComponent();
            model = new LibraryPatronViewModel();
            libraryPatronViewModelBindingSource.DataSource = model;
            WeakReferenceMessenger.Default.RegisterAll(this);
            model.SelectedPatronID = -1;
        }

        public void Receive(LibraryAddItem message)
        {
            PatronStatus.Text = "Patron has been added";
        }

        public void Receive(LibraryGetItem message)
        {
            PatronStatus.Text = "Patron has been retrieved";
        }

        public void Receive(LibraryRemoveItem message)
        {
            PatronStatus.Text = "Patron has been removed";
        }

        public void Receive(LibraryUpdateItem message)
        {
            PatronStatus.Text = "Patron has been updated";
        }

        public void Receive(ExceptionMessage message)
        {
            if (message.Value.GetType() == typeof(Exception))
            {
                PatronStatus.Text = message.Value.Message;
                return;
            }
            MessageBox.Show(message.Value.Message, "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void PatronList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PatronList.SelectedValue is int)
            {
                model.SelectedPatronID = (int)PatronList.SelectedValue;
            }
        }
    }
}
