using LibrarySystem.DBSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibrarySystem.Servicces
{
    public class Library
    {
        private BookDB _dbBooks ;
        public Library(BookDB Books)
        {
            _dbBooks =Books ;   
        }
        public void DesplayAll()
        {
            foreach (var item in _dbBooks._bookData)
            {
                PrintBook(item);
            }
        }   
        public void DesplayUnBorowBook()
        {
            foreach (var item in _dbBooks._bookData)
            {
                if (item.Borrowed==false)
                 PrintBook(item);
            }
        }
        public void Add(Book book)
        {
            if (GetBook(book.Title) is null)
            {
                _dbBooks._bookData.Add(book);
                _dbBooks.SaveBooks();
                Console.WriteLine("Book Added Successfully ");
            }
            else
            {
                Console.WriteLine("This Book Already Added !");
            }
        }
        public void Remove(string BookName)
        {
            var book = GetBook(BookName);
            if (book is null ||book.Borrowed == true)
            {
                Console.WriteLine(BookName + " is Not Founded ! ");
            }
            else
            {
                Console.WriteLine("BookName :" + BookName);

                if (book.Borrowed == true)
                {
                    Console.WriteLine("this book already Borrwd");
                }
                else if (book.Borrowed == false)
                {
                    _dbBooks._bookData.Remove(book);
                    _dbBooks.SaveBooks();
                    Console.WriteLine("Book removed from the library.");
                }
            }
                    

        }

        public Book GetBook( string name) 
        {
            foreach (var book in _dbBooks._bookData)
            {
                if (book.Title.Equals(name,StringComparison.OrdinalIgnoreCase))
                {
                    return book;
                }
            }
            return null;
        }
        public void Borrow(User u ,string name)
        {
            var book = GetBook(name);
            if (book is null)
            {
                Console.WriteLine("this not founded !");
            }
            else
            {              
                if (_dbBooks._borrowdBoks.ContainsKey(u))
                {
                    Console.WriteLine("\n*****User already borrow Befor ****\n");
                    Console.WriteLine("\n**********"+_dbBooks._borrowdBoks.ContainsKey(u).ToString()+"\t"+u.ToString()+"*********\n");
                    _dbBooks._borrowdBoks[u].Add(book);
                }
                else
                    _dbBooks._borrowdBoks.Add(u, new List<Book> { book });
                foreach (var item in _dbBooks._bookData)
                {
                    if (item.Title ==book.Title)
                    {
                        item.Borrowed = true;
                        break;
                    }
                }
                _dbBooks.SaveBooks();
                _dbBooks.SaveBorrowBooks();
                Console.WriteLine("\n\t**The book Borrowed Successfuly**");
            }
        }
        void PrintBook(Book book)
        {
            string IsBooroed = "";
            if (book.Borrowed == false)
            {
                IsBooroed = "Not Borrowed";
            }
            else if (book.Borrowed == true)
            {
                IsBooroed = "Borrowed";
            }
            Console.WriteLine(
                $"\nTitle : {book.Title}\nAuth : {book.Auth}\nYear : {book.Year}\nBook Status :{IsBooroed}");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
        }


    }
}
