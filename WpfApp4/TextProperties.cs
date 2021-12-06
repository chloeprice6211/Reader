using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Documents;
using System.Windows.Controls;

namespace reader
{
     public class TextProperties
    {
        double _fontSize;
        FontStyle _thisStyle;
        FontFamily _currentFont;
        FontWeight _thisWeight;

        public TextProperties(TextBlock myText)
        {
            _thisWeight = myText.FontWeight;
            _thisStyle = myText.FontStyle;
            _fontSize = myText.FontSize;
            _currentFont = myText.FontFamily;
        }
        public TextProperties(Paragraph myText)
        {
            _thisWeight = myText.FontWeight;
            _thisStyle = myText.FontStyle;
            _fontSize = myText.FontSize;
            _currentFont = myText.FontFamily;
            MessageBox.Show(this.ToString());
        }
        public void SetParagraphStyle(Paragraph my)
        {
            my.FontFamily = _currentFont;
            my.FontStyle = _thisStyle;
            my.FontWeight = _thisWeight;
            my.FontSize = _fontSize;
        }

        public double FontSize
        {
            get
            {
                return _fontSize;
            }
        }
        public FontStyle ThisStyle
        {
            get { return _thisStyle; }
        }
       public FontFamily ThisFont
        {
            get { return _currentFont; }
        }
        public FontWeight ThisWeight
        {
            get { return _thisWeight; }
        }
    }
}
