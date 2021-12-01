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
    /// Interaction logic for FontDialogWindow.xaml
    /// </summary>
    public partial class FontDialogWindow : Window
    {
        public FontDialogWindow(Paragraph main)
        {
            InitializeComponent();

            TextProperties newStyle = new(main);
            SetCurrentTextProperties(newStyle);

            
           
        }
        private void changingValue(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(fontSizeSliderValueLabel != null)
            {
                fontSizeSliderValueLabel.Content = (sender as Slider).Value.ToString();
                exampleText.FontSize = (sender as Slider).Value;
            }
            
        }

        private void ifBoldTextChecked(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                exampleText.FontWeight = FontWeights.Bold;
            }
            else exampleText.FontWeight = FontWeights.Regular;
        }

        private void ifItalicClicked(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                exampleText.FontStyle = FontStyles.Italic;
            }
            else exampleText.FontStyle = FontStyles.Normal;
        }

        private void ApplyButtonClick(object sender, RoutedEventArgs e)
        {
            TextProperties newProperty = new(exampleText);

            Close();

        }
        public void SetCurrentTextProperties(TextProperties currentProperties)
        {
            fontSizeSlider.Value = currentProperties.FontSize;
            if(currentProperties.ThisWeight == FontWeights.Bold)
            {
                isBoldCheckBox.IsChecked = true;
            }
            if(currentProperties.ThisStyle == FontStyles.Italic)
            {
                isItalicCheckBox.IsChecked = true;
            }

        }

        private void CancelButton(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
