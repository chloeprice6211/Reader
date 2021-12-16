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
        public Settings()
        {
            InitializeComponent();
            UserDataInput();

            Uri iconUri = new Uri(@"..\..\..\icons\settings.ico", UriKind.RelativeOrAbsolute);
            Icon = BitmapFrame.Create(iconUri);
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
            SaveUserDataButtonEnable();
        }
        private void NumberChanged(object sender, KeyEventArgs e)
        {
            SaveUserDataButtonEnable();
        }

        private void EmailChanged(object sender, KeyEventArgs e)
        {
            SaveUserDataButtonEnable();
        }

        private void CountryChanged(object sender, KeyEventArgs e)
        {
            SaveUserDataButtonEnable();
        }
        private void SaveUserDataButtonEnable()
        {
            saveUserDataButton.IsEnabled = true;
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

            thisbutton.IsEnabled = false;
        }

        private void OnPfpEnter(object sender, MouseEventArgs e)
        {
            MessageBox.Show("!!");
        }

    }
}
