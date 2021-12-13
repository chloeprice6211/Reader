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
                CoverPath = "/covers/cover1.jpg",
                ContentPath = "/content/book1.txt",
                Description = "A generation grew up on Rowling’s all-conquering magical fantasies, but countless adults have also been enthralled by her immersive world. Book four, the first of the doorstoppers, marks the point where the series really takes off. The Triwizard Tournament provides pace and tension, and Rowling makes her boy wizard look death in the eye for the first time.",
            });

            testCatalog.add(new PersistentBook()
            {
                Title = "The Lord of the Rings",
                Author = "by J.R.R. Tolkien (1954)",
                CoverPath = "/covers/cover2.jpg",
                ContentPath = "/content/book2.txt",
                Description = "You've likely already read this fantasy classic, but now's the perfect time to re-read it in advance of the Tolkien release. Tolkien initially wrote The Lord of the Rings to be one epic novel, but it was ultimately published in three volumes. The first book, The Fellowship of the Ring, begins an unforgettable saga with an influence on the fantasy genre that can't be exaggerated. Fellowship follows hobbit Frodo and his friends Sam, Pippin, and Merry as they leave their bucolic home in the Shire on a quest to destroy the Ring, on the advice of Gandalf the Wizard.",
            });

            testCatalog.add(new PersistentBook()
            {
                Title = "Dune",
                Author = "by Frank Herbert (1965)",
                CoverPath = "/covers/cover3.jpg",
                ContentPath = "/content/book3.txt",
                Description = "Welcome to a desert planet where water is more precious than gold, everyone wears moisture-preserving jumpsuits and giant worm creatures can come out of the earth's floor that can kill you at any moment. This is Dune, a stark wasteland where warring houses scheme against each other in bloody battles that can alter the course of human history. Although it's science-fiction on the surface, Frank Herbert's epic tome features the fantasy tropes of betrayal, redemption and freedom in spades, and is rightly considered one of the most important of the genre. Herbert's masterpiece not only helped to inspire Star Wars – it still resonates today, tackling environmental concerns, the rise of superpowers and rebellion of people exploited on their own land.",
            });

            testCatalog.add(new PersistentBook()
            {
                Title = "Wheel of Time : The Eye of the World",
                Author = "by Robert Jordan (1990)",
                CoverPath = "/covers/cover4.jpg",
                ContentPath = "/content/book4.txt",
                Description = "An epic fourteen novel saga, (as well as a prequel novel and two companion books), the author James Oliver Rigney Jr. (pen name Robert Jordan), published the first entry in 1990 and was still writing on his death in 2007. Too vast to summarise, the fantasy world – actually a distant version of Earth – is epic and magical, with a gigantic cast of characters. The series has spawned a video game, a roleplaying game, a soundtrack album and a forthcoming TV series, and the books have sold more than 80 million copies, making it one of the bestselling fantasy series since Lord of the Rings.",
            });

            testCatalog.add(new PersistentBook()
            {
                Title = "A Song of Ice and Fire : A Game of Thrones",
                Author = "by George R. R. Martin (1996)",
                CoverPath = "/covers/cover5.jpg",
                ContentPath = "/content/book5.txt",
                Description = "Winter is coming. Such is the stern motto of House Stark, the northernmost of the fiefdoms that owe allegiance to King Robert Baratheon in far-off King’s Landing. There Eddard Stark of Winterfell rules in Robert’s name. There his family dwells in peace and comfort: his proud wife, Catelyn; his sons Robb, Brandon, and Rickon; his daughters Sansa and Arya; and his bastard son, Jon Snow. Far to the north, behind the towering Wall, lie savage Wildings and worse—unnatural things relegated to myth during the centuries-long summer, but proving all too real and all too deadly in the turning of the season.",
            });

            testCatalog.add(new PersistentBook()
            {
                Title = "The Witcher : The Last Wish",
                Author = "by Andrzej Sapkowski (1993)",
                CoverPath = "/covers/cover6.jpg",
                ContentPath = "/content/book6.txt",
                Description = "Geralt is a Witcher, a man whose magic powers, enhanced by long training and a mysterious elixir, have made him a brilliant fighter and a merciless hunter. Yet he is no ordinary killer. His sole purpose: to destroy the monsters that plague the world. But not everything monstrous - looking is evil and not everything fair is good... and in every fairy tale there is a grain of truth.",
            });
        }

    }
}