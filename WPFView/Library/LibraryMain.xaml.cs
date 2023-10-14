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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFView.Library
{
    /// <summary>
    /// Interaction logic for LibraryMain.xaml
    /// </summary>
    public partial class LibraryMain : Page
    {
        public LibraryMain()
        {
            InitializeComponent();
        }

        private void Authors_Click(object sender, RoutedEventArgs e)
        {
            LibraryAuthor authorWindow = new LibraryAuthor();
            authorWindow.Show();
        }

        private void Books_Click(object sender, RoutedEventArgs e)
        {
            LibraryBook bookWindow = new LibraryBook();
            bookWindow.Show();
        }

        private void Patron_Click(object sender, RoutedEventArgs e)
        {
            LibraryPatron patronWindow = new LibraryPatron();
            patronWindow.Show();
        }

        private void Publisher_Click(object sender, RoutedEventArgs e)
        {
            LibraryPublisher publisherWindow = new LibraryPublisher();
            publisherWindow.Show();
        }
    }
}
