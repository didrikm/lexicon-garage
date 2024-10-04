namespace lexicon_garage.Garage;

public interface IHandler<T>
    where T : Vehicle
{
    void AddVehicle();
    void RemoveVehicle();
    void SelectVehicles();
    void WriteAll();
}
