using WildFarm.Models.Foods;

namespace WildFarm.Contracts
{
    public interface IFeedable
    {
        void Feed(Food food);
    }
}
