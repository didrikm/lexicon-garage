namespace lexicon_garage.Utils;

public class Menu
{
    private string header;
    private List<string> options;
    private List<Action> actions;

    public Menu(string menuHeader, MenuConfig config)
    {
        header = menuHeader;
        options = config.Options;
        actions = config.Actions;
    }

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            PrintMenu();
            string choice = Console.ReadLine() ?? string.Empty;

            if (choice == "0")
            {
                break;
            }
            else if (int.TryParse(choice, out int index) && index > 0 && index <= options.Count)
            {
                actions[index - 1].Invoke();
            }
            else
            {
                Console.WriteLine("\nInvalid input. Please try again.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }

    private void PrintMenu()
    {
        System.Console.WriteLine(header);
        Console.WriteLine("\nMenu Options:");
        for (int i = 0; i < options.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {options[i]}");
        }
        Console.WriteLine("0. Exit");
        Console.Write("\nEnter your choice: ");
    }
}
