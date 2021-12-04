using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Windows;
namespace reader
{

    public class Book
    {
        string _path;
        string _name;
        string _content;
        string _category;
        string _author;
        int _price;
        StreamReader reader;

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
            reader = new(_path);

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
        }
        public int Price
        {
            get
            {
                return _price;
            }
        }
        public string Content
        {
            get
            {
                return _content;
            }

        }
        public string Author
        {
            get
            {
                return _author;
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

    }
}
