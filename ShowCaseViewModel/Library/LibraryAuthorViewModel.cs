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
    public partial class LibraryAuthorViewModel: ObservableObject
    {
        public LibraryAuthorViewModel() 
        {
            ShowCaseInstance libraryInstance = ShowCaseInstance.Instance;
            data = libraryInstance.getLibrary();
            _ = data.GetAuthorList().Match(pass => AuthorList = pass, fail => AuthorList = new List<AuthorDto>());
        }

        private void RefreshAuthorList()
        {
            _= data.GetAuthorList().Match(pass => AuthorList = pass, fail => AuthorList.Clear());
        }

        private int currentAuthorID = 0;
        private bool newAuthor = false;
        private bool authorLoaded = false;
        private bool authorChanged = false;

        private ILibrary data;

        [ObservableProperty]
        private int selectedAuthorID;

        private bool authorSelected = false;

        partial void OnSelectedAuthorIDChanged(int value)
        {
            if (SelectedAuthorID == -1)
            {
                newAuthor = true;
                authorSelected = false;
                AuthorName = string.Empty;
                AuthorBiography = string.Empty;
                currentAuthorID = -1;
                authorChanged = false;
                return;
            }
            authorSelected = true;
        }

        private void AuthorValueChanged()
        {
            authorChanged = true;
        }

        [ObservableProperty]
        private List<AuthorDto> authorList;

        [ObservableProperty]
        private List<BookDto> authorBookList;

        [ObservableProperty]
        private string authorName;

        [ObservableProperty]
        private string authorBiography;

        partial void OnAuthorBiographyChanged(string value)
        {
            AuthorValueChanged();
        }

        partial void OnAuthorNameChanged(string value)
        {
            AuthorValueChanged();
        }

        [RelayCommand]
        private void addAuthor()
        {
            if (!newAuthor)
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(new Exception("A New Author is not selected")));
                return;
            }
            if (!authorChanged)
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(new Exception("Please fill out the fields before attempting to add the Author")));
                return;
            }
            if (AuthorName == string.Empty || AuthorBiography == string.Empty)
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(new Exception("Please fill out the empty field before adding")));
                return;
            }
            AuthorDto author = new AuthorDto() { Biography = AuthorBiography, Name = AuthorName };
            data.AddAuthor(author).Match(pass => AddAuthorData(pass), fail => WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(fail)));
        }

        private void AddAuthorData(bool pass)
        {
            WeakReferenceMessenger.Default.Send<LibraryAddItem>(new LibraryAddItem(pass));
            RefreshAuthorList();
        }

        [RelayCommand]
        private void getAuthor()
        {
            if (!authorSelected) 
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(new Exception("Please select an Author")));
                return;
            }
            AuthorDto? author = null;
            Exception? exception = null;
            data.GetAuthor(SelectedAuthorID).Match(pass => author = pass, fail => exception = fail);
            if (author is null)
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(exception));
                return;
            }
            AuthorBiography = author.Biography;
            AuthorName = author.Name;
            currentAuthorID = author.Id;
            _ = data.GetAuthorBooks(currentAuthorID).Match(pass => AuthorBookList = pass, fail => AuthorBookList = new List<BookDto>());
            authorLoaded = true;
            authorChanged = false;
            WeakReferenceMessenger.Default.Send<LibraryGetItem>(new LibraryGetItem(true));
        }

        [RelayCommand]
        private void updateAuthor()
        {
            if (!authorLoaded)
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(new Exception("Can not update no Author loaded on form")));
                return;
            }
            if (!authorChanged) 
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(new Exception("Make a change before calling update")));
                return;
            }
            AuthorDto author = new AuthorDto() { Name = AuthorName, Biography = AuthorBiography, Id = currentAuthorID  };
            data.UpdateAuthor(author).Match(Pass => WeakReferenceMessenger.Default.Send<LibraryUpdateItem>(new LibraryUpdateItem(Pass)),
                                            Fail => WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(Fail)));
        }

        [RelayCommand]
        private void removeAuthor()
        {
            if (!authorSelected)
            {
                WeakReferenceMessenger.Default.Send(new ExceptionMessage(new Exception("Author not Selected")));
                return;
            }

            data.RemoveAuthor(SelectedAuthorID).Match(Pass => RemoveAuthorData(Pass),
                                                      Fail => WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(Fail)));
        }

        private void RemoveAuthorData(bool Pass)
        {
            if (SelectedAuthorID == currentAuthorID)
            {
                authorLoaded = false;
                AuthorName = string.Empty;
                AuthorBiography = string.Empty;
                authorChanged = false;
            }
            WeakReferenceMessenger.Default.Send<LibraryRemoveItem>(new LibraryRemoveItem(Pass));
            RefreshAuthorList();
        }
    }
}
