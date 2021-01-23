namespace BorderControl.Interfaces
{
    public interface IMember : ICitizen, IRobot
    {
        string Id { get; set; }
    }
}
