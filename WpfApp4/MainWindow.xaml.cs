using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Windows.Controls;
using Microsoft.Win32;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace reader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///

    public partial class MainWindow : Window
    {
        string text;
        static bool isDark = false;
        public MainWindow()
        {
            string txtContent;

            InitializeComponent();
            Title = "Reader";
            Uri iconUri = new Uri(@"..\..\..\icons\mainWindowIcon.ico", UriKind.RelativeOrAbsolute);
            Icon = BitmapFrame.Create(iconUri);
            MaxWidth = 1200;

            StreamReader reader = new StreamReader(@"..\..\..\books\book1.txt");
            txtContent = reader.ReadToEnd();
            myParagraph.Inlines.Add(txtContent);
            text = txtContent;
        }
        private void DotsClick(object sender, RoutedEventArgs e)
        {
            if (menuGrid.Visibility == Visibility.Collapsed) { menuGrid.Visibility = Visibility.Visible; }
            else menuGrid.Visibility = Visibility.Collapsed;

            string TESTVARIABLE;

        }

        private void FontClick(object sender, RoutedEventArgs e)
        {
            FontDialogWindow newWindow = new FontDialogWindow(myParagraph);
            TextProperties newStyle;

            newWindow.ShowDialog();
            newStyle = new TextProperties(newWindow.exampleText);
            newStyle.SetParagraphStyle(myParagraph);


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
                else if (child is System.Windows.Controls.Image)
                {
                    (child as System.Windows.Controls.Image).Height -= 20;
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
                else if (child is System.Windows.Controls.Image)
                {
                    (child as System.Windows.Controls.Image).Height += 20;
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


        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            

            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(new FileStream("hello.pdf", FileMode.Create, FileAccess.Write)));
            Document document = new Document(pdfDocument);


            document.Add(new Paragraph(text));
            document.Close();
            Console.WriteLine("Awesome PDF just got created.");

        }
    }
} 
