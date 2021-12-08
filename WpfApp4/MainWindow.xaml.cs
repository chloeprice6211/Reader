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
using System.IO;
using Microsoft.Win32;

namespace reader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///

    public partial class MainWindow : Window
    {   string text;
       
        static bool isDark = false;

        public MainWindow()
        {
            InitializeComponent();
            #region windowCustomization
            Title = "Reader";
            Uri iconUri = new Uri(@"..\..\..\icons\mainWindowIcon.ico", UriKind.RelativeOrAbsolute);
            Icon = BitmapFrame.Create(iconUri);
            MaxWidth = 1200;
            #endregion

            StoreLibrary.AddAllBooks(StoreLibrary.StorePath);
            Library.AddAllBooks(Library.LibraryPath);
            AddLibraryBooksToComboBox();
            mainFlowDoc.IsScrollViewEnabled = true;
            LibraryBooksComboBox.FontFamily = new FontFamily("Calibri");
            LibraryBooksComboBox.FontSize = 20;

            Book test1 = new Book(@"..\..\..\books\StoreLibraryBooks\Harry_Potter.txt");
            
            SetContent(test1);
        }

        private void SetContent(Book item)
        {
            //myParagraph.Inlines.Clear();
            //myParagraph.Inlines.Add(new Run(item.Content));

            FlowDocument flowdoc = new FlowDocument();
            Paragraph pg = new Paragraph(new Run(item.Content));
            pg.FontFamily = new FontFamily("Calibri");
            pg.FontSize = 24;
            
            mainFlowDoc.Document = flowdoc;
            flowdoc.Blocks.Add(pg);

            CurrentBookName.Content = item.Name;
            LibraryBooksComboBox.Text = item.Name;
        }
        private void DotsClick(object sender, RoutedEventArgs e)
        {
            HideControlElements();
        }
        private void HideControlElements()
        {
            if (menuGrid.Visibility == Visibility.Collapsed)
            {
                menuGrid.Visibility = Visibility.Visible;
                LibraryBooksComboBox.Visibility = Visibility.Visible;
                CurrentBookName.Visibility = Visibility.Collapsed;
                themeImage.Visibility = Visibility.Visible;
                fontImage.Visibility = Visibility.Visible;
                UpperMenu.Visibility = Visibility.Visible;
                mainFlowDoc.Height -= 125;
            }
            else
            {
                mainFlowDoc.Height += 125;
                menuGrid.Visibility = Visibility.Collapsed;
                LibraryBooksComboBox.Visibility = Visibility.Collapsed;
                UpperMenu.Visibility = Visibility.Collapsed;
                themeImage.Visibility = Visibility.Hidden;
                fontImage.Visibility = Visibility.Hidden;
                CurrentBookName.Visibility = Visibility.Visible;

            }
        }
        private void FontClick(object sender, RoutedEventArgs e)
        {
            FlowDocumentReaderViewingMode viewingMode;
            Paragraph my = mainFlowDoc.Document.Blocks.ElementAt(0) as Paragraph;
            viewingMode = mainFlowDoc.ViewingMode;

            FontDialogWindow newWindow = new FontDialogWindow(my,viewingMode);
            TextProperties newStyle;

            newWindow.ShowDialog();
           newStyle = new TextProperties(newWindow.exampleText);
            newStyle.SetParagraphStyle(my);
            mainFlowDoc.ViewingMode = newWindow.ViewMode;
        }

        private void ThemeClick(object sender, RoutedEventArgs e)
        {
            if (isDark == false)
            {
                mainFlowDoc.Foreground = Brushes.White;
                Background = (Brush)new BrushConverter().ConvertFrom("#171717");
                fontImage.Source = new BitmapImage(new Uri(@"\mainMenuIcons\upperMenuIcons\fontCustomizationIconLight.png", UriKind.RelativeOrAbsolute));
                themeImage.Source = new BitmapImage(new Uri(@"\mainMenuIcons\upperMenuIcons\lightThemeIcon.png", UriKind.Relative));
                DotsButton.Foreground = Brushes.White;
                isDark = true;
                return;
            }
            else
            {
                mainFlowDoc.Foreground = Brushes.Black;
                Background = Brushes.White;
                fontImage.Source = new BitmapImage(new Uri(@"\mainMenuIcons\upperMenuIcons\fontCustomizationIconDark.png", UriKind.RelativeOrAbsolute));
                themeImage.Source = new BitmapImage(new Uri(@"\mainMenuIcons\upperMenuIcons\darkThemeIcon.png", UriKind.Relative));
            
                DotsButton.Foreground = Brushes.Black;
                isDark = false;
            }



        }
        private void MenuButtonHoverEnter(object sender, MouseEventArgs e)
        {
            foreach (object child in (sender as StackPanel).Children)
            {
                if (child is Label)
                {
                    (child as Label).FontSize += 8;
                }
                else if (child is Image)
                {
                    (child as Image).Height -= 20;
                }
            }
        }
        private void MenuButtonHoverLeave(object sender, MouseEventArgs e)
        {
            foreach (object child in (sender as StackPanel).Children)
            {
                if (child is Label)
                {
                    (child as Label).FontSize -= 8;
                }
                else if (child is Image)
                {
                    (child as Image).Height += 20;
                }
            }
        }
        private void FontCustomizationHoverEnter(object sender, MouseEventArgs e)
        {
            (sender as Button).BorderBrush = Brushes.Black;
            (sender as Button).BorderThickness = new Thickness(1);
        }
        private void AddLibraryBooksToComboBox()
        {
            BookComboBoxItem bookItem;
            
            bool IsListed;

            if (LibraryBooksComboBox.Items.Count == 0)
            {
                for (int a = 0; a < Library.myLibrary.Count; a++)
                {
                    bookItem = new BookComboBoxItem();
                    bookItem.FontFamily = new FontFamily("Calibri");
                    bookItem.FontSize = 17;
                    bookItem.BindedBook = Library.myLibrary[a];
                    bookItem.Content = bookItem.BindedBook.Name;
                    LibraryBooksComboBox.Items.Add(bookItem);
                  

                   
                }
            }
            else
            {
                foreach (Book item in Library.myLibrary)
                {
                    IsListed = false;
               
                    foreach(BookComboBoxItem bookItem1 in LibraryBooksComboBox.Items)
                        {
                            if(bookItem1.BindedBook.Name == item.Name)
                            {
                                IsListed = true;
                            }
                        }
                    
                    if (IsListed == false)
                    {
                        bookItem = new();
                        bookItem.BindedBook = item;
                        bookItem.Content = bookItem.BindedBook.Name;
                        LibraryBooksComboBox.Items.Add(bookItem);
                    }
                }

            }
        }
        private void OnLIbraryButtonClick(object sender, RoutedEventArgs e)
        {
            
         }

        private void OnShopButtonClick(object sender, RoutedEventArgs e)
        {
            HideControlElements();
            //mainFlowDoc.Height += 100;
            ShopWindow shopwin = new ShopWindow();
            shopwin.ShowDialog();
            
            if (shopwin.BookToRead != null)
            {
                SetContent(shopwin.BookToRead);
            }
            AddLibraryBooksToComboBox();
            
        }
        private void OnProgresButtonClick(object sender, RoutedEventArgs e)
        {
            HideControlElements();
            Achievement ach = new Achievement();
            ach.ShowDialog();
        }
            private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sf =new() ;
            sf.ShowDialog();
            Filesave(text);
            MessageBox.Show("a");
        }
        void Filesave(string textbuf)
        {
             string writePath = @"C:book.txt";
           
        
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(textbuf);
                }
 
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine("Дозапись");
                    sw.Write(4.5);
                }
               MessageBox.Show("Запись выполнена");
            }
            catch (Exception e)
               {
              Console.WriteLine(e.Message);
               }
            
        }
        private void BookChanging(object sender, EventArgs e)
        {
            Book toSet;

            toSet = ((BookComboBoxItem)((ComboBox)sender).Items[((ComboBox)sender).SelectedIndex]).BindedBook;
            SetContent(toSet);

            HideControlElements();
          
        }
    }
}
