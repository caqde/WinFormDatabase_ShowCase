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
    public partial class LibraryAuthor : Form
    {
        private LibraryAuthorViewModel _viewModel;

        public LibraryAuthor()
        {
            InitializeComponent();
            _viewModel = new LibraryAuthorViewModel();
            libraryAuthorViewModelBindingSource.DataSource = _viewModel;
        }

        private void AuthorListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _viewModel.SelectedAuthorID = AuthorListBox.SelectedIndex;
        }
    }
}
