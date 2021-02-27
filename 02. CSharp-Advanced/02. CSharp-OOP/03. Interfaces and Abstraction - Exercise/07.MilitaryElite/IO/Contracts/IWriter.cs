using _07.MilitaryElite.Contracts;

namespace _07.MilitaryElite.IO.Contracts
{
    public interface IWriter
    {
        void Write(string text);

        void WriteLine(ISoldier text);
    }
}
