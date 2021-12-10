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
        }
        private void UserDataInput()
        {
            StreamReader reader = new StreamReader(userDataPath);

            emailTxtBox.Text = reader.ReadLine();
            nameTxtBox.Text = reader.ReadLine();
            numberTxtBox.Text = reader.ReadLine();
            countryTxtBox.Text = reader.ReadLine();

        }
    }
}
