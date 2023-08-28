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
    public partial class SingleAttributeDatabaseViewModel: ObservableObject
    {
        public SingleAttributeDatabaseViewModel()
        {
            DatabaseInstance = ShowCaseInstance.Instance;
            IDbObject data = DatabaseInstance.getDBObject();
            dbId = data.GetID();
            dbName = data.GetName();
            DbNewItems = new List<NameType>();
        }

        private ShowCaseInstance DatabaseInstance;

        private bool itemChanged;
        private bool newEntry;

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
            IDbObject data = DatabaseInstance.getDBObject();
            bool response = data.NextEntry();
            if (response)
            {
                DbId = data.GetID();
                DbName = data.GetName();
            }
            
            WeakReferenceMessenger.Default.Send(new NextMessage(response));
            itemChanged = false;
            newEntry = false;
        }

        [RelayCommand]
        private void Previous()
        {
            IDbObject data = DatabaseInstance.getDBObject();
            bool response = data.PrevEntry();
            if (response)
            {
                DbId = data.GetID();
                DbName = data.GetName();
            }
            WeakReferenceMessenger.Default.Send(new PreviousMessage(response));
            itemChanged = false;
            newEntry = false;
        }

        [RelayCommand]
        private void Save()
        {
            IDbObject data = DatabaseInstance.getDBObject();
            if (itemChanged && DbName is not null)
            {
                if (newEntry)
                {
                    data.AddEntry(DbName);
                    WeakReferenceMessenger.Default.Send(new SaveMessage(true));
                    newEntry = false;
                }
                else
                {
                    data.SetName(DbName);
                    WeakReferenceMessenger.Default.Send(new SaveMessage(true));
                }
            }
            itemChanged = false;
        }

        [RelayCommand]
        private void Delete()
        {
            IDbObject data = DatabaseInstance.getDBObject();
            bool response = data.DeleteEntry();
            if (response)
            {
                DbId = data.GetID();
                DbName = data.GetName();
            }
            WeakReferenceMessenger.Default.Send(new DeleteMessage(response));
        }

        [RelayCommand]
        private void Add()
        {
            IDbObject data = DatabaseInstance.getDBObject();
            DbId = 0;
            DbName = "";
            newEntry = true;
            WeakReferenceMessenger.Default.Send(new AddMessage(true));
            itemChanged = false;
        }

        [RelayCommand]
        private void AddMulti()
        {
            bool response = true;
            WeakReferenceMessenger.Default.Send(new AddMultiMessage(response));
        }
    }
}