using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace reader
{
    class BookComboBoxItem:ComboBoxItem
    {
        Book bindedBook = new Book();

        public Book BindedBook
        {
            get
            {
                return bindedBook;
            }
            set
            {
                BindedBook = value;
            }
        }

    }
    
}
