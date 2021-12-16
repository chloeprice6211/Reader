using System;
using System.Collections.Generic;
using System.Linq;
using reader.View;
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
using System.Windows.Media.Animation;
using System.IO;
using Microsoft.Win32;
using System.Windows.Threading;
using reader.Model;

namespace reader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///


    public partial class MainWindow : Window
    { string text;

        static bool isHidden = true;
        static bool isDark = false;
        string currentTheme = "light";
        DispatcherTimer timer;

        public MainWindow(VisualBook bookItem)
        {
            InitializeComponent();
            #region windowCustomization
            Title = "Reader";
            Uri iconUri = new Uri(@"..\..\..\icons\mainWindowIcon.ico", UriKind.RelativeOrAbsolute);
            Icon = BitmapFrame.Create(iconUri);
            WindowState = WindowState.Maximized;

            #endregion



            Book converted = new();

            converted.Name = bookItem.persistentBook.Title;
            converted.Content = bookItem.Content;
            converted.Category = "cat";
            converted.Author = bookItem.persistentBook.Author;
            converted.Price = 50;
            converted.BookCoverUri = new Uri("../../../bookCovers/c++.png", UriKind.Relative);

            if (!Library.Exists(converted.Name))
            {
                Library.AddBook(converted);
            }

           
            AddLibraryBooksToComboBox();
            mainFlowDoc.IsScrollViewEnabled = true;
            LibraryBooksComboBox.FontFamily = new FontFamily("Calibri");
            LibraryBooksComboBox.FontSize = 20;

            mainFlowDoc.IsTwoPageViewEnabled = true;
            mainFlowDoc.MaxWidth = 1400;
            mainFlowDoc.Height = 900;
            mainFlowDoc.HorizontalAlignment = HorizontalAlignment.Center;

           

            SetContent(converted);


            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

        }


        public MainWindow()
        {
            InitializeComponent();
            #region windowCustomization
            Title = "Reader";
            Uri iconUri = new Uri(@"..\..\..\icons\mainWindowIcon.ico", UriKind.RelativeOrAbsolute);
            Icon = BitmapFrame.Create(iconUri);
            WindowState = WindowState.Maximized;

            #endregion

            
            
            mainFlowDoc.IsScrollViewEnabled = true;
            LibraryBooksComboBox.FontFamily = new FontFamily("Calibri");
            LibraryBooksComboBox.FontSize = 20;

            mainFlowDoc.IsTwoPageViewEnabled = true;
            mainFlowDoc.MaxWidth = 1400;
            mainFlowDoc.Height = 900;
            mainFlowDoc.HorizontalAlignment = HorizontalAlignment.Center;


            Book test1 = new Book(@"..\..\..\books\StoreLibraryBooks\Harry_Potter.txt");
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            SetContent(test1);
        }
        void timer_Tick(object sender, EventArgs e)
        {
            // proverkacountbook();

        }

        public void SetContent(Book item)
        {
            //myParagraph.Inlines.Clear();
            //myParagraph.Inlines.Add(new Run(item.Content));

            FlowDocument flowdoc = new FlowDocument();
            Paragraph pg = new Paragraph(new Run(item.Content)); //содержимое книги в ридере
            pg.FontFamily = new FontFamily("Calibri");
            pg.FontSize = 24;

            mainFlowDoc.Document = flowdoc;
            flowdoc.Blocks.Add(pg);

            

            CurrentBookName.Content = item.Name; //тайтл книги на главном экране
            LibraryBooksComboBox.Text = item.Name; //добавления имя в бокс для переключения по книгам
        }

        public void addBookToLibrary(VisualBook book)
        {
            
            if(!Library.Exists(book.persistentBook.Title))
            {

                Library.AddBook(new Book
                {
                    Name = book.persistentBook.Title,
                    Content = book.Content,
                    Author = book.persistentBook.Author,
                    Price = 35,
                    Category = "Bestseller",
                    

                });
            }
            
          

        }

        private void DotsClick(object sender, RoutedEventArgs e)
        {
            HideControlElements();
        }
        private void HideControlElements()
        {

            if (isHidden == true)
            {
                menuGrid.Visibility = Visibility.Visible;
                LibraryBooksComboBox.Visibility = Visibility.Visible;
               CurrentBookName.Visibility = Visibility.Collapsed;
               themeImage.Visibility = Visibility.Visible;
               fontImage.Visibility = Visibility.Visible;
                //UpperMenu.Visibility = Visibility.Visible;

                mainFlowDoc.Height -= 135;

                DoubleAnimation navMenuAnimation = new(0, 70, TimeSpan.FromSeconds(0.5d));
                DoubleAnimation buttMenuAnimation = new(0, 135, TimeSpan.FromSeconds(0.5d));
                UpperNavigationMenu.BeginAnimation(HeightProperty, navMenuAnimation);
                menuGrid.BeginAnimation(HeightProperty, buttMenuAnimation);

                isHidden = false;
                return;
            }
            else
            {
                mainFlowDoc.Height += 135;

                LibraryBooksComboBox.Visibility = Visibility.Collapsed;
                //UpperMenu.Visibility = Visibility.Collapsed;
                themeImage.Visibility = Visibility.Hidden;
                fontImage.Visibility = Visibility.Hidden;
                CurrentBookName.Visibility = Visibility.Visible;

                DoubleAnimation buttMenuAnimation = new(135, 0, TimeSpan.FromSeconds(0.5d));

                menuGrid.BeginAnimation(HeightProperty, buttMenuAnimation);

                isHidden = true;
            }
        }
        private void FontClick(object sender, RoutedEventArgs e)
        {
            FontWindowShow();
         
        }

        private void ThemeClick(object sender, RoutedEventArgs e)
        {


            ThemeChange();
        }
        private void ThemeChange()
        {
            if (isDark == false)
            {
                currentTheme = "dark";
                mainFlowDoc.Foreground = Brushes.White;
                Background = (Brush)new BrushConverter().ConvertFrom("#171717");
                fontImage.Source = new BitmapImage(new Uri(@"\mainMenuIcons\upperMenuIcons\fontCustomizationIconLight.png", UriKind.RelativeOrAbsolute));
                themeImage.Source = new BitmapImage(new Uri(@"\mainMenuIcons\upperMenuIcons\lightThemeIcon.png", UriKind.Relative));
                HomeImage.Source = new BitmapImage(new Uri(@"\mainMenuButtons\darkTheme\darkThemeHome.png", UriKind.Relative));
                StoreImage.Source = new BitmapImage(new Uri(@"\mainMenuButtons\darkTheme\darkThemeStore.png", UriKind.Relative));
                SettingsImage.Source = new BitmapImage(new Uri(@"\mainMenuButtons\darkTheme\darkThemeSettings.png", UriKind.Relative));
                ProgressImage.Source = new BitmapImage(new Uri(@"\mainMenuButtons\darkTheme\darkThemeProgress.png", UriKind.Relative));
                DotsButton.Foreground = Brushes.White;
                isDark = true;
                return;
            }
            else
            {
                currentTheme = "light";
                mainFlowDoc.Foreground = Brushes.Black;
                Background = Brushes.White;
                fontImage.Source = new BitmapImage(new Uri(@"\mainMenuIcons\upperMenuIcons\fontCustomizationIconDark.png", UriKind.RelativeOrAbsolute));
                themeImage.Source = new BitmapImage(new Uri(@"\mainMenuIcons\upperMenuIcons\darkThemeIcon.png", UriKind.Relative));
                HomeImage.Source = new BitmapImage(new Uri(@"\mainMenuButtons\lightTheme\home.png", UriKind.Relative));
                StoreImage.Source = new BitmapImage(new Uri(@"\mainMenuButtons\lightTheme\store.png", UriKind.Relative));
                SettingsImage.Source = new BitmapImage(new Uri(@"\mainMenuButtons\lightTheme\settings.png", UriKind.Relative));
                ProgressImage.Source = new BitmapImage(new Uri(@"\mainMenuButtons\lightTheme\progress.png", UriKind.Relative));

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
        public void AddLibraryBooksToComboBox()
        {

            LibraryBooksComboBox.Items.Clear();
           

            BookComboBoxItem toAdd;

            for(int a = 0;a<Library.myLibrary.Count;a++)
            {
                
                toAdd = new();
                toAdd.BindedBook = Library.myLibrary[a];
                toAdd.Content = toAdd.BindedBook.Name;

                LibraryBooksComboBox.Items.Add(toAdd);
            }
            /*
            BookComboBoxItem bookItem;

            bool IsListed;

            

            if (LibraryBooksComboBox.Items.Count == 0)
            {
                for (int a = 0; a < Library.myLibrary.Count; a++)
                {
                    MessageBox.Show(Library.myLibrary.Count.ToString());
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

                    foreach (BookComboBoxItem bookItem1 in LibraryBooksComboBox.Items)
                    {
                        if (bookItem1.BindedBook.Name == item.Name)
                        {
                            IsListed = true;
                            MessageBox.Show(bookItem1.BindedBook.Name);
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
            */
        }
        private void OnHomeButtonClick(object sender, RoutedEventArgs e)
        {
            HomeWindowShow();
        }
        private void HomeWindowShow()
        {
            MainPage mp = new();
            mp.Show();

            Close();
        }
        private void FontWindowShow()
        {
            FlowDocumentReaderViewingMode viewingMode;
            Paragraph my = mainFlowDoc.Document.Blocks.ElementAt(0) as Paragraph;
            viewingMode = mainFlowDoc.ViewingMode;

            FontDialogWindow newWindow = new FontDialogWindow(my, viewingMode, this.ActualWidth);
            TextProperties newStyle;

            newWindow.ShowDialog();
            newStyle = new TextProperties(newWindow.exampleText);
            newStyle.SetParagraphStyle(my);
            HideControlElements();
            mainFlowDoc.ViewingMode = newWindow.ViewMode;


        }
        private void OnShopButtonClick(object sender, RoutedEventArgs e)
        {
            HideControlElements();
            ShopWindowShow();
        }
        private void ShopWindowShow()
        {
            //mainFlowDoc.Height += 100;
            ShopWindow shopwin = new ShopWindow(currentTheme);
            shopwin.ShowDialog();

            AddLibraryBooksToComboBox();

            if (shopwin.BookToRead != null)
            {

                SetContent(shopwin.BookToRead);
            }
            if(shopwin.BookToRead != null)
                LibraryBooksComboBox.Text = shopwin.BookToRead.Name;


        }
        private void OnProgresButtonClick(object sender, RoutedEventArgs e)
        {
            HideControlElements();
            Achievement ach = new Achievement();
            ach.ShowDialog();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sf = new();
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

        private void MainWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            Window thisWindow = (Window)sender;

            if (thisWindow.ActualWidth > 700)
            {
                mainFlowDoc.ViewingMode = FlowDocumentReaderViewingMode.TwoPage;
            }
            else
            {
                mainFlowDoc.ViewingMode = FlowDocumentReaderViewingMode.Page;
            }
        }
        private void MainWindowKeyDown(object sender, KeyEventArgs e)
        {

            switch (e.Key)
            {
                case Key.F: FontWindowShow(); break;
                case Key.E: SettingsShow(); break;
                case Key.G: HideControlElements(); break;
                case Key.S: ShopWindowShow(); break;
                case Key.H: HomeWindowShow(); break;
                case Key.T: ThemeChange(); break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void SettingsShow()
        {
            Settings settingsWindow = new(currentTheme);
            settingsWindow.Show();
        }
        private void OnSettingsClick(object sender, RoutedEventArgs e)
        {
            SettingsShow();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    } 

}

