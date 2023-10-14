﻿using ShowCaseViewModel.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFView.Library
{
    /// <summary>
    /// Interaction logic for LibraryBook.xaml
    /// </summary>
    public partial class LibraryBook : Window
    {
        public LibraryBook()
        {
            InitializeComponent();
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            var context = DataContext as LibraryBookViewModel;
            context.SelectedBookID = -1;
        }
    }
}
