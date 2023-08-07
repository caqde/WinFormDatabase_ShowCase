using CommunityToolkit.Mvvm.Messaging;
using ShowCaseViewModel;
using ShowCaseViewModel.GridViewTypes;
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
    public partial class SingleAttributeMultipleEntryDialog : Form, IRecipient<MultiSaveMessage>, IRecipient<CloseDialogMessage>
    {
        bool dataSaved = false;

        public SingleAttributeMultipleEntryDialog()
        {
            InitializeComponent();
            mainAddMultipleViewModelBindingSource.DataSource = new SingleAttributeDatabaseMultipleViewModel();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //Why this needs to be restated I do not know. But if this is not done the application will display the Datasource
            //but crash when a user tries to edit the data.
            newItemsBindingSource.DataSource = mainAddMultipleViewModelBindingSource.DataSource;
            newItemsBindingSource.DataMember = "NewItems";
            WeakReferenceMessenger.Default.RegisterAll(this);
        }

        public void Receive(CloseDialogMessage message)
        {
            if (message.Value)
            {
                this.Close();
            }
            else
            {
                if (dataSaved)
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
        }

        public void Receive(MultiSaveMessage message)
        {
            dataSaved = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            
            return;
        }
    }
}
