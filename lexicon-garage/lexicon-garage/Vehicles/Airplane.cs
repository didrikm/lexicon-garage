namespace lexicon_garage.Vehicles;

public class Airplane : Vehicle
{
    private int _numberOfEngines;

    public int NumberOfEngines
    {
        get { return _numberOfEngines; }
        set { _numberOfEngines = value; }
    }
}
