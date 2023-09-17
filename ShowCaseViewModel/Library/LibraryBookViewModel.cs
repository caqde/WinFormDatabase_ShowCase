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
    public partial class LibraryBookViewModel : ObservableObject
    {
        public LibraryBookViewModel()
        {
            ShowCaseInstance libraryInstance = ShowCaseInstance.Instance;
            data = libraryInstance.getLibrary();
            _ = data.GetBookList().Match(pass => books = pass, fail => books = new List<BookDto>());
            _ = data.GetAuthorList().Match(pass => authors = pass, fail => authors = new List<AuthorDto>());
            _ = data.GetPublisherList().Match(pass => publishers = pass, fail => publishers = new List<PublisherDto>());
        }

        private ILibrary data;

        private bool newBook = false;

        private bool bookChanged = false;

        [ObservableProperty]
        private int selectedBookID;

        [ObservableProperty]
        private int selectedAuthorID;

        [ObservableProperty]
        private int selectedPublisherID;

        private bool authorSelected = false;
        private bool bookSelected = false;
        private bool publisherSelected = false;

        partial void OnSelectedAuthorIDChanged(int value)
        {
            authorSelected = true;
        }

        partial void OnSelectedBookIDChanged(int value)
        {
            bookChanged = false;
            if (value == -1)
            {
                authorSelected = false;
                publisherSelected = false;
                newBook = true;
                bookSelected = false;
                ISBN = 0;
                Description = "";
                Title = "";
                return;
            }
            bookSelected = true;
        }

        partial void OnSelectedPublisherIDChanged(int value)
        {
            publisherSelected = true;
        }

        private int currentBookID;

        [ObservableProperty]
        private List<BookDto> books;

        [ObservableProperty]
        private List<AuthorDto> authors;

        [ObservableProperty]
        private List<PublisherDto> publishers;

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private int iSBN;

        [ObservableProperty]
        private int authorID;

        [ObservableProperty]
        private int publisherID;

        [ObservableProperty]
        private int borrowedID;

        partial void OnAuthorIDChanged(int value)
        {
            bookValueChanged();
        }

        partial void OnPublisherIDChanged(int value)
        {
            bookValueChanged();
        }

        partial void OnISBNChanged(int value)
        {
            bookValueChanged();
        }

        partial void OnDescriptionChanged(string value)
        {
            bookValueChanged();
        }

        partial void OnTitleChanged(string value)
        {
            bookValueChanged();
        }


        private void bookValueChanged()
        {
            bookChanged = true;
        }

        [RelayCommand]
        private void getBook()
        {
            if (!bookSelected) return;
            BookDto? book = null;
            Exception? exception = null;
            data.GetBook(SelectedBookID).Match(pass => book = pass, fail => exception = fail);
            if (exception is not null)
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(exception));
                return;
            }
            Title = book.Title;
            Description = book.Description;
            currentBookID = book.Id;
            ISBN = book.ISBN;
            AuthorID = book.authorID;
            PublisherID = book.publisherID;
            WeakReferenceMessenger.Default.Send<LibraryGetItem>(new LibraryGetItem(true));
        }

        [RelayCommand]
        private void addBook()
        {
            if (!newBook)
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(new Exception("This command should not be click-able, a new book is not selected")));
                return;
            }
                
            if (!authorSelected || !publisherSelected)
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(new Exception("An Author and Publisher needs to be selected")));
                return;
            }
            if (Description == "" || ISBN == 0 || Title == "")
            {
                WeakReferenceMessenger.Default.Send(new ExceptionMessage(new Exception("Please fill out all fields")));
                return;
            }
            BookDto book = new BookDto() { Description = Description, authorID = AuthorID, ISBN = ISBN, publisherID = PublisherID, Title = Title };
            data.AddBook(book).Match(pass => WeakReferenceMessenger.Default.Send<LibraryAddItem>(new LibraryAddItem(pass)) 
                                , Fail => WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(Fail)));
        }

        [RelayCommand]
        private void removeBook()
        {
            if (!bookSelected)
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(new Exception("Book not selected")));
                return;
            }
            data.RemoveBook(selectedBookID).Match(Pass => WeakReferenceMessenger.Default.Send<LibraryRemoveItem>(new LibraryRemoveItem(Pass)),
                                                  Fail => WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(Fail)));
        }

        [RelayCommand]
        private void updateBook()
        {

        }
    }
}
