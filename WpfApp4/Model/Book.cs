using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Net;
using System.Drawing;
using System.Windows.Controls;
namespace reader
{

    public class Book
    {
        string _path;
        string _name;
        string _content;
        string _category;
        string _author;
        Uri _coverUri;
        int _price;

        StreamReader reader;

        public Book() { }
        public Book(OpenFileDialog dialog)
        {
            StreamReader reader;

            dialog.ShowDialog();

            _name = Path.GetFileNameWithoutExtension(dialog.FileName);
            reader = new(dialog.FileName);
            _content = reader.ReadToEnd();
        }
        public Book(string path)
        {
            _path = path;
            reader = new(_path, Encoding.UTF8);

            _coverUri = new Uri(reader.ReadLine(),UriKind.RelativeOrAbsolute);
            _category = reader.ReadLine();
            _author = reader.ReadLine();
           _price = Convert.ToInt32(reader.ReadLine());


            _name = Path.GetFileNameWithoutExtension(path);
            _name = _name.Replace('_', ' ');

            _content = reader.ReadToEnd();
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
            }
        }
        public int Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
            }

        }
        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
            }
        }
        public string BookPath
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
            }
        }
        public Uri BookCoverUri
        {
            get
            {
                return _coverUri;
            }
            set
            {
                _coverUri = value;
            }
        }

    }
}
