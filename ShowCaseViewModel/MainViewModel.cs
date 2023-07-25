using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ShowCaseViewModel.Messages;

namespace ShowCaseViewModel
{
    public partial class MainViewModel: ObservableObject
    {
        public MainViewModel()
        {

        }

        private bool itemChanged;

        [ObservableProperty]
        private string? dbName;

        [RelayCommand]
        private void Next()
        {
            WeakReferenceMessenger.Default.Send(new NextMessage(itemChanged));
        }

        [RelayCommand]
        private void Previous()
        {
            WeakReferenceMessenger.Default.Send(new PreviousMessage(itemChanged));
        }

        [RelayCommand]
        private void Save()
        {
            WeakReferenceMessenger.Default.Send(new SaveMessage(true));
        }
    }
}