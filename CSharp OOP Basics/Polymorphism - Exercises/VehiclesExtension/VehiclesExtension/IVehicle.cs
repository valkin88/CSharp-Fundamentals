public interface IVehicle
{
    bool IsEmpty { get; set; }
    string Type { get; }
    void Drive(double distance);
    void Refuel(double amountOfFuel);
}
