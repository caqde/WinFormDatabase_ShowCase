using CommunityToolkit.Mvvm.Messaging;
using ShowCaseViewModel;
using ShowCaseViewModel.Messages;
using ShowCaseViewModel.Messages.MainAddMutlipleDialog;
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
    public partial class MainAddMultipleDialog : Form, IRecipient<MultiSaveMessage>, IRecipient<CloseDialogMessage>
    {
        public MainAddMultipleDialog()
        {
            InitializeComponent();
            mainAddMultipleViewModelBindingSource.DataSource = new MainAddMultipleViewModel();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            newItemsBindingSource.DataSource = mainAddMultipleViewModelBindingSource.DataSource;
            newItemsBindingSource.DataMember = "NewItems";
        }

        public void Receive(CloseDialogMessage message)
        {
            if (message.Value)
            {
                this.Close();
            }
            else
            {
                var result = MessageBox.Show("Data is not saved! Save before exit?", "Save Data?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    WeakReferenceMessenger.Default.Send(new SaveCloseMessage(true));
                }
                else if (result == DialogResult.No)
                {
                    this.Close();
                }
                else
                {
                    return;
                }
            }
        }

        public void Receive(MultiSaveMessage message)
        {
            return;
        }
    }
}
