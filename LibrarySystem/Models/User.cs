using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Servicces
{
    public  class User
    {
        public string Id { get; set; }
        public int Role { get; set; }
        public string UserName { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is User other)
            {
                return Id == other.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
