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
            dbId = data.GetiD();
            dbName = data.GetName();
        }

        private ShowCaseInstance DatabaseInstance;

        private bool itemChanged;

        [ObservableProperty]
        private List<String> dbNewItems;

        [ObservableProperty]
        private int dbId;
        [ObservableProperty]
        private string? dbName;

        partial void OnDbNameChanged(string? oldValue, string? newValue)
        {
            if (oldValue != newValue)
            {
                itemChanged = true;
            }
        }

        [RelayCommand]
        private void Next()
        {
            dbObjectModel data = DatabaseInstance.getDBObject();
            bool response = data.NextEntry();
            if (response)
            {
                dbId = data.GetiD();
                DbName = data.GetName();
            }
            
            WeakReferenceMessenger.Default.Send(new NextMessage(response));
            itemChanged = false;
        }

        [RelayCommand]
        private void Previous()
        {
            dbObjectModel data = DatabaseInstance.getDBObject();
            bool response = data.PrevEntry();
            if (response)
            {
                dbId = data.GetiD();
                DbName = data.GetName();
            }
            WeakReferenceMessenger.Default.Send(new PreviousMessage(response));
            itemChanged = false;
        }

        [RelayCommand]
        private void Save()
        {
            dbObjectModel data = DatabaseInstance.getDBObject();
            if (itemChanged)
            {
                data.SetName(dbName);
                WeakReferenceMessenger.Default.Send(new SaveMessage(data.SaveEntry()));
            }
            itemChanged = false;
        }

        [RelayCommand]
        private void Delete()
        {
            dbObjectModel data = DatabaseInstance.getDBObject();
            bool response = data.DeleteEntry();
            if (response)
            {
                dbId = data.GetiD();
                DbName = data.GetName();
            }
            WeakReferenceMessenger.Default.Send(new DeleteMessage(response));
        }

        [RelayCommand]
        private void Add()
        {
            dbObjectModel data = DatabaseInstance.getDBObject();
            bool response = data.AddEntry();
            if (response)
            {
                dbId = data.GetiD();
                DbName = data.GetName();
            }
            WeakReferenceMessenger.Default.Send(new AddMessage(response));
            itemChanged = true;
        }

        [RelayCommand]
        private void MultiSave()
        {
            dbObjectModel data = DatabaseInstance.getDBObject();
            bool response = data.SaveEntries();
            WeakReferenceMessenger.Default.Send(new MultiSaveMessage(response));
        }
    }
}