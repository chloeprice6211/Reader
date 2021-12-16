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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using Microsoft.Win32;
using System.Drawing;

namespace reader
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        string userDataPath = @"../../../userData/profile/userData.txt";
        public Settings(string theme)
        {
            InitializeComponent();
            UserDataInput();
            Uri iconUri = new Uri(@"..\..\..\icons\settings.ico", UriKind.RelativeOrAbsolute);
            Icon = BitmapFrame.Create(iconUri);
            
            if(theme =="dark") ThemeChange();

        }
        private void UserDataInput()
        {
            StreamReader reader = new StreamReader(userDataPath);

            emailTxtBox.Text = reader.ReadLine();
            nameTxtBox.Text = reader.ReadLine();
            numberTxtBox.Text = reader.ReadLine();
            countryTxtBox.Text = reader.ReadLine();

            reader.Close();

        }

        private void NameChanged(object sender, KeyEventArgs e)
        {
            saveUserDataButton.IsEnabled = true;
            saveUserDataButton.Opacity = 1f;
        }
        private void NumberChanged(object sender, KeyEventArgs e)
        {
            saveUserDataButton.IsEnabled = true;
            saveUserDataButton.Opacity = 1f;
        }
      
        private void EmailChanged(object sender, KeyEventArgs e)
        {
            saveUserDataButton.IsEnabled = true;
            saveUserDataButton.Opacity = 1f;
        }

        private void CountryChanged(object sender, KeyEventArgs e)
        {
            saveUserDataButton.IsEnabled = true;
            saveUserDataButton.Opacity = 1f;
        }
        private void SaveUserDataButtonEnable()
        {
            saveUserDataButton.IsEnabled = true;
            saveUserDataButton.Opacity = 1f;
        }

        private void OnSaveButtonClick(object sender, RoutedEventArgs e)
        {
            Button thisbutton = (Button)sender;
            File.WriteAllText(userDataPath, String.Empty);

            StreamWriter writer = new StreamWriter(userDataPath);



            writer.WriteLine(emailTxtBox.Text);
            writer.WriteLine(nameTxtBox.Text);
            writer.WriteLine(numberTxtBox.Text);
            writer.WriteLine(countryTxtBox.Text);

            writer.Close();

            saveUserDataButton.IsEnabled = false;
            saveUserDataButton.Opacity = 0.05f;
        }

        private void ThemeChange()
        {
            Background = (Brush)new BrushConverter().ConvertFrom("#171717");
            foreach(object temp in profileDataGrid.Children)
            {
                if(temp is TextBlock)
                {
                    ((TextBlock)temp).Foreground = Brushes.White;
                    
                }
                
                else if(temp is TextBox)
                {
                    ((TextBox)temp).Foreground = Brushes.White;
                    ((TextBox)temp).Background = Brushes.Transparent;
                    ((TextBox)temp).BorderBrush = Brushes.LightBlue;
                }
            }

            saveUserDataButton.BorderBrush = Brushes.White;
            saveUserDataButton.Foreground = Brushes.White;

            ProfileLabel.Foreground = Brushes.White;
            ShortCutLabel.Foreground = Brushes.White;

            foreach(TextBlock item in SCgrid.Children)
            {
                item.Foreground = Brushes.White;
            }
       
            
        }

        private void test(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
