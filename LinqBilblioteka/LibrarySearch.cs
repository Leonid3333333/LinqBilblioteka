using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBilblioteka
{
    public class LibrarySearch
    {
        private List<Item> _items;

        public LibrarySearch(List<Item> items)
        {
            _items = items;
        }

        public List<Book> FindBooksByAuthor(string author)
        {
            return _items.OfType<Book>().Where(b => b.Author == author).ToList();
        }

        public List<Book> FindBooksByGenre(string genre)
        {
            return _items.OfType<Book>().Where(b => b.Genre == genre).ToList();
        }

        public List<Magazine> FindMagazinesByPublisher(string publisher)
        {
            return _items.OfType<Magazine>().Where(m => m.Publisher == publisher).ToList();
        }

        public List<Magazine> FindMagazinesByYear(int year)
        {
            return _items.OfType<Magazine>().Where(m => m.PublicationYear == year).ToList();
        }
    }
}
