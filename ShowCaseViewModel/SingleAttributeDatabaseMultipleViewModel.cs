using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using ShowCaseViewModel.GridViewTypes;
using ShowCaseViewModel.Messages;
using ShowCaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using ShowCaseModel.Models;
using ShowCaseViewModel.Messages.MainAddMutlipleDialog;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ShowCaseViewModel
{
    public partial class SingleAttributeDatabaseMultipleViewModel : ObservableObject, IRecipient<CreateMultiMessage>, IRecipient<SaveCloseMessage>
    {
        public SingleAttributeDatabaseMultipleViewModel() 
        {
            DatabaseInstance = new ShowCaseInstance();
            NewItems = new BindingList<NameType>();
            newEntries = new Dictionary<int, string>();
            WeakReferenceMessenger.Default.RegisterAll(this);
        }

        private bool saveClicked = false;
        private bool firstSave = false;
        private ShowCaseInstance DatabaseInstance;
        private Dictionary<int, string> newEntries;

        [ObservableProperty]
        private BindingList<NameType> newItems;

        //Changes to Win Form's DataGridView do not trigger this? Why? BindingList does not trigger this
        partial void OnNewItemsChanged(BindingList<NameType> value)
        {
            saveClicked = false;
        }

        [RelayCommand]
        private void MultiSave()
        {
            WeakReferenceMessenger.Default.Send(new MultiSaveMessage(Save()));
            
        }

        [RelayCommand]
        private void MultiSaveClose()
        {
            WeakReferenceMessenger.Default.Send(new CloseDialogMessage(Save()));
        }

        [RelayCommand]
        private void Cancel()
        {
            WeakReferenceMessenger.Default.Send(new CloseDialogMessage(false));
        }


        private bool Save()
        {
            dbObjectModel data = DatabaseInstance.getDBObject();
            int x = 0;
            if (NewItems is not null && NewItems.Count > 0)
            {
                newEntries = new Dictionary<int, string>();
                foreach (var item in NewItems)
                {
                    newEntries.Add(x++, item.Name);
                }
            }
            bool response;
            if (saveClicked)
            {
                response = true;
            }
            else
            {
                if (firstSave)
                {
                    response = data.SetEntries(newEntries);
                    response = data.SaveEntries();
                    saveClicked = true;
                }
                else
                {
                    response = data.AddEntries(ref newEntries);
                    firstSave = true;
                    saveClicked = true;
                } 
            }
            return response;
        }


        public void Receive(CreateMultiMessage message)
        {
            int value = message.Value;
            NewItems = new BindingList<NameType>();
            NewItems.RaiseListChangedEvents = true;
            NewItems.ListChanged += NewItems_ListChanged;
            for (int i = 0; i < value; i++)
            {
                NewItems.Add(new NameType("Name " + i.ToString()));
            }
            WeakReferenceMessenger.Default.Send(new EditMultiMessage(true));
        }

        private void NewItems_ListChanged(object? sender, ListChangedEventArgs e)
        {
            BindingList<NameType> newEntries = (BindingList<NameType>)sender;
            OnNewItemsChanged(newEntries);
        }

        public void Receive(SaveCloseMessage message)
        {
            MultiSaveClose();
        }
    }
}
