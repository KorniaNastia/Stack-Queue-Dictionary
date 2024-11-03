public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public decimal Price { get; set; }

    public Book(string title, string author, decimal price)
    {
        Title = title;
        Author = author;
        Price = price;
    }

    public override string ToString()
    {
        return $"Title: {Title}, Author: {Author}, Price: {Price:C}";
    }
}

// Клас для управління магазином книг
public class BookStore
{
    private Dictionary<int, Book> books = new Dictionary<int, Book>();

    // Додавання нової книги до словника
    public void AddBook(int id, Book book)
    {
        if (!books.ContainsKey(id))
        {
            books[id] = book;
            Console.WriteLine($"Book '{book.Title}' added with ID {id}.");
        }
        else
        {
            Console.WriteLine($"Book ID {id} already exists.");
        }
    }

    // Видалення книги зі словника за її унікальним ідентифікатором
    public void RemoveBook(int id)
    {
        if (books.Remove(id))
        {
            Console.WriteLine($"Book with ID {id} removed.");
        }
        else
        {
            Console.WriteLine($"Book with ID {id} not found.");
        }
    }

    // Отримання інформації про книгу за її унікальним ідентифікатором
    public void GetBookInfo(int id)
    {
        if (books.TryGetValue(id, out Book book))
        {
            Console.WriteLine($"Book Info: {book}");
        }
        else
        {
            Console.WriteLine($"Book with ID {id} not found.");
        }
    }
}

// Головна програма
class Program
{
    static void Main(string[] args)
    {
        BookStore bookStore = new BookStore();

        // Створюємо кілька книг
        Book book1 = new Book("1984", "George Orwell", 9.99m);
        Book book2 = new Book("To Kill a Mockingbird", "Harper Lee", 7.99m);
        Book book3 = new Book("The Great Gatsby", "F. Scott Fitzgerald", 10.99m);

        // Додаємо книги до словника
        bookStore.AddBook(1, book1);
        bookStore.AddBook(2, book2);
        bookStore.AddBook(3, book3);

        // Отримуємо інформацію про книгу
        bookStore.GetBookInfo(1);
        bookStore.GetBookInfo(2);

        // Видаляємо книгу
        bookStore.RemoveBook(2);

        // Спробуємо отримати інформацію про видалену книгу
        bookStore.GetBookInfo(2);

        // Видаляємо ще одну книгу
        bookStore.RemoveBook(3);

        // Перевіряємо інформацію про всі книги
        bookStore.GetBookInfo(1);
        bookStore.GetBookInfo(3);
    }
}
