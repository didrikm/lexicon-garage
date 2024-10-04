namespace lexicon_garage.Vehicles;

public class Boat : Vehicle
{
    private int _lengthInFeet;

    public int LengthInFeet
    {
        get { return _lengthInFeet; }
        set { _lengthInFeet = value; }
    }
}
