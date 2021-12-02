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
        }

        private void OnAddBalanceButtonClick(object sender, RoutedEventArgs e)
        {
            int currentBalanceInt = Convert.ToInt32(currentBalance.Content) + 25;

            currentBalance.Content = currentBalanceInt.ToString();
        }

        private void OnBuyBookButtonClick(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
