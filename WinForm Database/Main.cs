using CommunityToolkit.Mvvm.Messaging;
using ShowCaseViewModel.Messages;

namespace WinForm_Database
{
    public partial class Main : Form, IRecipient<PreviousMessage>, IRecipient<SaveMessage>, IRecipient<NextMessage>
    {
        public Main()
        {
            InitializeComponent();
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
    }
}