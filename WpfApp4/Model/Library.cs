using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reader
{
    static class Library
    {
       static List<Book> myLibrary = new List<Book>();

        static public void AddBook(Book toAdd)
        {
            myLibrary.Add(toAdd);
        }
    }
}
