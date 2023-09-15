using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShowCaseModel.DataTypes.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseViewModel.Library
{
    public partial class LibraryPublisherViewModel: ObservableObject
    {
        [ObservableProperty]
        private List<PublisherDto> publishers;

        [ObservableProperty]
        private string publisherName;

        [ObservableProperty]
        private string publisherDescription;

        [ObservableProperty]
        private List<BookDto> publisherBooks;

        [RelayCommand]
        private void addPublisher()
        {

        }

        [RelayCommand]
        private void getPublisher(int publisherID)
        {

        }

        [RelayCommand]
        private void removePublisher() 
        {
        }

        [RelayCommand]
        private void updatePublisher() 
        {
        }
    }
}
