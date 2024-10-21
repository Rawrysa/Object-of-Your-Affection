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
                        break;
                    case Menu.search:
                        break;
                    case Menu.add:
                        break;
                    case Menu.delete:
                        break;
                    case Menu.exit:
                        exit = true;
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
                    return menuOption;
                }
                else
                {
                    Console.WriteLine("Enter a valid option");
                }
            }
        }
    }
}
