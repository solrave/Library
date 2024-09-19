using static System.Console;
namespace Project_Library;

public class Library
{
    private List<Book> _bookShelf; //rider предлагает сделать это поле readonly, но ведь я буду изменять список через AddBook()
    public Library()
    {
        _bookShelf = new List<Book>()
        {
            new Book ("Fandango", "Alex Grin", 1954),
            new Book ("Martin Iden", "Jack London", 1876),
            new Book ("Little Prince", "Antuan Exuperi", 1925),
            new Book ("Little Prince", "Antuan Exuperi", 1925) //одинаковые книги добавлены чтобы показать что поиск по имени автора выдаст все совпадения
        };
    }

    public void AddBook(Book book) => _bookShelf.Add(book);
    
    public void RemoveBook(int value) => _bookShelf.RemoveAt(value);

    public int GetListLength() => _bookShelf.Count;
    
    public void ShowAllBooks()
    {
        WriteLine("________________________________________");
        for (int i = 0; i < _bookShelf.Count; i++)
        {
            WriteLine($"{i+1}. {_bookShelf[i]}");
        }
        WriteLine("________________________________________");
    }
    
    public void FindBookByAuthor(string title)
    {
        var searchList = _bookShelf.FindAll(b => b._author.IndexOf(title, StringComparison.OrdinalIgnoreCase ) >= 0);
        if (searchList.Count > 0)
        {
            WriteLine("These books were found:");
            foreach (var book in searchList)
            {
                WriteLine(book);
            }
        }
        else
        {
            WriteLine("Book not found!");
        }
    }
    
}