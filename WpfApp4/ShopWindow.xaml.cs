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
using System.Windows.Media.Animation;

namespace reader
{
    /// <summary>
    /// Interaction logic for ShopWindow.xaml
    /// </summary>
    public partial class ShopWindow : Window
    {
        Book bookToRead;
        string panelColorCode;
        string labelColorCode;
        public ShopWindow(string theme)
        {
            InitializeComponent();
            Title = "Store";

            StreamReader reader = new(@"../../../userData/balance.txt");
            currentBalance.Content = reader.ReadLine();

            ThemeChange(theme);
            ShopItemsInitialization();
            ItemPurchaseAvailability();
            
            WindowState = WindowState.Maximized;
        }

        private void OnAddBalanceButtonClick(object sender, RoutedEventArgs e)
        {
            int currentBalanceInt = Convert.ToInt32(currentBalance.Content) + 25;

            currentBalance.Content = currentBalanceInt.ToString();
            
            ItemPurchaseAvailability();
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
            ItemPurchaseAvailability();
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
                var brush = (Brush)converter.ConvertFromString(panelColorCode);

                myGrid.Background = (Brush)brush;
                myGrid.Background.Opacity = 0.5;
                myGrid.Width=200;


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
                bi3.UriSource = myGrid.BookElement.BookCoverUri;
                bi3.EndInit();
                myImage.Width = 150;
                myImage.Margin = new Thickness(10, 10, 10, 10);
                myImage.Source = bi3;
                #endregion
                #region bookNameProperties
                bookName.FontFamily = new FontFamily("Calibri");
                bookName.FontSize = 30;
                bookName.Margin = new Thickness(4, 4, 0, 0);
                bookName.Foreground = (Brush)new BrushConverter().ConvertFrom(labelColorCode);
                #endregion
                #region listedProperties
                listed.FontFamily = new FontFamily("Calibri");
                listed.FontSize = 20;
                listed.Margin = new Thickness(4, 0, 0, 0);
                listed.Foreground = (Brush)new BrushConverter().ConvertFrom("#169400");
                listed.Visibility = Visibility.Visible;
                if (!exist) listed.Visibility=Visibility.Hidden;

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
                buyButton.Foreground = (Brush)new BrushConverter().ConvertFrom(labelColorCode);
                buyButton.FontWeight = FontWeights.Bold;

                buyButton.MouseEnter += new MouseEventHandler(MouseOnBuyButton);
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

        private void TestEvent(object sender, KeyEventArgs e)
        {
            searching();
        }

        private void SearchBoxFocused(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "";
            ((TextBox)sender).Foreground = (Brush)new BrushConverter().ConvertFrom(labelColorCode);
        }

        private void TextBoxNotFocused(object sender, RoutedEventArgs e)
        {
            SearchBoxUnfocus();
        }
        private void ItemPurchaseAvailability()
        {
            foreach(StoreMenuElement item in MainStoreWrapPanel.Children)
            {
                Button purchaseButton = (Button)item.Children[4];
                if (purchaseButton.Content == "Read")
                {
                    continue;
                }
                string valueInString = purchaseButton.Content.ToString();
                valueInString = valueInString.Replace("$", "");
                int value = Convert.ToInt32(valueInString);

                if (purchaseButton.Content != "Read" && value <= Convert.ToInt32(currentBalance.Content.ToString()))
                {
                    purchaseButton.Foreground = Brushes.Black;
                }
                else if(purchaseButton.Content != "Read" && value > Convert.ToInt32(currentBalance.Content.ToString()))
                {
                    purchaseButton.Foreground = Brushes.Red;
                }
                
            }
        }

        private void OnEraseButtonClick(object sender, RoutedEventArgs e)
        {
            StoreItemSearchBox.Text = "";
            searching();
            SearchBoxUnfocus();
        }
        private void MouseOnBuyButton(object sender, MouseEventArgs e)
        {
            //Button thisButton = (Button)sender;
           // DoubleAnimation buttonHoverAnimation = new(50, 60,TimeSpan.FromSeconds(0.1d));
            //ColorAnimation buttonHoverColorAnimation = new(Colors.White,Colors.Black, TimeSpan.FromSeconds(0.1d));


            //thisButton.Background = new SolidColorBrush(Colors.Transparent);
            //thisButton.Background.BeginAnimation(SolidColorBrush.ColorProperty, buttonHoverColorAnimation);
            //thisButton.BeginAnimation(Button.HeightProperty, buttonHoverAnimation);
        }
        private void searching()
        {
            string bookName;
            string searchKey = StoreItemSearchBox.Text;
            int count = 0;

            eraseButton.Visibility = Visibility.Visible;

            foreach (StoreMenuElement itemGrid in MainStoreWrapPanel.Children)
            {
                bookName = ((Label)itemGrid.Children[0]).Content.ToString();
                bool contains = bookName.Contains(searchKey, StringComparison.OrdinalIgnoreCase);

                if (!contains)
                {
                    itemGrid.Visibility = Visibility.Collapsed;
                }
                else if (contains)
                {
                    itemGrid.Visibility = Visibility.Visible;
                    count++;
                }




            }

            if (count == 0) NoFoundLabel.Visibility = Visibility.Visible;
            else if (count > 0) NoFoundLabel.Visibility = Visibility.Collapsed;
        }
        private void SearchBoxUnfocus()
        {
            if (StoreItemSearchBox.Text != "")
            {
                return;
            }
            eraseButton.Visibility = Visibility.Hidden;
            StoreItemSearchBox.Text = "Search for book...";
            StoreItemSearchBox.Foreground = (Brush)new BrushConverter().ConvertFrom("#FFCACACA");
        }
        private void ThemeChange(string theme)
        {
            if(theme == "dark")
            {
                Background = (Brush)new BrushConverter().ConvertFrom("#171717");
                 panelColorCode = "#2e2e2e";
                 labelColorCode = "#ffffff";
                mainLabel.Foreground = Brushes.White;
                addBalanceButton.Foreground = Brushes.White;
            }
            else if(theme == "light")
            {
                Background = Brushes.White;
                panelColorCode = "#e6e6e6";
                labelColorCode = "#000000";
                mainLabel.Foreground = Brushes.Black;
                addBalanceButton.Foreground = Brushes.Black;
            }
        }
        
    }
   
}
