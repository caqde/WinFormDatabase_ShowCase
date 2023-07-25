using CommunityToolkit.Mvvm.Messaging;
using ShowCaseViewModel;
using ShowCaseViewModel.Messages;

namespace WinForm_Database
{
    public partial class Main : Form, IRecipient<PreviousMessage>, IRecipient<SaveMessage>, IRecipient<NextMessage>
    {
        public Main()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            MainDataSource.DataSource = new MainViewModel();
            WeakReferenceMessenger.Default.Register<PreviousMessage>(this);
            WeakReferenceMessenger.Default.Register<SaveMessage>(this);
            WeakReferenceMessenger.Default.Register<NextMessage>(this);
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