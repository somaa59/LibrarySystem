using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Servicces
{
    public class Book
    {
        public string Title { get; set; }
        public string Auth { get; set; }
        public int Year { get; set; }
        public bool Borrowed { get; set; }   
    }
}
