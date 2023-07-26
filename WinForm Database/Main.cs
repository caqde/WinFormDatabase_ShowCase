using CommunityToolkit.Mvvm.Messaging;
using ShowCaseViewModel;
using ShowCaseViewModel.Messages;
using System.ComponentModel;

namespace WinForm_Database
{
    public partial class Main : Form, IRecipient<PreviousMessage>, IRecipient<SaveMessage>, IRecipient<NextMessage>
        , IRecipient<AddMessage>, IRecipient<DeleteMessage>
    {
        public Main()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            MainDataSource.DataSource = new MainViewModel();
            WeakReferenceMessenger.Default.RegisterAll(this);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            WeakReferenceMessenger.Default.UnregisterAll(this);
        }

        public void Receive(PreviousMessage message)
        {
            if (message.Value)
            {
                tbStatuslbl.Text = "Moving to Previous Item";
            }
            else
            {
                tbStatuslbl.Text = "Previous Item doesn't exist";
            }
        }

        public void Receive(SaveMessage message)
        {
            if (message.Value)
            {
                tbStatuslbl.Text = "Item Saved";
            }
            else
            {
                tbStatuslbl.Text = "Unable to save Item";
            }
        }

        public void Receive(NextMessage message)
        {
            if (message.Value)
            {
                tbStatuslbl.Text = "Moving to Next Item";
            }
            else
            {
                tbStatuslbl.Text = "Next Item doesn't exist";
            }
        }

        public void Receive(DeleteMessage message)
        {
            if(message.Value)
            {
                tbStatuslbl.Text = "Item Deleted";
            }
            else
            {
                tbStatuslbl.Text = "No Item to delete";
            }
        }

        public void Receive(AddMessage message)
        {
            if(message.Value)
            {
                tbStatuslbl.Text = "New Item Added";
            }
            else
            {
                tbStatuslbl.Text = "Database Error Item not created";
            }
        }
    }
}