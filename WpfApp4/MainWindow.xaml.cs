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
        Book test1 = new Book(@"..\..\..\books\StoreLibraryBooks\C++.txt");

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


            Book test1 = new Book(@"..\..\..\books\StoreLibraryBooks\C++.txt");

            SetContent(test1);
        }

        private void SetContent(Book item)
        {
            //myParagraph.Inlines.Clear();
            //myParagraph.Inlines.Add(new Run(item.Content));

            FlowDocument flowdoc = new FlowDocument();
            Paragraph pg = new Paragraph(new Run(item.Content));
            mainFlowDoc.Document = flowdoc;

            flowdoc.Blocks.Add(pg);

          
        }

        private void SetContent(string cont)
        {
           
        }
        private void DotsClick(object sender, RoutedEventArgs e)
        {
            if (menuGrid.Visibility == Visibility.Collapsed)
            { menuGrid.Visibility = Visibility.Visible;
                mainFlowDoc.Height -= 100;
            }
            else
            {
                mainFlowDoc.Height += 100;
                menuGrid.Visibility = Visibility.Collapsed;
            }
            


        }
        private void FontClick(object sender, RoutedEventArgs e)
        {
            Paragraph my = new();
            FontDialogWindow newWindow = new FontDialogWindow(my);
            TextProperties newStyle;

            newWindow.ShowDialog();
            newStyle = new TextProperties(newWindow.exampleText);
            newStyle.SetParagraphStyle(my);
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

        private void OnLIbraryButtonClick(object sender, RoutedEventArgs e)
        {
            SetContent("dsadsa");
         }

        private void OnShopButtonClick(object sender, RoutedEventArgs e)
        {
            ShopWindow shopwin = new ShopWindow();
            shopwin.ShowDialog();

            SetContent(shopwin.BookToRead);
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
    }
}
