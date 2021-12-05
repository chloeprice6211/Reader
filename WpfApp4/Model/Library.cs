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
       static string _libraryPath = @"../../../books/Library/";

        static public void AddBook(Book toAdd)
        {
            myLibrary.Add(toAdd);
            CreateBookFile(toAdd);
        }
        static void CreateBookFile(Book item)
        {
            string fileName = item.Name;
            fileName = fileName.Replace(' ', '_');


            if (File.Exists(LibraryPath + fileName + ".txt"))

            {
                return;
            }

            
            StreamWriter writer = new StreamWriter(LibraryPath + fileName + ".txt");

            writer.WriteLine(item.Category);
            writer.WriteLine(item.Author);
            writer.WriteLine(item.Price);
            writer.Close();
            File.AppendAllText(LibraryPath+fileName+".txt",item.Content);
           
        }
        static public void AddAllBooks(string path)
        {
            string[] allBooks = Directory.GetFiles(path);
            Book tempItem;

            for (int a = 0; a < allBooks.Length; a++)
            {
                tempItem = new(allBooks[a]);
                AddBook(tempItem);
            }

        }
        static public bool FindIfBookListed(Book item)
        {
            foreach(Book book in myLibrary)
            {
                if(item.Name == book.Name)
                {
                    return true;
                }
            }
            return false;
        }
        public static string LibraryPath
        {
            get
            {
                return _libraryPath;
            }
        }
    }
}
