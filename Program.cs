// See https://aka.ms/new-console-template for more information

using Project_Library;
using static System.Console;
//Испольлзую статический метод тут потому что класс Библиотека по идее не должна отвечать за собственное отображение
//а новый класс Displayer или типа того я создавать не стал.

static void ClearConsole()
{
    Clear();
    WriteLine("\x1b[3J");
}

static void ShowMenu(int menuIndex)
{
    ClearConsole();
    string[] menuItems = new[] { "Add Book", "Remove Book", "Search Book by Author", "Show all Books", "Exit" };
    WriteLine("Welcome to the Library Program.");
    WriteLine("Choose an option by pressing <UP> and <DOWN> arrows.."); 
    for (int i = 0; i < menuItems.Length; i++)
    {
        Write($"{i + 1}.");
        Write((menuIndex == i) ? $">>{menuItems[i]}" : $"{menuItems[i]}");
        WriteLine();
    }
}

void PressAnyKey()
{
    WriteLine("Press any key to continue..");
    ReadLine();
}


Library books = new Library();
bool running = true;
int menuIndex = 0;
ConsoleKey key; //нужно внутри цикла while эту переменную объявить или тут тоже можно?
while (running)
{
    ShowMenu(menuIndex);
    key = ReadKey().Key;
    switch (key)
    {
        case ConsoleKey.UpArrow:
            menuIndex = (menuIndex == 0) ? 4 : menuIndex -= 1;
            break;

        case ConsoleKey.DownArrow:
            menuIndex = (menuIndex == 4) ? 0 : menuIndex += 1;
            break;

        case ConsoleKey.Enter:
            switch (menuIndex)
            {
                case 0:
                    ClearConsole();
                    WriteLine("Input book's Title:");
                    string userTitle = ReadLine(); //Converting null literal or possible null value into non-nullable type
                    WriteLine("Input book's Author:");//С этим надо что-то делать?
                    string userAuthor = ReadLine();
                    WriteLine("Input book's Year:");
                    if (int.TryParse(ReadLine(), out int userYear))
                    {
                        if (userYear > 0 && userYear < 2024)
                        {
                            var bookToAdd = new Book(userTitle, userAuthor, userYear);
                            books.AddBook(bookToAdd);
                            WriteLine("Book was added to the list!");
                            PressAnyKey();   
                        }
                        else
                        {
                            WriteLine("Input correct year please!");
                            PressAnyKey();
                        }
                    }
                    else
                    {
                        WriteLine("Wrong Input! Input numbers here..");
                        PressAnyKey();
                    }
                    break;
                case 1://можно ли выделенный комментарием код упаковать в метод и стоит ли это делать?
                    //-----------------------------------------------------------------------
                    ClearConsole();
                    books.ShowAllBooks();  //потому что тут внутри используются другие методы
                    WriteLine("Input number of a book you wish to remove..");
                    if (int.TryParse(ReadLine(), out int userInput)) //и ожидается ввод от пользователя
                    {
                        if (userInput > 0 && userInput <= books.GetListLength())
                        {
                            books.RemoveBook(userInput - 1);
                            WriteLine("Book was removed from the list!");
                            WriteLine("Press any key to continue..");
                            ReadLine();
                        }
                    }//-------------------------------------------------------------------------------
                    else
                    {
                        WriteLine($"Input number between 1 and {books.GetListLength()}!");
                        PressAnyKey();
                    }

                    break;
                case 2:
                    ClearConsole();
                    WriteLine("Input author's name:");
                    string searchAuthor = ReadLine();
                    if (searchAuthor.Any())
                    {
                        books.FindBookByAuthor(searchAuthor);
                    }
                    else
                    {
                        WriteLine("Book not found!");
                    }
                    PressAnyKey();
                    
                    break;
                case 3:
                    ClearConsole();
                    WriteLine("These are books in the library:");
                books.ShowAllBooks();
                    PressAnyKey();
                    break;
                case 4:
                    running = false;
                    break;
            }
            break;
    }

}



