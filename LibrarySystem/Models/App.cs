using LibrarySystem.DBSystem;
namespace LibrarySystem.Servicces
{
    public static class App
    {
        private static  Library library;
        private static  UserDB  dbUser ;
        public static void Run(string[] args)
        {
            library = new Library(new BookDB());
            dbUser = new UserDB();
            while (true) { 
                Console.WriteLine("\t\t******* Welcom at our LibrarySystem *******\n");
               
                
                Console.WriteLine("Are you Librarin or RegularUser !");
                Console.WriteLine("PLZ Select one option from this :");
                Console.Write("[1] Librarin\n" +
                              "[2] RegularUser\n" +
                              "[3] Exit\n>>");
                char userType = Console.ReadLine()[0];
                if (userType == '1')
                {
                    var user =Validate(userType);
                    if(user is null)
                    {   
                        Console.WriteLine("Invalid user GoodBye !");
                        break;
                    }
                    Console.WriteLine("\t\t*****Welcom Mr." + user.UserName + "******\n\n");

                    Librarian l1 =new Librarian();

                    //librarianServices
                    bool flage = true;
                    while (flage)
                    {
                        Console.WriteLine("PLZ Select one option from this :");
                        Console.Write("[A] Add new regularUser\n" +
                                      "[B] Add new Book\n" +
                                      "[R] Remove book\n" +
                                      "[D] Desplay\n" +
                                      "[E] Exit\n>>");
  
                        char choice = Console.ReadLine().ToUpper()[0];
                        switch (choice) 
                        {
                            case 'A':
                                Console.Write("Enter user naem : ");
                                string username = Console.ReadLine();
                                Console.Write("Enter user Role : ");
                                int userRole = Convert.ToInt32(Console.ReadLine());
                                l1.AddUser(new User
                                {
                                    Role=userRole,
                                    Id=dbUser.GenerateId(1,10000),
                                    UserName=username
                                },dbUser);
                                break;
                            case 'B':
                                Console.WriteLine("Enter book details : ");
                                Console.Write("\t Book Name : ");
                                string name =Console.ReadLine();
                                Console.Write("\t Book Auth : ");
                                string auth =Console.ReadLine();
                                Console.Write("\t Book Year : ");
                                int year =Convert.ToInt32(Console.ReadLine());
                            
                                l1.AddBook(new Book { 
                                    Title =name,
                                    Auth=auth,
                                    Year=year,
                                    Borrowed=false
                                   } , library);
                                break;
                            case 'R':
                                Console.Write("Enter The Book Title To Deleted it : ");
                                string title =Console.ReadLine();
                                l1.RemoveBook(title,library);
                                break;
                            case 'D':
                                l1.DisplayBooks(library);
                                break;
                            case 'E':
                                flage = false;
                                break;
                            default: Console.WriteLine("Enter correct choice !");
                                break;
                               
                    }
                        
                    }
                    
                }
                else if (userType == '2') 
                {
                    var user = Validate(userType);
                    if (user is null)
                    {
                        Console.WriteLine("Invalid user GoodBye !");
                        break;
                    }
                    Console.WriteLine("\t\t*****Welcom Mr." + user.UserName+"******\n\n");
                    LibraryUser user1 = new LibraryUser();
                    bool flage2 = true;
                    while (flage2)
                    {
                        Console.WriteLine("PLZ Select one option from this :");
                        Console.Write("[D] Display All un Borow books\n" +
                                      "[B] Borrow a new book\n" +
                                      "[E] Exit\n>>");

                        char choice2 = Console.ReadLine().ToUpper()[0];
                        switch (choice2)
                        {
                            case 'D':
                                user1.DisplayBook(library);
                                if (user1 is null)
                                {
                                    Console.WriteLine("All Books are Borrowed !");
                                }
                                break;
                            case 'B':
                                Console.Write("enter name book to borrow it :");
                                string n = Console.ReadLine();
                                user1.BorrowBook(user, n, library);
                                break;
                            case 'E':
                                flage2 = false;
                                break;

                        }
                    }
    
                    
                }
                else if (userType =='3')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Choise ! Plz enter correct value [ 1 or 2 or 3]");
                }
            }
        }
        public static User Validate( char type)
        {
            Console.Write("Plz enter your Code : ");
            string code = Console.ReadLine();
            
            var user = dbUser.GetUser(code);
            if (user is not null)
            {
                if (user.Role == (type-'0'))
                    return user;
                else
                    Console.WriteLine("Access Denied !");
            }
            
            return null;
        }

      
    }
}
