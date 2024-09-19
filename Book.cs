namespace Project_Library;

public class Book
{
    private string _title { get; }   //здесь по совету rider сделал поля приватными хотя они были публичными, но
    public string _author { get; }  //это поле _author оставил публичным потому что обращаюсь к нему в методе FindBookByAuthor, это норм?
    private int _year { get; }  //или лучше сделать метод GetAuthor для этого поля?

    public Book(string title, string author, int year)
    {
        _title = title;
        _author = author;
        _year = year;
    }

    public override string ToString()
    {
        return $"Author:{_author} Title:{_title} Year:{_year}";
    }
}