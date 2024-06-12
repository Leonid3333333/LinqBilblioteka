using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBilblioteka
{
    public class Book : Item, IBorrowable
    {
        public string Author { get; set; }
        public string Genre { get; set; }

        public Book(int id, string title, int publicationYear, string author, string genre)
            : base(id, title, publicationYear)
        {
            Author = author;
            Genre = genre;
        }

        public void Borrow(Reader reader)
        {
            reader.BorrowItem(this);
        }

        public void Return(Reader reader)
        {
            reader.ReturnItem(this);
        }
    }
}
