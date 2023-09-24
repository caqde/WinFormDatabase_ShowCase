using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ShowCaseModel;
using ShowCaseModel.DataTypes.Library;
using ShowCaseModel.Models;
using ShowCaseViewModel.Messages.LibraryMessages;
using ShowCaseViewModel.Messages.Universal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseViewModel.Library
{
    public partial class LibraryPatronViewModel: ObservableObject
    {
        public LibraryPatronViewModel() 
        {
            ShowCaseInstance libraryInstance = ShowCaseInstance.Instance;
            data = libraryInstance.getLibrary();
            _ = data.GetPatronList().Match(pass => PatronList = pass, fail => PatronList = new List<PatronDto>());
            PatronBorrowedBooks = new List<BorrowedBookDto>();
        }

        private void RefreshPatronList()
        {
            _ = data.GetPatronList().Match(pass => PatronList = pass, fail => PatronList.Clear());
        }

        [ObservableProperty]
        private int selectedPatronID;

        private bool patronSelected = false;

        partial void OnSelectedPatronIDChanged(int value)
        {
            if (SelectedPatronID == -1)
            {
                newPatron = true;
                patronSelected = false;
                PatronName = string.Empty;
                PatronCity = string.Empty;
                PatronAddress = string.Empty;
                PatronBorrowedBooks.Clear();
                PatronPhoneNumber = string.Empty;
                PatronPostalCode = 0;
                patronChanged = false;
                return;
            }
            patronSelected = true;
        }

        private ILibrary data;

        private int currentPatronID = 0;
        private bool newPatron = false;
        private bool patronLoaded = false;
        private bool patronChanged = false;

        [ObservableProperty]
        private List<PatronDto> patronList;

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

        partial void OnPatronAddressChanged(string value)
        {
            PatronValueChanged();
        }

        partial void OnPatronCityChanged(string value)
        {
            PatronValueChanged();
        }

        partial void OnPatronNameChanged(string value)
        {
            PatronValueChanged();
        }

        partial void OnPatronPhoneNumberChanged(string value)
        {
            PatronValueChanged();
        }

        partial void OnPatronPostalCodeChanged(int value)
        {
            PatronValueChanged();
        }

        private void PatronValueChanged()
        {
            patronChanged = true;
        }

        [RelayCommand]
        private void addPatron()
        {
            if (!newPatron)
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(new Exception("A New Patron is not selected")));
                return;
            }
            if (!patronChanged)
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(new Exception("Please fill out the fields before adding")));
                return;
            }
            if (PatronAddress == string.Empty || PatronName == string.Empty || PatronPhoneNumber ==  string.Empty || PatronPostalCode <= 0 || patronCity == string.Empty) 
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(new Exception("Please fill out the empty fields")));
                return;
            }
            PatronDto PatronDto = new PatronDto() { City = PatronCity, Name = PatronName, PhoneNumber = PatronPhoneNumber, PostalCode = PatronPostalCode, StreetAddress = PatronAddress };
            data.AddPatron(PatronDto).Match(pass => AddPatronData(pass), fail => WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(fail)));
        }

        private void AddPatronData(bool pass)
        {
            WeakReferenceMessenger.Default.Send<LibraryAddItem>(new LibraryAddItem(pass));
            RefreshPatronList();
        }

        [RelayCommand]
        private void getPatron()
        {
            if (!patronSelected)
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(new Exception("Please select a Patron first")));
                return;
            }
            PatronDto? patron = null;
            Exception? exception = null;
            data.GetPatron(SelectedPatronID).Match(pass => patron = pass, fail => exception = fail);
            if (patron is null)
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(exception));
                return;
            }
            PatronAddress = patron.StreetAddress;
            PatronName = patron.Name;
            currentPatronID = patron.Id;
            PatronPostalCode = patron.PostalCode;
            PatronPhoneNumber = patron.PhoneNumber;
            PatronCity = patron.City;
            _ = data.GetBorrowedBooksByPatron(patron.Id).Match(pass => PatronBorrowedBooks = pass, fail => PatronBorrowedBooks.Clear());
            patronLoaded = true;
            patronChanged = false;
            WeakReferenceMessenger.Default.Send<LibraryGetItem>(new LibraryGetItem(true));
        }

        [RelayCommand]
        private void updatePatron()
        {
            if (!patronLoaded)
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(new Exception("Can not update no Patron Loaded")));
                return;
            }
            if (!patronChanged)
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(new Exception("Please make a change before trying to update")));
                return;
            }
            PatronDto patron = new PatronDto() { Name = PatronName, City = PatronCity, Id = currentPatronID, PhoneNumber = PatronPhoneNumber, PostalCode = PatronPostalCode, StreetAddress = PatronAddress };
            data.UpdatePatron(patron).Match(Pass => WeakReferenceMessenger.Default.Send<LibraryUpdateItem>(new LibraryUpdateItem(Pass)),
                                            Fail => WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(Fail)));
        }

        [RelayCommand]
        private void removePatron()
        {
            if (!patronSelected)
            {
                WeakReferenceMessenger.Default.Send(new ExceptionMessage(new Exception("No Patron Selected for removal")));
                return;
            }

            data.RemovePatron(selectedPatronID).Match(Pass => RemovePatronData(Pass),
                                                      Fail => WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(Fail)));
        }

        private void RemovePatronData(bool pass)
        {
            if (SelectedPatronID == currentPatronID)
            {
                patronLoaded = false;
                PatronName = string.Empty;
                PatronCity = string.Empty;
                PatronAddress = string.Empty;
                PatronBorrowedBooks.Clear();
                PatronPhoneNumber = string.Empty;
                PatronPostalCode = 0;
                patronChanged = false;
            }
            WeakReferenceMessenger.Default.Send<LibraryRemoveItem>(new LibraryRemoveItem(pass));
        }
    }
}
