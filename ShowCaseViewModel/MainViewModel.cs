using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ShowCaseModel;
using ShowCaseModel.Models;
using ShowCaseViewModel.Messages;

namespace ShowCaseViewModel
{
    public partial class MainViewModel: ObservableObject
    {
        public MainViewModel()
        {
            DatabaseInstance = new ShowCaseInstance();
            dbObjectModel data = DatabaseInstance.getDBObject();
        }

        private ShowCaseInstance DatabaseInstance;

        private bool itemChanged;

        [ObservableProperty]
        private int dbId;
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

        [RelayCommand]
        private void Delete()
        {
            WeakReferenceMessenger.Default.Send(new DeleteMessage(true));
        }

        [RelayCommand]
        private void Add()
        {
            WeakReferenceMessenger.Default.Send(new AddMessage(true));
        }
    }
}