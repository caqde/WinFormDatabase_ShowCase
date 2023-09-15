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
