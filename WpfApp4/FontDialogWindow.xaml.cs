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
        double mainWinWidth;
        FlowDocumentReaderViewingMode viewMode;
        public FontDialogWindow(Paragraph main, FlowDocumentReaderViewingMode incomingViewMode, double windowWidth)
        {
            Title = "Font customization";
            mainWinWidth = windowWidth;
            Uri FontDialogWindowIcon = new(@"..\..\..\icons\fontDialogWindowIcon.ico",UriKind.RelativeOrAbsolute);
            Icon = BitmapFrame.Create(FontDialogWindowIcon);
            InitializeComponent();
            if (incomingViewMode == FlowDocumentReaderViewingMode.Page || incomingViewMode == FlowDocumentReaderViewingMode.TwoPage)
            {
                SetPageView();
            }
            else SetScrollView();

            
            FontChanging(main.FontFamily);
            TextProperties newStyle = new TextProperties(main);
           
            SetCurrentTextProperties(newStyle);
        }
        private void changingValue(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (fontSizeSliderValueLabel != null)
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
            TextProperties newProperty = new TextProperties(exampleText);

            Close();

        }
        public void SetCurrentTextProperties(TextProperties currentProperties)
        {
            fontSizeSlider.Value = currentProperties.FontSize;
            if (currentProperties.ThisWeight == FontWeights.Bold)
            {
                isBoldCheckBox.IsChecked = true;
            }
            if (currentProperties.ThisStyle == FontStyles.Italic)
            {
                isItalicCheckBox.IsChecked = true;
            }
        }

        private void CancelButton(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FontChanging(object sender, EventArgs e)
        {
            exampleText.FontFamily = new FontFamily(FontComboBox.Text);

        }
        private void FontChanging(FontFamily temp)
        {
            exampleText.FontFamily = temp;

            switch (temp.ToString())
            {
                case "Times New Roman": FontComboBox.SelectedIndex = 0; break;
                case "Calibri": FontComboBox.SelectedIndex = 1; break;
                case "Tahoma": FontComboBox.SelectedIndex = 2; break;
                case "Comic sans MS": FontComboBox.SelectedIndex = 3; break;
            }

        }

        private void OnPageModeClick(object sender, RoutedEventArgs e)
        {
            SetPageView();

        }

        private void OnScrollModeClick(object sender, RoutedEventArgs e)
        {
            SetScrollView();
        }

        private void SetScrollView()
        {
            Button thisbutton = ScrollModeButton;

            thisbutton.BorderBrush = Brushes.Green;
            thisbutton.FontWeight = FontWeights.Bold;
            thisbutton.Foreground = Brushes.Black;

            PageModeButton.BorderBrush = Brushes.Gray;
            PageModeButton.Foreground = Brushes.Gray;

            ViewMode = FlowDocumentReaderViewingMode.Scroll;
        }
        private void SetPageView()
        {
            Button thisbutton = PageModeButton;

            thisbutton.BorderBrush = Brushes.Green;
            thisbutton.FontWeight = FontWeights.Bold;
            thisbutton.Foreground = Brushes.Black;

            ScrollModeButton.BorderBrush = Brushes.Gray;
            ScrollModeButton.Foreground = Brushes.Gray;

            if(mainWinWidth > 750)
                ViewMode = FlowDocumentReaderViewingMode.TwoPage;

            else
                ViewMode = FlowDocumentReaderViewingMode.Page;


        }
        public FlowDocumentReaderViewingMode ViewMode
        {
            get
            {
                return viewMode;
            }
            set
            {
                viewMode = value;
            }
        }
    }
}