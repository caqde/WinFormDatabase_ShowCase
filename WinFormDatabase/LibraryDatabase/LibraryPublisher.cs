using ShowCaseViewModel.Library;
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
    public partial class LibraryPublisher : Form
    {
        private LibraryPublisherViewModel viewModel;

        public LibraryPublisher()
        {
            InitializeComponent();
            viewModel = new LibraryPublisherViewModel();
            libraryPublisherViewModelBindingSource.DataSource = viewModel;
        }

        private void PublisherList_SelectedIndexChanged(object sender, EventArgs e)
        {
            viewModel.SelectedPublisherID = PublisherList.SelectedIndex;
        }
    }
}
