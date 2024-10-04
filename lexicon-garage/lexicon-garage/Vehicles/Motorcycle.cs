namespace lexicon_garage.Vehicles;

public class Motorcycle : Vehicle
{
    private bool _hasSidecar;

    public bool HasSidecar
    {
        get { return _hasSidecar; }
        set { _hasSidecar = value; }
    }
}
