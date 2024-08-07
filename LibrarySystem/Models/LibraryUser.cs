using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Servicces
{
    public class LibraryUser : User
    {
        public void DisplayBook(Library l)
        {
            l.DesplayUnBorowBook();
        }
        public void BorrowBook( User user ,string bookName,Library l)
        {
           l.Borrow(user,bookName);
        }
       
    }
}
