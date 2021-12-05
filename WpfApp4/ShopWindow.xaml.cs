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
using System.IO;

namespace reader
{
    /// <summary>
    /// Interaction logic for ShopWindow.xaml
    /// </summary>
    public partial class ShopWindow : Window
    {
        Book bookToRead;
        public ShopWindow()
        {
            InitializeComponent();
            Title = "Store";

            StreamReader reader = new(@"../../../userData/balance.txt");
            currentBalance.Content = reader.ReadLine();
            ShopItemsInitialization();
        }

        private void OnAddBalanceButtonClick(object sender, RoutedEventArgs e)
        {
            int currentBalanceInt = Convert.ToInt32(currentBalance.Content) + 25;

            currentBalance.Content = currentBalanceInt.ToString();
        }
        private void OnBuyBookButtonClick(object sender, RoutedEventArgs e)
        {
            StreamWriter writer;
            Button thisbutton = (sender as Button);
            Label listedlabel = ((StoreMenuElement)thisbutton.Parent).Children[1] as Label;
            Book currentBook = ((StoreMenuElement)thisbutton.Parent).BookElement;

            string temporary = thisbutton.Content.ToString();
            temporary = temporary.Replace("$", "");

            int temp = Convert.ToInt32(currentBalance.Content);
            

            if (temp - Convert.ToInt32(temporary) < 0)
            {
                return;
            }

            temp -= Convert.ToInt32(temporary);
            currentBalance.Content = temp.ToString();
            File.WriteAllText(@"../../../userData/balance.txt", "");
            writer = new(@"../../../userData/balance.txt");
            writer.WriteLine(currentBalance.Content.ToString());
            writer.Close();


            listedlabel.Visibility = Visibility.Visible;
            thisbutton.Content = "Read";
            BookToRead = currentBook;

            Library.AddBook(((StoreMenuElement)thisbutton.Parent).BookElement);   

            thisbutton.Click -= new RoutedEventHandler(OnBuyBookButtonClick);
            thisbutton.Click += new RoutedEventHandler(OnReadBookButtonClick);
        }
        private void ShopItemsInitialization()
        {
            for (int a = 0; a < StoreLibrary.BooksToSell.Count; a++)
            {
                StoreMenuElement myGrid = new StoreMenuElement();

                #region gridProperties
                myGrid.Margin = new Thickness(35, 20, 0, 20);
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString("#F1F1F1");

                myGrid.Background = (Brush)brush;
                myGrid.Background.Opacity = 0.5;


                RowDefinition rowDef1 = new RowDefinition();
                RowDefinition rowDef2 = new RowDefinition();
                RowDefinition rowDef3 = new RowDefinition();
                RowDefinition rowDef4 = new RowDefinition();
                RowDefinition rowDef5 = new RowDefinition();

                myGrid.RowDefinitions.Add(rowDef1);
                myGrid.RowDefinitions.Add(rowDef2);
                myGrid.RowDefinitions.Add(rowDef3);
                myGrid.RowDefinitions.Add(rowDef4);
                myGrid.RowDefinitions.Add(rowDef5);
                #endregion

                Label bookName = new Label();
                Label listed = new Label();
                Image myImage = new Image();
                Label author = new Label();
                Button buyButton = new Button();
                TextBlock item3 = new TextBlock();
                myGrid.BookElement = StoreLibrary.BooksToSell[a];

                bool exist = Library.FindIfBookListed(myGrid.BookElement);

                #region imageProperties
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri("../../../images/BookImageStore.png", UriKind.RelativeOrAbsolute);
                bi3.EndInit();
                myImage.Width = 200;
                myImage.Source = bi3;
                #endregion
                #region bookNameProperties
                bookName.FontFamily = new FontFamily("Calibri");
                bookName.FontSize = 30;
                bookName.Margin = new Thickness(4, 4, 0, 0);
                #endregion
                #region listedProperties
                listed.FontFamily = new FontFamily("Calibri");
                listed.FontSize = 20;
                listed.Margin = new Thickness(4, 0, 0, 0);
                listed.Foreground = (Brush)new BrushConverter().ConvertFrom("#02D55E");
                listed.Visibility = Visibility.Visible;
                if (!exist) listed.Visibility=Visibility.Collapsed;

                #endregion
                #region authorNameProperties
                author.FontFamily = new FontFamily("Calibri");
                author.FontSize = 20;
                author.Margin = new Thickness(4, 0, 0, 0);
                author.Foreground = Brushes.Gray;
                #endregion
                #region buttonProperties
                buyButton.Background = Brushes.Transparent;
                buyButton.BorderThickness = new Thickness(1);
                buyButton.Height = 50;
                buyButton.FontFamily = new FontFamily("Calibri");
                buyButton.FontSize = 20;
                buyButton.Background = Brushes.White;
                buyButton.FontWeight = FontWeights.Bold;


                buyButton.Click += new RoutedEventHandler(OnBuyBookButtonClick);
                #endregion



                bookName.Content = StoreLibrary.BooksToSell[a].Name;
                author.Content = StoreLibrary.BooksToSell[a].Author;
                listed.Content = "In library";
                if(Library.FindIfBookListed(myGrid.BookElement))
                {
                    buyButton.Content = "Read";
                    buyButton.Click -= new RoutedEventHandler(OnBuyBookButtonClick);
                    buyButton.Click += new RoutedEventHandler(OnReadBookButtonClick);
                }
                else buyButton.Content = "$ " + StoreLibrary.BooksToSell[a].Price.ToString();
                myImage.Source = bi3;

                Grid.SetRow(bookName, 0);
                Grid.SetRow(author, 2);
                Grid.SetRow(listed, 1);
                Grid.SetRow(myImage, 3);
                Grid.SetRow(buyButton, 4);
                

                myGrid.Children.Add(bookName);
                myGrid.Children.Add(listed);
                myGrid.Children.Add(author);
                myGrid.Children.Add(myImage);
                myGrid.Children.Add(buyButton);
                

                MainStoreWrapPanel.Children.Add(myGrid);
            }
        }
        private void OnReadBookButtonClick(object sender, RoutedEventArgs e)
        {
            Button thisbutton = sender as Button;
            BookToRead = ((StoreMenuElement)thisbutton.Parent).BookElement;
            Close();
        }
        public Book BookToRead
        {
            get
            {
                return bookToRead;
            }
            set
            {
                bookToRead = value;
            }
        }
    }
   
}
