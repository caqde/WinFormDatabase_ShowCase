using CommunityToolkit.Mvvm.Messaging;
using ShowCaseViewModel;
using ShowCaseViewModel.Messages.Main;
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
    public partial class Main : Form, IRecipient<LaunchSingleDatabaseViewMessage>
    {
        private Form? currentPanelForm;
        private Dictionary<Type, Form> FormList = new Dictionary<Type, Form>();

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

            if (FormPanelNeedsClearing(typeof(SingleAttributeDatabase)))
            {
                ClearFormPanel();
                AddFormPanel();
            }      
            else
            {
                if (currentPanelForm is null)
                {
                    AddFormPanel();
                }
            }
        }

        private void AddFormPanel()
        {
            if (FormList.ContainsKey (typeof(SingleAttributeDatabase)))
            {
                currentPanelForm = FormList[typeof(SingleAttributeDatabase)];
                this.formPanel.Controls.Add(currentPanelForm);
                currentPanelForm.Show();
            }
            else
            {
                SingleAttributeDatabase singleDatabaseForm = new SingleAttributeDatabase();
                singleDatabaseForm.TopLevel = false;
                singleDatabaseForm.AutoScroll = true;
                singleDatabaseForm.FormBorderStyle = FormBorderStyle.None;
                currentPanelForm = singleDatabaseForm;
                FormList.Add(typeof(SingleAttributeDatabase), singleDatabaseForm);
                this.formPanel.Controls.Add(singleDatabaseForm);
                currentPanelForm.Show();
            }

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
            if (currentPanelForm != null)
            {
                currentPanelForm.Hide();
                formPanel.Controls.Remove(currentPanelForm);
            }
        }
    }
}
