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
    {
        static bool isDark = false;
        public MainWindow()
        {
            string txtContent;

            InitializeComponent();
            Title = "Reader";
            StreamReader reader = new("texts/mytext.txt");
            txtContent = reader.ReadToEnd();

            myParagraph.Inlines.Add(txtContent);
            
        }
        private void DotsClick(object sender, RoutedEventArgs e)
        {
            if (FontButton.Visibility == Visibility.Hidden && ThemeButton.Visibility == Visibility.Hidden)
            {
                FontButton.Visibility = 0;
                ThemeButton.Visibility = 0;
                OpenButton.Visibility = 0;
            }
            else
            {
                FontButton.Visibility = Visibility.Hidden; ThemeButton.Visibility = Visibility.Hidden; OpenButton.Visibility = Visibility.Hidden;
            }
        }

        private void FontClick(object sender, RoutedEventArgs e)
        {
            FontDialogWindow newWindow = new(myParagraph);
            TextProperties newStyle;

            newWindow.ShowDialog();
            newStyle = new(newWindow.exampleText);
            newStyle.SetParagraphStyle(myParagraph);

            FontButton.Visibility = Visibility.Hidden;
            ThemeButton.Visibility = Visibility.Hidden;
            
        }

        private void ThemeClick(object sender, RoutedEventArgs e)
        {
            if (isDark == false)
            {
                mainFlowDoc.Foreground = Brushes.White;
                Background = (Brush)new BrushConverter().ConvertFrom("#171717");

                ThemeButton.Foreground = Brushes.White;
                FontButton.Foreground = Brushes.White;
                DotsButton.Foreground = Brushes.White;
                isDark = true;
                return;
            }
            else
            {
                mainFlowDoc.Foreground = Brushes.Black;
                Background = Brushes.White;

                ThemeButton.Foreground = Brushes.Black;
                FontButton.Foreground = Brushes.Black;
                DotsButton.Foreground = Brushes.Black;
                isDark = false;
            }

            

        }

        private void OpenClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog my = new();
            StreamReader reader;
            string text;
            string a;

            my.ShowDialog();
            reader = new(my.FileName);
            text = reader.ReadToEnd();

            myParagraph.Inlines.Clear();
            myParagraph.Inlines.Add(text);
        }
    }
}
