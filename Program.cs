namespace Object_of_Your_Affection
{
    enum Menu
    {
        view = 1,
        search,
        add,
        delete,
        exit
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            do
            {
                PrintMenu();

                switch (MenuOption())
                {
                    case Menu.view:
                        View();
                        break;
                    case Menu.search:
                        Search();   
                        break;
                    case Menu.add:
                        Add();
                        break;
                    case Menu.delete:
                        Delete();
                        break;
                    case Menu.exit:
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
            while (!exit);
        }

        static void PrintMenu()
        {
            Console.WriteLine("------------------------------------------------------------------------" +
            "\nObject of Your Affection" +
            "\n------------------------------------------------------------------------");
            Console.WriteLine("1. View all users");
            Console.WriteLine("2. Search for user");
            Console.WriteLine("3. Add a new profile");
            Console.WriteLine("4. Delete a profile");
            Console.WriteLine("5. Exit");
        }

        static Menu MenuOption()
        {
            while (true)
            {
                int.TryParse(Console.ReadLine(), out int option);

                if (Enum.IsDefined(typeof(Menu), option))
                {
                    Menu menuOption = (Menu)option;
                    Console.Clear();
                    return menuOption;
                }
                else
                {
                    Console.WriteLine("Enter a valid option");
                }
            }
        }

        static void View()
        {
            if (Profile.Profiles.Count > 0)
            {
                Profile.Profiles.ForEach(x => x.ViewProfile());
            }
            else
            {
                Console.WriteLine("No profiles added yet");
            }
        }

        static void Search()
        {
            Console.WriteLine("Enter the username");
            if (Profile.SearchProfile(Console.ReadLine(), out List<Profile> results))
            {
                results.ForEach(x => x.ViewProfile());
            }
            else
            {
                Console.WriteLine("The user does not exist");
            }
        }

        static void Add()
        {
            Console.WriteLine("Enter the username");
            string username = Console.ReadLine();
            while (true)
            {
                if (Profile.SearchProfile(username) == true)
                {
                    Console.WriteLine("\nThe username already exists, please enter a unique one\n");
                    username = Console.ReadLine();
                }
                else { break; }
            }
            Console.WriteLine("\nEnter the city");
            string city = Console.ReadLine();
            Console.WriteLine("\nEnter the age");
            int age = Int32.Parse(Console.ReadLine());
            Console.WriteLine("\nList out your hobbies seperated by commas");
            string hobbies = Console.ReadLine();
            Console.WriteLine("\nEnter your pronouns");
            string pronouns = Console.ReadLine();

            Profile.CreateProfile(username, city, age, hobbies, pronouns);

            Console.WriteLine("The user has been added");
        }

        static void Delete()
        {
            Console.WriteLine("Enter the username");
            if (Profile.DeleteProfile(Console.ReadLine()))
            {
                Console.WriteLine("The user has been deleted");
            }
            else
            {
                Console.WriteLine("The user does not exist");
            }
        }
    }
}
