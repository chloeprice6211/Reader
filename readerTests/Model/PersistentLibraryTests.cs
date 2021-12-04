using Microsoft.VisualStudio.TestTools.UnitTesting;
using reader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reader.Model.Tests
{
    [TestClass()]
    public class PersistentLibraryTests
    {
        PersistentLibrary testCatalog = new PersistentLibrary();

        [TestMethod()]
        public void TestLoadFromJson()
        {
            
            initEntries();

            PersistentLibrary actual = new PersistentLibrary();

            actual.load();

            Assert.IsTrue(actual.Books.ElementAt(0).Equals(testCatalog.Books.ElementAt(0)));

            Assert.IsTrue(testCatalog.Books.SequenceEqual(actual.Books));

        }


        [TestMethod()]
        public void TestSaveToJson()
        {
            initEntries();

            testCatalog.save();

        }


        void initEntries()
        {
            testCatalog.add(new PersistentBook()
            {
                Title = "Harry Potter and the Goblet of Fire",
                Author = "by JK Rowling (2000)",
                CoverPath = "cover1.jpg",
                ContentPath = "book1.txt"
            });

            testCatalog.add(new PersistentBook()
            {
                Title = "The Lord of the Rings",
                Author = "by J.R.R. Tolkien (1954)",
                CoverPath = "cover2.jpg",
                ContentPath = "book2.txt"
            });

            testCatalog.add(new PersistentBook()
            {
                Title = "Dune",
                Author = "by Frank Herbert (1965)",
                CoverPath = "cover3.jpg",
                ContentPath = "book3.txt"
            });

            testCatalog.add(new PersistentBook()
            {
                Title = "Wheel of Time : The Eye of the World",
                Author = "by Robert Jordan (1990)",
                CoverPath = "cover4.jpg",
                ContentPath = "book4.txt"
            });

            testCatalog.add(new PersistentBook()
            {
                Title = "A Song of Ice and Fire : A Game of Thrones",
                Author = "by George R. R. Martin (1996)",
                CoverPath = "cover5.jpg",
                ContentPath = "book5.txt"
            });

            testCatalog.add(new PersistentBook()
            {
                Title = "The Witcher : The Last Wish",
                Author = "by Andrzej Sapkowski (1993)",
                CoverPath = "cover6.jpg",
                ContentPath = "book6.txt"
            });
        }

    }
}