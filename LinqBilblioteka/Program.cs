using LinqBilblioteka;
using System.ComponentModel;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var libraryManager = new LibraryManager();
        await libraryManager.LoadItemsAsync("items.txt");

        var search = new LibrarySearch(libraryManager.Items);

        var booksByAuthor = search.FindBooksByAuthor("George Orwell");
        var magazinesByPublisher = search.FindMagazinesByPublisher("Forbes Media");
        var booksByYear = search.FindMagazinesByYear(2022);

        PrintAllItems(libraryManager.Items);

        var reader = new Reader(1, "John Doe");
        var reader1 = new Reader(2, "Anna Shmit");
        //Reader.Add(new reader (2, "Anna));
        reader.BorrowItem(booksByAuthor.First());
        reader.BorrowItem(booksByAuthor.First());
        reader.BorrowItem(magazinesByPublisher.First());
        reader.BorrowItem(booksByAuthor.First());
        reader.BorrowItem(magazinesByPublisher.First());
        reader.BorrowItem(magazinesByPublisher.First());
        reader.BorrowItem(booksByYear.First());

        reader1.BorrowItem(magazinesByPublisher.First());
        reader1.BorrowItem(booksByYear.First());

        PrintAllReadersAndBorrowedItems(new List<Reader> { reader1 });
    }

    public static void PrintAllItems(List<Item> items)
    {
        foreach (var item in items)
        {
            if (item is Book book)
            {
                Console.WriteLine($"Book: {book.Title} by {book.Author} ({book.PublicationYear}) - {book.Genre}");
            }
            else if (item is Magazine magazine)
            {
                Console.WriteLine($"Magazine: {magazine.Title} ({magazine.PublicationYear}) - Issue {magazine.IssueNumber}, Published by {magazine.Publisher}");
            }
        }
    }

    public static void PrintAllReadersAndBorrowedItems(List<Reader> readers)
    {
        foreach (var reader in readers)
        {
            Console.WriteLine($"Reader: {reader.Name} (ID: {reader.ReaderId})");
            foreach (var item in reader.BorrowedItems)
            {
                Console.WriteLine($"\tBorrowed Item: {item.Title} ({item.PublicationYear})");
            }
        }
    }
}