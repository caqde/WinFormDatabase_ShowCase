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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseViewModel.Library
{
    public partial class LibraryMainCheckoutViewModel: ObservableObject
    {
        public LibraryMainCheckoutViewModel() 
        {
            DatabaseInstance = ShowCaseInstance.Instance;
            data = DatabaseInstance.getLibrary();
            _ = data.GetBookList().Match(pass => bookList = pass, fail => bookList = new List<BookDto>());
            _ = data.GetPatronList().Match(pass => patronList = pass, fail => patronList = new List<PatronDto>());
            _ = data.GetBorrowedBooksList().Match(pass => borrowedBookList = pass, fail => borrowedBookList = new List<BorrowedBookDto>());
            RemoveBorrowedBooksFromList();
        }

        private void RefreshBorrowedBookList()
        {
            _ = data.GetBorrowedBooksList().Match(pass => BorrowedBookList = pass, fail => BorrowedBookList.Clear());
        }

        private void RemoveBorrowedBooksFromList()
        {
            foreach (var book in BorrowedBookList) 
            {
                BookList.Remove(book.BorrowedBook);
            }
        }

        private ILibrary data;

        [ObservableProperty]
        private int selectedBook;

        [ObservableProperty]
        private int selectedPatron;

        [ObservableProperty]
        private int selectedBorrowedBook;

        private bool patronSelected = false;
        private bool bookSelected = false;
        private bool borrowedBookSelected = false;

        partial void OnSelectedBookChanged(int value)
        {
            if (value < 0)
            {
                bookSelected = false;
                return;
            }
            bookSelected = true;
        }

        partial void OnSelectedBorrowedBookChanged(int value)
        {
            borrowedBookSelected = true;
        }

        partial void OnSelectedPatronChanged(int value)
        {
            patronSelected = true;
        }


        private ShowCaseInstance DatabaseInstance;

        [ObservableProperty]
        private List<BookDto> bookList;
        [ObservableProperty]
        private List<PatronDto> patronList;
        [ObservableProperty]
        private List<BorrowedBookDto> borrowedBookList;

        [RelayCommand]
        private void borrowBook()
        {
            if (!bookSelected && !patronSelected)
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(new Exception("Please select a book and patron")));
                return;
            }
            if (!bookSelected) 
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(new Exception("Please select a book to borrow")));
                return;
            }
            if (!patronSelected)
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(new Exception("Please select a patron to borrow the book")));
                return;
            }
            data.BorrowBook(SelectedPatron, SelectedBook, TimeSpan.FromDays(7)).Match(pass => BorrowBookRefresh(pass),
                                                                                    fail => WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(fail)));
        }

        private void BorrowBookRefresh(bool pass)
        {
            WeakReferenceMessenger.Default.Send<LibraryBorrowBook>(new LibraryBorrowBook(pass));
            RefreshBorrowedBookList();
        }

        [RelayCommand]
        private void returnBook()
        {
            if (!borrowedBookSelected)
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(new Exception("Select a book to be returned")));
                return;
            }
            data.RemoveBorrowedBook(SelectedBorrowedBook).Match(pass => ReturnBookRefresh(pass),
                                                                fail => WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(fail)));
        }

        private void ReturnBookRefresh(bool pass)
        {
            WeakReferenceMessenger.Default.Send<LibraryReturnBook>(new LibraryReturnBook(pass));
            RefreshBorrowedBookList();
        }

        [RelayCommand]
        private void reBorrowBook()
        {
            if (!borrowedBookSelected) 
            {
                WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(new Exception("Select a book to extend the borrow time on")));
                return;
            }

            data.UpdateBorrowedBook(BorrowedBookList[SelectedBorrowedBook]).Match(pass => WeakReferenceMessenger.Default.Send<LibraryReBorrowBook>(new LibraryReBorrowBook(pass))
                                                                                 , fail => WeakReferenceMessenger.Default.Send<ExceptionMessage>(new ExceptionMessage(fail)));
        }
    }
}
