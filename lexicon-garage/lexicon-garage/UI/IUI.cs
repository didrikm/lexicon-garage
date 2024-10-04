namespace lexicon_garage.UserInterface;

public interface IUI
{
    //först ska alla sparade garage läsas in från JSON
    //menyval om man vill använda en av de befintliga eller skapa ny
    //sedan allt nedan
    //En garagehandler, flera utbytbara garage
    void WriteAll();
    void WriteTypes();
    void AddVehicle();
    void RemoveVehicle();
    void SelectVehicles(); //Borde bytas till void också
}
