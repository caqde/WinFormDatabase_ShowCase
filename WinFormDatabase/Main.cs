using CommunityToolkit.Mvvm.Messaging;
using ShowCaseViewModel;
using ShowCaseViewModel.Messages.Main;
using ShowCaseViewModel.Messages.Universal;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm_Database.LibraryDatabase;

namespace WinForm_Database
{
    public partial class Main : Form, IRecipient<LaunchSingleDatabaseViewMessage>, IRecipient<LaunchLibraryDatabaseMessage>
    {
        enum FormTable
        {
            SingleAttribute,
            Library
        }

        private Form? currentPanelForm;
        private Dictionary<Type, Form> FormList = new Dictionary<Type, Form>();
        private Dictionary<Type, FormTable> FormTypeList = new Dictionary<Type, FormTable>() { { typeof(SingleAttributeDatabase), FormTable.SingleAttribute },
                                                                                                { typeof(LibraryMain), FormTable.Library } };

        public Main()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            mainViewModelBindingSource.DataSource = new MainViewModel();
            WeakReferenceMessenger.Default.RegisterAll(this);
        }

        public void Receive(LaunchSingleDatabaseViewMessage message)
        {
            LoadFormPanel(typeof(SingleAttributeDatabase));
        }

        public void Receive(LaunchLibraryDatabaseMessage message)
        {
            LoadFormPanel(typeof(LibraryMain));
        }

        private void LoadFormPanel(Type Panel)
        {
            if (FormPanelNeedsClearing(Panel))
            {
                ClearFormPanel();
                AddFormPanel(Panel);
            }
            else
            {
                if (currentPanelForm is null)
                {
                    AddFormPanel(Panel);
                }
            }
        }

        private void AddFormPanel(Type newformType)
        {
            if (FormList.ContainsKey(newformType))
            {
                currentPanelForm = FormList[newformType];
                this.formPanel.Controls.Add(currentPanelForm);
                currentPanelForm.Show();
            }
            else
            {
                AddNewFormPanel(newformType);
            }
        }

        private void AddNewFormPanel(Type newformType)
        {
            FormTable type = FormTypeList[newformType];
            Form? form = null;
            switch (type)
            {
                case FormTable.Library:
                    form = new LibraryMain();
                    break;
                case FormTable.SingleAttribute:
                    form = new SingleAttributeDatabase();
                    break;

                default:
                    return;
            }
            form.TopLevel = false;
            form.AutoScroll = true;
            form.FormBorderStyle = FormBorderStyle.None;
            currentPanelForm = form;
            FormList.Add(newformType, form);
            this.formPanel.Controls.Add(form);
            currentPanelForm.Show();
        }

        private bool FormPanelNeedsClearing(Type newformType)
        {
            if (currentPanelForm is not null)
            {
                if (currentPanelForm.GetType() == newformType)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private void ClearFormPanel()
        {
            if (currentPanelForm is not null)
            {
                currentPanelForm.Hide();
                formPanel.Controls.Remove(currentPanelForm);
            }
        }


    }
}
