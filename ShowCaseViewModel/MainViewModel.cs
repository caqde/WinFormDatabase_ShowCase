using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ShowCaseViewModel.Messages.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel() 
        { 
        }

        [RelayCommand]
        private void LoadMainView()
        {
            WeakReferenceMessenger.Default.Send<LaunchSingleDatabaseViewMessage>(new LaunchSingleDatabaseViewMessage(true));
        }

        [RelayCommand]
        private void LoadLibraryView() 
        {
            WeakReferenceMessenger.Default.Send<LaunchLibraryDatabaseMessage>(new LaunchLibraryDatabaseMessage(true));
        }
    }
}
