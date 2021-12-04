using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Controls;
using System.Windows;

namespace reader
{
    static class Library
    {
       public static List<Book> myLibrary = new List<Book>();
       static string _libraryPath = @"../../../books/library/";

        static public void AddBook(Book toAdd)
        {
            myLibrary.Add(toAdd);
            CreateBookFile(toAdd);
        }
        static void CreateBookFile(Book item)
        {
            string fileName = item.Name;
            fileName = fileName.Replace(' ', '_');

            File.WriteAllText(_libraryPath + fileName + ".txt", item.Content);
        }
    }
}
