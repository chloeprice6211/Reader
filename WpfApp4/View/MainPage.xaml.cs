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
    }
}
