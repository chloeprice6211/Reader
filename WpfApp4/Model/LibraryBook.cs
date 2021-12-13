using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace reader.Model
{
    // -- не изменять !!
    // -- класс для хранения, основной
    public class PersistentBook : IEquatable<PersistentBook>
    {
        public string ContentPath { get; set; }
        public string CoverPath { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }

        public bool Equals(PersistentBook other)
        {
            // Complex is a value type, thus we don't have to check for null
            // if (other == null) return false;

            return (this.Title == other.Title)
                && (this.Author == other.Author);
        }

        public override bool Equals(object other)
        {
            // other could be a reference type, the is operator will return false if null
            if (other is PersistentBook)
                return this.Equals((PersistentBook)other);
            else
                return false;
        }



        public int GetHashCode(PersistentBook obj)
        {
            if (object.ReferenceEquals(obj, null)) return 0;

            int hashCodeTitle = obj.Title == null ? 0 : obj.Title.GetHashCode();
            int hasCodeAuthor = obj.Author.GetHashCode();

            return hashCodeTitle ^ hasCodeAuthor;
        }
    }

    // -- класс для работы с визуализацией
    public class VisualBook
    {
        public PersistentBook persistentBook { get; set; }
        public string Content { get; set; }
        public BitmapImage Cover { get; set; }

    }

}