﻿using CommunityToolkit.Mvvm.ComponentModel;
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

namespace ShowCaseViewModel
{
    public partial class MainAddMultipleViewModel : ObservableObject, IRecipient<CreateMultiMessage>, IRecipient<SaveCloseMessage>
    {
        public MainAddMultipleViewModel() 
        {
            DatabaseInstance = new ShowCaseInstance();
            NewItems = new List<NameType>();
            newEntries = new Dictionary<int, string>();
            WeakReferenceMessenger.Default.RegisterAll(this);
        }

        private ShowCaseInstance DatabaseInstance;
        private Dictionary<int, string> newEntries;

        [ObservableProperty]
        private List<NameType> newItems;

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
            bool response = data.AddEntries(newEntries);
            return response;
        }


        public void Receive(CreateMultiMessage message)
        {
            int value = message.Value;
            NewItems = new List<NameType>();
            for (int i = 0; i < value; i++)
            {
                NewItems.Add(new NameType("Name " + i.ToString()));
            }
            WeakReferenceMessenger.Default.Send(new EditMultiMessage(true));
        }

        public void Receive(SaveCloseMessage message)
        {
            MultiSaveClose();
        }
    }
}
