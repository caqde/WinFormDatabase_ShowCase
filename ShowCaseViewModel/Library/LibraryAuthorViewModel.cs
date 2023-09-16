﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShowCaseModel.DataTypes.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseViewModel.Library
{
    public partial class LibraryAuthorViewModel: ObservableObject
    {
        private bool newAuthor = false;

        [ObservableProperty]
        private int selectedAuthorID;

        private bool authorSelected;

        partial void OnSelectedAuthorIDChanged(int value)
        {
            authorSelected = true;
        }

        [ObservableProperty]
        private List<AuthorDto> authorList;

        [ObservableProperty]
        private List<BookDto> authorBookList;

        [ObservableProperty]
        private string authorName;

        [ObservableProperty]
        private string authorBiography;

        [RelayCommand]
        private void addAuthor()
        {

        }

        [RelayCommand]
        private void getAuthor()
        {

        }

        [RelayCommand]
        private void updateAuthor()
        {

        }

        [RelayCommand]
        private void removeAuthor()
        {

        }

    }
}
