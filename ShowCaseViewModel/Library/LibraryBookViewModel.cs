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
    public partial class LibraryBookViewModel: ObservableObject
    {
        private bool newBook = false;

        [ObservableProperty]
        private int selectedBookID;

        [ObservableProperty]
        private int selectedAuthorID;

        [ObservableProperty]
        private int selectedPublisherID;

        private bool authorSelected;
        private bool bookSelected;
        private bool publisherSelected;

        partial void OnSelectedAuthorIDChanged(int value)
        {
            authorSelected = true;
        }

        partial void OnSelectedBookIDChanged(int value)
        {
            bookSelected = true;
        }

        partial void OnSelectedPublisherIDChanged(int value)
        {
            publisherSelected = true;
        }


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
        private int authorID;

        [ObservableProperty]
        private int publisherID;

        [ObservableProperty]
        private int borrowedID;

        [RelayCommand]
        private void getBook(int bookID)
        {

        }

        [RelayCommand]
        private void addBook()
        {

        }

        [RelayCommand]
        private void removeBook()
        {

        }

        [RelayCommand]
        private void updateBook()
        {

        }
    }
}
