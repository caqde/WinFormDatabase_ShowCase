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
    public partial class LibraryPatron : Form
    {
        LibraryPatronViewModel model;

        public LibraryPatron()
        {
            InitializeComponent();
            model = new LibraryPatronViewModel();
            libraryPatronViewModelBindingSource.DataSource = model;
        }

        private void PatronList_SelectedIndexChanged(object sender, EventArgs e)
        {
            model.SelectedPatronID = PatronList.SelectedIndex;
        }
    }
}
