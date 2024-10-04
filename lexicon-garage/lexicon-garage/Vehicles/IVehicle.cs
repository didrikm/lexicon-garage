using System.Runtime.CompilerServices;

namespace lexicon_garage.Vehicles;

public interface IVehicle
{
    string RegistrationNumber { get; set; }
    string Color { get; set; }
    int NumberOfWheels { get; set; }
    string FuelType { get; set; }
}
