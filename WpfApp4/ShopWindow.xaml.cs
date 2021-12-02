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

namespace reader
{
    /// <summary>
    /// Interaction logic for ShopWindow.xaml
    /// </summary>
    public partial class ShopWindow : Window
    {
        public ShopWindow()
        {
            InitializeComponent();
            Title = "Store";
            ShopItemsInitialization();
        }

        private void OnAddBalanceButtonClick(object sender, RoutedEventArgs e)
        {
            int currentBalanceInt = Convert.ToInt32(currentBalance.Content) + 25;

            currentBalance.Content = currentBalanceInt.ToString();
        }

        private void OnBuyBookButtonClick(object sender, RoutedEventArgs e)
        {
            string temporary = (sender as Button).Content.ToString();
            temporary = temporary.Replace("$", "");
            int temp = Convert.ToInt32(currentBalance.Content);

            if (temp - Convert.ToInt32(temporary) <0)
            {
                return;
            }
            temp -= Convert.ToInt32(temporary);

            currentBalance.Content = temp;
        }
        private void ShopItemsInitialization()
        {
            int count = 0;
            foreach(Grid childGrid in MainStoreWrapPanel.Children)
            {
               (childGrid.Children[0] as Label).Content = StoreLibrary.BooksToSell[count].Name;
                (childGrid.Children[2] as Button).Content = "$" + StoreLibrary.BooksToSell[count].Price;

                count++;
            }
        }
       
    }
}
