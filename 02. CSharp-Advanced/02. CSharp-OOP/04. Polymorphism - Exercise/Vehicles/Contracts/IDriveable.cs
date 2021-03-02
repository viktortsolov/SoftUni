namespace Vehicles.Contracts
{
    public interface IDriveable
    {
        string Drive(double amount);
        string DriveEmpty(double amount);
    }
}
