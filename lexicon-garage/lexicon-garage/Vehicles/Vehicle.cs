namespace lexicon_garage.Vehicles;

public abstract class Vehicle : IVehicle
{
    private string _registrationNumber;
    private string _color;
    private int _numberOfWheels;
    private string _fuelType;

    public string RegistrationNumber { get; set; }

    public string Color
    {
        get { return _color; }
        set { _color = value; }
    }

    public int NumberOfWheels
    {
        get { return _numberOfWheels; }
        set { _numberOfWheels = value; }
    }

    public string FuelType
    {
        get { return _fuelType; }
        set { _fuelType = value; }
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} {_registrationNumber} {_color} {_numberOfWheels} {_fuelType}";
    }
}
