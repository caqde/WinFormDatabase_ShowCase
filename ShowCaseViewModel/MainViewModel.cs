using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ShowCaseModel;
using ShowCaseModel.Models;
using ShowCaseViewModel.GridViewTypes;
using ShowCaseViewModel.Messages;
using System.ComponentModel;

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
            DbNewItems = new List<NameType>();
        }

        private ShowCaseInstance DatabaseInstance;

        private bool itemChanged;

        [ObservableProperty]
        private List<NameType> dbNewItems;

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
                DbId = data.GetiD();
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
                DbId = data.GetiD();
                DbName = data.GetName();
            }
            WeakReferenceMessenger.Default.Send(new PreviousMessage(response));
            itemChanged = false;
        }

        [RelayCommand]
        private void Save()
        {
            dbObjectModel data = DatabaseInstance.getDBObject();
            if (itemChanged && DbName is not null)
            {
                data.SetName(DbName);
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
                DbId = data.GetiD();
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
                DbId = data.GetiD();
                DbName = data.GetName();
            }
            WeakReferenceMessenger.Default.Send(new AddMessage(response));
            itemChanged = true;
        }

        [RelayCommand]
        private void AddMulti()
        {
            bool response = true;
            WeakReferenceMessenger.Default.Send(new AddMultiMessage(response));
        }
    }
}