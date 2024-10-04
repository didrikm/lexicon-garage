namespace lexicon_garage.Vehicles;

public class Car : Vehicle
{
    private int _numberOfDoors;

    public int NumberOfDoors
    {
        get { return _numberOfDoors; }
        set { _numberOfDoors = value; }
    }

    public override string ToString()
    {
        return $"{base.ToString()} {_numberOfDoors}";
    }
}
