namespace lexicon_garage.UserInterface;

public class UI : IUI
{
    private Garage<Vehicle> _garage;
    private GarageHandler<Vehicle> _garageHandler;

    public UI(int garageCapacity)
    {
        _garage = new(garageCapacity);
        _garageHandler = new(_garage);

        MenuConfig mainMenuConfig = new();
        mainMenuConfig.AddOption("Add vehicle", AddVehicle);
        mainMenuConfig.AddOption("Remove vehicle by registration number", RemoveVehicle);
        mainMenuConfig.AddOption("Select vehicles by attributes", SelectVehicles);
        mainMenuConfig.AddOption("Print out all vehicle types and their count", WriteTypes);
        mainMenuConfig.AddOption("Print out all vehicles", WriteAll);

        Menu mainMenu = new("Main menu:", mainMenuConfig);
        mainMenu.Run();
        //Här sparas
        Console.Clear();
        System.Console.WriteLine("Goodbye!");
    }

    public void AddVehicle()
    {
        _garageHandler.AddVehicle();
    }

    public void RemoveVehicle()
    {
        _garageHandler.RemoveVehicle();
    }

    public void SelectVehicles()
    {
        _garageHandler.SelectVehicles();
    }

    public void WriteTypes()
    {
        _garageHandler.WriteTypes();
    }

    public void WriteAll()
    {
        _garageHandler.WriteAll();
    }
}
