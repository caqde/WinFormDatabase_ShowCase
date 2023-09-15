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
    public partial class LibraryPatronViewModel: ObservableObject
    {
        [ObservableProperty]
        private List<PatronDto> patrons;

        [ObservableProperty]
        private string patronName;

        [ObservableProperty]
        private string patronAddress;

        [ObservableProperty]
        private string patronCity;

        [ObservableProperty]
        private int patronPostalCode;

        [ObservableProperty]
        private string patronPhoneNumber;

        [ObservableProperty]
        private List<BorrowedBookDto> patronBorrowedBooks;

        [RelayCommand]
        private void addPatron()
        {
        }

        [RelayCommand]
        private void getPatron(int patronId)
        {

        }

        [RelayCommand]
        private void updatePatron()
        {

        }

        [RelayCommand]
        private void removePatron()
        {

        }
    }
}
