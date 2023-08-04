using CommunityToolkit.Mvvm.Messaging;
using IPrompt;
using ShowCaseViewModel;
using ShowCaseViewModel.Messages;
using System.ComponentModel;

namespace WinForm_Database
{
    public partial class Main : Form, IRecipient<PreviousMessage>, IRecipient<SaveMessage>, IRecipient<NextMessage>
        , IRecipient<AddMessage>, IRecipient<DeleteMessage>, IRecipient<AddMultiMessage>
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
            if (message.Value)
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
            if (message.Value)
            {
                tbStatuslbl.Text = "New Item Added";
            }
            else
            {
                tbStatuslbl.Text = "Database Error Item not created";
            }
        }

        public void Receive(AddMultiMessage message)
        {
            string input = IInputBox.Show("How many items do you want to add", "Add Multiple?", System.Windows.MessageBoxImage.Question , "0");
            int value = 0;
            bool isNumeric = Int32.TryParse(input, out value);
            if (isNumeric)
            {

            }
            else
            {
                MessageBox.Show("Value entered is not a Number", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}