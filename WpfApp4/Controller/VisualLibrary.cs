using reader.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace reader.Controller
{
    // -- не изменять !!
    public class VisualLibrary : INotifyPropertyChanged
    {

        ObservableCollection<VisualBook> visual = new ObservableCollection<VisualBook>();
        public ObservableCollection<VisualBook> VisualBooks
        {
            get { return visual; }
        }

        PersistentLibrary library;

        public VisualBook selectedBook { get; set; } 

        public event PropertyChangedEventHandler? PropertyChanged;

        public void init()
        {
            library = new PersistentLibrary();
            library.load();

            foreach (PersistentBook b in library.Books)
            {
                visual.Add(new VisualBook
                {
                    persistentBook = b,
                    Cover = createCover(b.CoverPath),
                    Content = createContent(b.ContentPath)
                });
            }

        }

        public void saveToJson(VisualLibrary visualLibrary)
        {
            library = new PersistentLibrary();
            foreach (VisualBook b in visualLibrary.VisualBooks)
            {
                library.add(b.persistentBook);
            }

            library.save();
        }

        public BitmapImage createCover(string path)
        {
            return new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
        }

        public string createContent(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }

        }

    }
}
