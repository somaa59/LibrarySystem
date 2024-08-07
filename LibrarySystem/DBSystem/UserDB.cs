using LibrarySystem.Servicces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DBSystem
{
    public class UserDB
    {
        private List<User> _users = new List<User>();
        public UserDB()
        {
            Console.WriteLine("Load Users....");
            ReadUser();
        }
        public User GetUser(string id)
        {
            foreach (var user in _users)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }
        public void Add(User user)
        {
            _users.Add(user);
            Console.WriteLine("COUNT=" + _users.Count);
            SaveUser();
            Console.WriteLine("User Added successfuly.");
            DisplayUser(user);
        }

        public void DisplayUser(User user)
        {
            Console.WriteLine($"YourDat :\n\tuserName:{user.UserName}");
            if (user.Role == 1)
            {
                Console.WriteLine($"\tEmployeeNumber:{user.Id}");
            }else
                 Console.WriteLine($"\tLibraryCardNumber:{user.Id}");
        }

        public void Remove(User user)
        {
            _users.Remove(user);
            SaveUser();
        }

        private void ReadUser()
        {
            if (File.Exists("UsersDb.txt"))
            {
                var users = File.ReadAllText("UsersDb.txt");
                foreach (var userData in users.Split(Environment.NewLine))
                {
                    if (!string.IsNullOrEmpty(userData))
                    {
                        var user = userData.Split(",");
                        _users.Add(new User {
                            Role =Convert.ToInt32(user[0]),
                            Id = user[1],
                            UserName = user[2]
                        });
                    }
                }
            }
           if (_users.Count == 0|| !File.Exists("UsersDb.txt"))
            {
                Console.WriteLine("Plz Enter the data to Register As A Librarian :");
                Console.Write("Enter Your user Name :\n>>");
                var name =Console.ReadLine();

                Add(new User
                {
                    Role = 1,
                    Id=GenerateId(200000, 300000),
                    UserName=name
                });
                SaveUser();
            }
            
            
        }
        public void SaveUser()
        {
            StringBuilder sb = new StringBuilder();
           foreach(var user in _users)
           {
                Console.WriteLine(user.UserName + " => saved ");
                sb.AppendLine($"{user.Role},{user.Id},{user.UserName}");
           }
                 File.WriteAllText("UsersDb.txt",sb.ToString());
        }
        public string GenerateId(int start, int end)
        {
            
            Random rnd = new Random();
            
            return ""+rnd.Next(start,end);
        }

    }
}
