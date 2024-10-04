namespace lexicon_garage;

class Program
{
    public static void Main(string[] args)
    {
        MenuConfig garageMenuConfig = new();
        garageMenuConfig.AddOption("Create new garage", NewGarage);
        //foreach för namn på sparade dbs
        Menu garageMenu = new("Garage Menu:", garageMenuConfig);
        garageMenu.Run();
        Console.Clear();
        System.Console.WriteLine("Goodbye!");
    }

    private static void NewGarage()
    {
        System.Console.Write("Enter garage capacity: ");
        try
        {
            int capacity = int.Parse(Console.ReadLine());
            UI ui = new(capacity);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }

    private static void LoadGarage()
    {
        throw new NotImplementedException();
    }
}
