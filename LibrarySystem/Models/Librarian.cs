using LibrarySystem.DBSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Servicces
{
    public class Librarian 
    {
       public void AddUser(User user,UserDB db)
       {
            db.Add(user) ;

       }
        public void AddBook(Book book,Library library)
       {
            library.Add(book); ;

       }
        public void RemoveBook(string bookName, Library library)
        {
            library.Remove(bookName);
        }
        public void DisplayBooks(Library library) {
            library.DesplayAll();
        }
       
        
    }
}