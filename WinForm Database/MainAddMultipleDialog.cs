using ShowCaseViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_Database
{
    public partial class MainAddMultipleDialog : Form
    {
        public MainAddMultipleDialog()
        {  
            InitializeComponent();
            mainViewModelBindingSource.DataSource = new MainAddMultipleViewModel();
        }
    }
}
