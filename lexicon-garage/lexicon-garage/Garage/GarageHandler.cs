namespace lexicon_garage.Garage;

using System;

public class GarageHandler<T> : IHandler<Vehicle>
    where T : IVehicle
{
    private Garage<Vehicle> _garage;

    public GarageHandler(Garage<Vehicle> garage)
    {
        _garage = garage;
    }

    public void AddVehicle()
    {
        //gör reg unikt
        System.Console.Write("Enter vehicle type (Car, Airplane, Boat, Bus, Motorcycle): ");
        string vehicleType = Console.ReadLine();

        System.Console.Write(
            "Enter vehicle data (RegistrationNumber Color NumberOfWheels FuelType): "
        );
        string input = Console.ReadLine().ToLower();
        string[] vehicleData = input.Split(' ');

        if (vehicleData.Length != 4)
        {
            System.Console.WriteLine("Invalid input. Please enter data in the correct format.");
            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }

        Vehicle vehicle = null;

        //Måste lägga till felhantering för alla unika props
        switch (vehicleType.ToLower())
        {
            case "car":
                System.Console.Write("Enter number of doors: ");
                int numberOfDoors = int.Parse(Console.ReadLine());
                vehicle = new Car
                {
                    RegistrationNumber = vehicleData[0],
                    Color = vehicleData[1],
                    NumberOfWheels = int.Parse(vehicleData[2]),
                    FuelType = vehicleData[3],
                    NumberOfDoors = numberOfDoors,
                };
                break;
            case "airplane":
                System.Console.Write("Enter number of engines: ");
                int numberOfEngines = int.Parse(Console.ReadLine());
                vehicle = new Airplane
                {
                    RegistrationNumber = vehicleData[0],
                    Color = vehicleData[1],
                    NumberOfWheels = int.Parse(vehicleData[2]),
                    FuelType = vehicleData[3],
                    NumberOfEngines = numberOfEngines,
                };
                break;
            case "boat":
                System.Console.Write("Enter length in feet: ");
                int lengthInFeet = int.Parse(Console.ReadLine());
                vehicle = new Boat
                {
                    RegistrationNumber = vehicleData[0],
                    Color = vehicleData[1],
                    NumberOfWheels = int.Parse(vehicleData[2]),
                    FuelType = vehicleData[3],
                    LengthInFeet = lengthInFeet,
                };
                break;
            case "bus":
                System.Console.Write("Enter number of seats: ");
                int numberOfSeats = int.Parse(Console.ReadLine());
                vehicle = new Bus
                {
                    RegistrationNumber = vehicleData[0],
                    Color = vehicleData[1],
                    NumberOfWheels = int.Parse(vehicleData[2]),
                    FuelType = vehicleData[3],
                    NumberOfSeats = numberOfSeats,
                };
                break;
            case "motorcycle":
                System.Console.Write("Does the motorcycle have a sidecar(Y/N): ");
                string yOrN = Console.ReadLine().ToLower();
                bool hasSidecar = false;
                if (yOrN == "y")
                    hasSidecar = true;
                else if (yOrN == "n")
                    hasSidecar = false;
                else
                {
                    System.Console.WriteLine("\nInvalid input.\nPress any key to continue...");
                    Console.ReadKey();
                }
                vehicle = new Motorcycle
                {
                    RegistrationNumber = vehicleData[0],
                    Color = vehicleData[1],
                    NumberOfWheels = int.Parse(vehicleData[2]),
                    FuelType = vehicleData[3],
                    HasSidecar = hasSidecar,
                };
                break;
            default:
                System.Console.WriteLine("Invalid vehicle type.");
                return;
        }
        _garage.AddVehicle(vehicle);
    }

    public void RemoveVehicle()
    {
        System.Console.Write("Enter the registration number of the vehicle you wish to remove: ");
        string regNumber = Console.ReadLine().ToLower();
        _garage.RemoveVehicle(regNumber);
    }

    public void SelectVehicles()
    {
        System.Console.WriteLine("Enter vehicle type (or leave blank to skip:)");
        string type = Console.ReadLine();
        if (!string.IsNullOrEmpty(type))
        {
            type = string.Concat(type[0].ToString().ToUpper(), type.Substring(1).ToLower());
        }

        Console.WriteLine("Enter vehicle color (or leave blank to skip):");
        string color = Console.ReadLine().ToLower();

        Console.WriteLine("Enter number of wheels (or leave blank to skip):");
        string numberOfWheelsInput = Console.ReadLine();
        int numberOfWheels = 0;
        if (
            !string.IsNullOrEmpty(numberOfWheelsInput)
            && !int.TryParse(numberOfWheelsInput, out numberOfWheels)
        )
        {
            Console.WriteLine("Invalid input for number of wheels.");
            return;
        }

        Console.WriteLine("Enter fuel type (or leave blank to skip):");
        string fuelType = Console.ReadLine().ToLower();

        Func<Vehicle, bool> predicate = vehicle =>
            (string.IsNullOrEmpty(type) || vehicle.GetType().Name == type)
            && (string.IsNullOrEmpty(color) || vehicle.Color == color)
            && (numberOfWheels == 0 || vehicle.NumberOfWheels == numberOfWheels)
            && (string.IsNullOrEmpty(fuelType) || vehicle.FuelType == fuelType);

        foreach (Vehicle vehicle in _garage.SelectVehicles(predicate))
        {
            System.Console.WriteLine(vehicle);
        }
        System.Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void WriteTypes()
    {
        var vehicleCounts = _garage
            .GroupBy(v => v.GetType())
            .Select(g => new { Type = g.Key, Count = g.Count() });

        foreach (var count in vehicleCounts)
        {
            Console.WriteLine($"{count.Type.Name}: {count.Count}");
        }
        System.Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void WriteAll()
    {
        System.Console.WriteLine("All vehicles currently in the garage:\n");
        foreach (Vehicle vehicle in _garage)
        {
            Console.WriteLine($"Registration Number: {vehicle.RegistrationNumber}");
            Console.WriteLine($"Color: {vehicle.Color}");
            Console.WriteLine($"Number of Wheels: {vehicle.NumberOfWheels}");
            Console.WriteLine($"Fuel Type: {vehicle.FuelType}");

            if (vehicle is Airplane airplane)
            {
                Console.WriteLine($"Number of Engines: {airplane.NumberOfEngines}");
            }
            else if (vehicle is Motorcycle motorcycle)
            {
                Console.WriteLine($"Has Sidecar: {motorcycle.HasSidecar}");
            }
            else if (vehicle is Car car)
            {
                Console.WriteLine($"Number of Doors: {car.NumberOfDoors}");
            }
            else if (vehicle is Bus bus)
            {
                Console.WriteLine($"Number of Seats: {bus.NumberOfSeats}");
            }
            else if (vehicle is Boat boat)
            {
                Console.WriteLine($"Length in Feet: {boat.LengthInFeet}");
            }

            Console.WriteLine();
        }
        System.Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
