using System.Collections;

namespace lexicon_garage.Garage;

public class Garage<T> : IEnumerable<T>
    where T : Vehicle
{
    private T[] _vehicles;

    public Garage(int capacity)
    {
        _vehicles = new T[capacity];
    }

    public void AddVehicle(T vehicle)
    {
        int index = Array.IndexOf(_vehicles, null);

        if (index >= 0)
        {
            _vehicles[index] = vehicle;
            System.Console.WriteLine(
                $"{vehicle.GetType().Name} {vehicle.RegistrationNumber} was successfully added."
            );
            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        else
        {
            System.Console.WriteLine(
                "Garage is full. Unable to add vehicle.\nPress any key to continue..."
            );
            Console.ReadKey();
        }
    }

    public void RemoveVehicle(string regNumber)
    {
        int index = Array.FindIndex(_vehicles, v => v.RegistrationNumber == regNumber);

        if (index >= 0)
        {
            _vehicles[index] = null;
            System.Console.WriteLine(
                $"Vehicle {regNumber} has been deleted.\nPress any key to continue..."
            );
            Console.ReadKey();
        }
        else
        {
            System.Console.WriteLine("Vehicle not found.");
        }
    }

    public IEnumerable<T> SelectVehicles(Func<T, bool> predicate)
    {
        return _vehicles.OfType<T>().Where(predicate);
    }

    public int Count
    {
        get { return _vehicles.Count(vehicle => vehicle != null); }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _vehicles.OfType<T>().Where(vehicle => vehicle != null).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
