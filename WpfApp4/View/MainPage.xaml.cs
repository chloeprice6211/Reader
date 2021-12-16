using Microsoft.Win32;
using reader.Controller;
using reader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace reader.View
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        VisualLibrary visualLibrary;
        public MainPage()
        {
            InitializeComponent();

            if (StoreLibrary.BooksToSell.Count == 0)
            {
            
            StoreLibrary.AddAllBooks(StoreLibrary.StorePath);
            }

            if (Library.myLibrary.Count == 0)
            {
                Library.AddAllBooks(Library.LibraryPath);
            }
            visualLibrary = new VisualLibrary();
            visualLibrary.init();

            listBooks.ItemsSource = visualLibrary.VisualBooks;

            //this.Height = SystemParameters.PrimaryScreenHeight * 0.95;
            //this.Width = SystemParameters.PrimaryScreenWidth * 0.95;
        }

        private void buttonView_Click(object sender, RoutedEventArgs e)
        {
            PopupWindow pw = new PopupWindow();
            pw.Owner = Application.Current.MainWindow;
            
            visualLibrary.selectedBook = ((Button)sender).Tag as VisualBook;
            pw.initPopup(visualLibrary.selectedBook);

            pw.Show();

        }

        private void buttonOpenFile_Click(object sender, RoutedEventArgs e)
        {
            PersistentBook book;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                book = new PersistentBook()
                {
                    Title = System.IO.Path.GetFileNameWithoutExtension(openFileDialog.FileName),
                    CoverPath = "../icons/google-docs.png",
                    ContentPath = openFileDialog.FileName
                };
                visualLibrary.VisualBooks.Add(new VisualBook
                {
                    persistentBook = book,
                    Cover = visualLibrary.createCover(book.CoverPath),
                    Content = visualLibrary.createContent(book.ContentPath),
                });
                listBooks.ItemsSource = visualLibrary.VisualBooks;
            }                 
        }

        private void buttonOpenShop_Click(object sender, RoutedEventArgs e)
        {
            ShopWindow shopWindow = new ShopWindow("light");
            shopWindow.Show();
        }

        private void buttonRead_Click(object sender, RoutedEventArgs e)
        {
            visualLibrary.selectedBook = ((Button)sender).Tag as VisualBook;

            MainWindow reader = new MainWindow(visualLibrary.selectedBook);
           // MainWindow reader = new MainWindow();

            
            reader.addBookToLibrary(visualLibrary.selectedBook);
            reader.Show();

            Close();
            //mainWindow.Show();
        }
    }
}
