using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace reader
{
    public class StoreMenuElement:Grid
    {
        Book book;

        public Book BookElement
        {
            get
            {
                return book;
            }
            set
            {
                book = value;
            }
        }
    }
}
