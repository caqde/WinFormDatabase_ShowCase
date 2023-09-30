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
    public partial class LibraryBooks : Form
    {
        LibraryBookViewModel libraryBookViewModel;

        public LibraryBooks()
        {
            InitializeComponent();
            libraryBookViewModel = new LibraryBookViewModel();
            libraryBookViewModelBindingSource.DataSource = libraryBookViewModel;
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
    }
}
