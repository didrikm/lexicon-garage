namespace lexicon_garage.Vehicles;

public class Bus : Vehicle
{
    private int _numberOfSeats;

    public int NumberOfSeats
    {
        get { return _numberOfSeats; }
        set { _numberOfSeats = value; }
    }
}
