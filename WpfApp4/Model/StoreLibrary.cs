using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace reader
{
    static class StoreLibrary
    {
        public static List<Book> BooksToSell = new List<Book>();
        
        static public void AddBook(Book item)
        {
            BooksToSell.Add(item);
        }
        static public void AddAllBooks(string path)
        {
            string[] allBooks = Directory.GetFiles(path);
            Book tempItem;

           for(int a = 0;a<allBooks.Length;a++)
            {
                tempItem = new(allBooks[a]);
                AddBook(tempItem);
            }

        }
    }
}
