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
    public partial class LibraryPublisherViewModel: ObservableObject
    {
        public LibraryPublisherViewModel() 
        {
            ShowCaseInstance libraryInstance = ShowCaseInstance.Instance;
            data = libraryInstance.getLibrary();
            _ = data.GetPublisherList().Match(pass => PublisherList = pass, fail => PublisherList = new List<PublisherDto>());
            PublisherBooks = new List<BookDto>();
        }

        private void RefreshPublisherList()
        {
            _ = data.GetPublisherList().Match(pass => PublisherList = pass, fail => PublisherList.Clear());
        }

        private ILibrary data;


        [ObservableProperty]
        private int selectedPublisherID;

        private bool publisherSelected;

        partial void OnSelectedPublisherIDChanged(int value)
        {
            if (selectedPublisherID == -1)
            {
                newPublisher = true;
                publisherSelected = false;
                PublisherName = string.Empty;
                PublisherDescription = string.Empty;
                PublisherBooks.Clear();
                publisherChanged = false;
                return;
            }
            publisherSelected = true;
        }

        private int currentPublisherID = 0;
        private bool newPublisher = false;
        private bool publisherLoaded = false;
        private bool publisherChanged = false;


        [ObservableProperty]
        private List<PublisherDto> publisherList;

        [ObservableProperty]
        private string publisherName;

        [ObservableProperty]
        private string publisherDescription;

        [ObservableProperty]
        private List<BookDto> publisherBooks;

        partial void OnPublisherNameChanged(string value)
        {
            PublisherValueChanged();
        }

        partial void OnPublisherDescriptionChanged(string value)
        {
            PublisherValueChanged();
        }

        private void PublisherValueChanged()
        {
            publisherChanged = true;
        }

        [RelayCommand]
        private void addPublisher()
        {
            if (!newPublisher)
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(new Exception("A Publisher is not selected")));
                return;
            }
            if (!publisherChanged)
            {
                WeakReferenceMessenger.Default.Send(new ExceptionMessage(new Exception("Please fill out the fields before adding")));
                return;
            }
            if (PublisherDescription == string.Empty || PublisherName == string.Empty)
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(new Exception("Please fill out the empty fields before adding")));
                return;
            }
            PublisherDto publisherDto = new PublisherDto() { Description = PublisherDescription, Name = PublisherName };
            data.AddPublisher(publisherDto).Match(pass => AddPublisherData(pass), fail => WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(fail)));
        }

        private void AddPublisherData(bool pass)
        {
            WeakReferenceMessenger.Default.Send<LibraryAddItem>(new LibraryAddItem(pass));
            RefreshPublisherList();
        }

        [RelayCommand]
        private void getPublisher()
        {
            if (!publisherSelected)
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(new Exception("Please select a Publisher first")));
                return;
            }
            PublisherDto? publisherDto = null;
            Exception? exception = null;
            data.GetPublisher(selectedPublisherID).Match(pass => publisherDto = pass, fail => exception = fail);
            if (exception != null)
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(exception));
                return;
            }
            PublisherDescription = publisherDto.Description;
            PublisherName = publisherDto.Name;
            currentPublisherID = publisherDto.Id;
            _ = data.GetPublisherBooks(currentPublisherID).Match(pass => PublisherBooks = pass, fail => PublisherBooks.Clear());
            publisherLoaded = true;
            publisherChanged = false;
            WeakReferenceMessenger.Default.Send<LibraryGetItem>(new LibraryGetItem(true));
        }

        [RelayCommand]
        private void removePublisher() 
        {
            if (!publisherSelected)
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(new Exception("No Publisher selected for removal")));
                return;
            }
            data.RemovePublisher(selectedPublisherID).Match(Pass => RemovePublisherData(Pass),
                                                            Fail => WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(Fail)));
        }

        private void RemovePublisherData(bool pass)
        {
            if (SelectedPublisherID == currentPublisherID)
            {
                publisherLoaded = false;
                PublisherBooks.Clear();
                PublisherDescription = string.Empty; 
                PublisherName = string.Empty;
                publisherChanged = false;
            }
            WeakReferenceMessenger.Default.Send<LibraryRemoveItem>(new LibraryRemoveItem(pass));
        }

        [RelayCommand]
        private void updatePublisher() 
        {
            if (!publisherLoaded)
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(new Exception("No Publisher is loaded for updating")));
                return;
            }
            if (!publisherChanged)
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(new Exception("No changes have been made")));
                return;
            }
            PublisherDto publisher = new PublisherDto() { Description = PublisherDescription, Id = currentPublisherID, Name = PublisherName };
            data.UpdatePublisher(publisher).Match(Pass => WeakReferenceMessenger.Default.Send<LibraryUpdateItem>(new LibraryUpdateItem(Pass))
                                                , Fail => WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(Fail)));
        }
    }
}
