using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBilblioteka
{
    public class LibraryManager
    {
        public List<Item> Items { get; set; } = new List<Item>();

        public async Task LoadItemsAsync(string item)
        {
            var lines = await File.ReadAllLinesAsync(item);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts[0] == "Book")
                {
                    var book = new Book(
                        int.Parse(parts[1]),
                        parts[2],
                        int.Parse(parts[3]),
                        parts[4],
                        parts[5]
                    );
                    Items.Add(book);
                }
                else if (parts[0] == "Magazine")
                {
                    var magazine = new Magazine(
                        int.Parse(parts[1]),
                        parts[2],
                        int.Parse(parts[3]),
                        int.Parse(parts[4]),
                        parts[5]
                    );
                    Items.Add(magazine);
                }
            }
        }

        public async Task SaveItemsAsync(string Item)
        {
            var lines = new List<string>();
            foreach (var item in Items)
            {
                if (item is Book book)
                {
                    lines.Add($"Book,{book.Id},{book.Title},{book.PublicationYear},{book.Author},{book.Genre}");
                }
                else if (item is Magazine magazine)
                {
                    lines.Add($"Magazine,{magazine.Id},{magazine.Title},{magazine.PublicationYear},{magazine.IssueNumber},{magazine.Publisher}");
                }
            }
            await File.WriteAllLinesAsync(Item, lines);
        }
    }
}
