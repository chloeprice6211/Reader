using reader.Model;
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

namespace reader.View
{
    /// <summary>
    /// Логика взаимодействия для PopupWindow.xaml
    /// </summary>
    public partial class PopupWindow : Window
    {
        public PopupWindow()
        {
            InitializeComponent();
        }

        public void initPopup(VisualBook visualBook)
        {
           Title = visualBook.persistentBook.Title;
           imageCover.Source = visualBook.Cover;
           labelTitle.Content = visualBook.persistentBook.Title;
           labelAuthor.Content = visualBook.persistentBook.Author;
           textBlockDescription.Text = visualBook.persistentBook.Description;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
