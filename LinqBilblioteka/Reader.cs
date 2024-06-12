using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBilblioteka
{
    public class Reader
    {
        public int ReaderId { get; set; }
        public string Name { get; set; }
        public List<Item> BorrowedItems { get; set; }

        public Reader(int readerId, string name)
        {
            ReaderId = readerId;
            Name = name;
            BorrowedItems = new List<Item>();
        }

        public void BorrowItem(Item item)
        {
            BorrowedItems.Add(item);
        }

        public void ReturnItem(Item item)
        {
            BorrowedItems.Remove(item);
        }
    }
}
