using LibrarySystem.Servicces;
using System.Text;

namespace LibrarySystem.DBSystem
{
    public class BookDB
    {
        public Dictionary<User, List<Book> >_borrowdBoks = new Dictionary<User, List<Book> >();
        public List<Book> _bookData = new();
        public BookDB()
        {
            Console.WriteLine("Load Books....");
            ReadBooks();     
            ReadBorrowBooks();
        }
        public void ReadBooks()
        {
            if (File.Exists("BookDB.txt"))
            {
                var Allbooks = File.ReadAllText("BookDB.txt");
                foreach (var bookLine in Allbooks.Split(Environment.NewLine))
                {
                    if (!string.IsNullOrEmpty(bookLine))
                    {
                        var book = bookLine.Split(",");
                      //  Console.WriteLine(book.Length);

                        _bookData.Add(new Book
                        {
                            Title = book[0],
                            Auth = book[1],
                            Year = Convert.ToInt32(book[2]),
                            Borrowed = Convert.ToBoolean(book[3])
                        });
                    }
                }
            }
            else
            {
                Console.WriteLine("No Booke Added yet !");
            }
        }
        public void SaveBooks()
        {
            var sp = new StringBuilder();
            foreach (var item in _bookData)
            {
                sp.AppendLine($"{item.Title},{item.Auth},{item.Year},{item.Borrowed}");
            }  
                File.WriteAllText("BookDB.txt",sp.ToString());
        }

        public void ReadBorrowBooks()
        {
            if (File.Exists("BorrowBooksDB.txt"))
            {
                var AllData = File.ReadAllText("BorrowBooksDB.txt");
                foreach (var items in AllData.Split(Environment.NewLine))
                {
                    if (!string.IsNullOrEmpty(items))
                    {
                        var dict = items.Split(":");
                        var userData = dict[0];
                        var booksData = dict[1];

                        var data = userData.Split(",");
                       // Console.WriteLine($"****\n{userData} \n {data[0] } , {data[1] }{data[2] }\n******");
                        var user = new User
                        {
                            Role = Convert.ToInt32(data[0]),
                            Id = data[1],
                            UserName = data[2]
                        };

                        List<Book> books = new List<Book>();
                        foreach (var bookItem in booksData.Split("#"))
                        {
                            if (!string.IsNullOrEmpty(bookItem))
                            {
                                var book = bookItem.Split(",");
                                books.Add(new Book
                                {
                                    Title = book[0],
                                    Auth = book[1],
                                    Year = Convert.ToInt32(book[2]),
                                    Borrowed = Convert.ToBoolean(book[3])
                                });
                            }
                        }
                        _borrowdBoks.Add(user, books);
                    }
                }
            }
        }
        public void SaveBorrowBooks()
        {
            var sp = new StringBuilder();
            var spBook = new StringBuilder();
            foreach(var item in _borrowdBoks) 
            {
                var user = item.Key;
                var books = item.Value;
                for (int i = 0; i < books.Count; i++)
                {
                    spBook.Append($"{books[i].Title},{books[i].Auth},{books[i].Year},{books[i].Borrowed}#");      
                }
                sp.AppendLine($"{user.Role},{user.Id},{user.UserName}:{spBook.ToString()}");
                spBook.Clear();
            }
            File.WriteAllText("BorrowBooksDB.txt", sp.ToString());
        }
    
    }
}
