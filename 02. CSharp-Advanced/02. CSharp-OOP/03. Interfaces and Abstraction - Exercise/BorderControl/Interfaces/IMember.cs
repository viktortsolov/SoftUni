namespace BorderControl.Interfaces
{
    public interface IMember : ICitizen, IRobot, IPet
    {
        long Id { get; set; }
        string Birthdate { get; set; }
    }
}
