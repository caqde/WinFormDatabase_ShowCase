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
using WPFView.Library;
using WPFView.SingleAttribute;

namespace WPFView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum PageTable
        {
            SingleAttribute,
            Library
        }

        private Dictionary<Type, Page> PageList = new Dictionary<Type, Page>();
        private Dictionary<Type, PageTable> PageTypeList = new Dictionary<Type, PageTable>() { { typeof(SingleAttributeMain), PageTable.SingleAttribute },
                                                                                                { typeof(LibraryMain), PageTable.Library } };

        public MainWindow()
        {
            InitializeComponent();
        } 

        private bool CheckPage(PageTable type)
        {
            if (PageFrame.Content is not null)
            {
                Type PageFrameType = PageFrame.Content.GetType();
                if (!PageTypeList.ContainsKey(PageFrameType))
                {
                    return false;
                }
                if (PageTypeList[PageFrameType] == type)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        private void LoadPage(Type type)
        {
            if (PageList.ContainsKey(type))
            {
                PageFrame.Content = PageList[type];
                return;
            }
            PageTable tableType = PageTypeList[type];
            Page? page = null;
            switch (tableType)
            {
                case PageTable.SingleAttribute:
                    page = new SingleAttributeMain();
                    break;
                case PageTable.Library:
                    page = new LibraryMain();
                    break;
                default:
                    return;
            }
            PageList.Add(type, page);
            PageFrame.Content = page;
        }

        private void SingleAttribute_Click(object sender, RoutedEventArgs e)
        {
            if (CheckPage(PageTable.SingleAttribute))
            {
                return;
            } 
            LoadPage(typeof(SingleAttributeMain));
        }

        private void LibraryButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckPage(PageTable.Library))
            {
                return;
            }
            LoadPage(typeof(LibraryMain));    
        }
    }
}
