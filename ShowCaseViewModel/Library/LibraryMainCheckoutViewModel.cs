using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShowCaseModel;
using ShowCaseModel.DataTypes.Library;
using ShowCaseModel.Models;
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
            ILibrary data = DatabaseInstance.getLibrary();
            _ = data.GetBookList().Match(pass => bookList = new BindingList<BookDto>(pass), fail => bookList = new BindingList<BookDto>());
            _ = data.GetPatronList().Match(pass => patronList = new BindingList<PatronDto>(pass), fail => patronList = new BindingList<PatronDto>());
            _ = data.GetBorrowedBooksList().Match(pass => borrowedBookList = new BindingList<BorrowedBookDto>(pass), fail => borrowedBookList = new BindingList<BorrowedBookDto>());
            RemoveBorrowedBooksFromList();
        }

        private void RemoveBorrowedBooksFromList()
        {
            foreach (var book in BorrowedBookList) 
            {
                bookList.Remove(book.BorrowedBook);
            }
        }

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
        private BindingList<BookDto> bookList;
        [ObservableProperty]
        private BindingList<PatronDto> patronList;
        [ObservableProperty]
        private BindingList<BorrowedBookDto> borrowedBookList;

        [RelayCommand]
        private void borrowBook()
        {

        }

        [RelayCommand]
        private void returnBook()
        {

        }
    }
}
