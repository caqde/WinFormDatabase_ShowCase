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

namespace ShowCaseViewModel
{
    public partial class MainAddMultipleViewModel : ObservableObject, IRecipient<CreateMultiMessage>
    {
        public MainAddMultipleViewModel() 
        {
            DatabaseInstance = new ShowCaseInstance();
            NewItems = new List<Simple>();
            WeakReferenceMessenger.Default.Register<CreateMultiMessage>(this);
        }

        private ShowCaseInstance DatabaseInstance;
        private Dictionary<int, string> newEntries;

        [ObservableProperty]
        private List<Simple> newItems;

        [RelayCommand]
        private void MultiSave()
        {
            dbObjectModel data = DatabaseInstance.getDBObject();
            int x = 0;
            if (newEntries is not null && newEntries.Count > 0 && newItems is not null && newItems.Count > 0) 
            {
                List<int> keys = new List<int>(newEntries.Keys);
                foreach (var item in keys)
                {
                    newEntries[item] = newItems[x].Name;
                    x++;
                }
            }
            bool response = data.SaveEntries();
            WeakReferenceMessenger.Default.Send(new MultiSaveMessage(response));
        }

        public void Receive(CreateMultiMessage message)
        {
            int value = message.Value;
            NewItems = new List<Simple>();
            for (int i = 0; i < value; i++)
            {
                NewItems.Add(new Simple());
            }
            dbObjectModel data = DatabaseInstance.getDBObject();
            newEntries = data.AddEntries(value);
            WeakReferenceMessenger.Default.Send(new EditMultiMessage(true));
        }
    }
}
