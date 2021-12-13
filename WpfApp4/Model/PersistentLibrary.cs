using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace reader.Model
{
    // -- не изменять !!
    public class PersistentLibrary
    {
        const string FileName = "library.json";

        List<PersistentBook> books = new List<PersistentBook>();
        public List<PersistentBook> Books
        {
            get { return books; }
        }

        public void load()
        {
            string readText = File.ReadAllText(FileName);
           // Console.WriteLine(readText);

            books = JsonSerializer.Deserialize<List<PersistentBook>>(readText);
            foreach(PersistentBook book in books)
            {
                Console.WriteLine(book.Title);
                Console.WriteLine(book.Author);
                Console.WriteLine(book.ContentPath);
                Console.WriteLine(book.CoverPath);
                Console.WriteLine(book.Description);
            }
        }
        public void save()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(books, options);

            using (StreamWriter writetext = new StreamWriter(FileName))
            {
                writetext.WriteLine(jsonString);
            }
        }

        public void add(PersistentBook book)
        {
            books.Add(book);
        }

        public void remove(PersistentBook book)
        {
            books.Remove(book);
        }

        public void searchByTitle(string Title)
        {
            books.Where(i => i.Title == Title).FirstOrDefault();
        }

        public void searchByAuthor(string Author)
        {
            books.Where(i => i.Author == Author).FirstOrDefault();
        }
    }
}
