using MilitaryElite.Enumerations;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, MissionStateEnum missionStateEnum)
        {
            MissionStateEnum = MissionStateEnum;
        }

        public string CodeName { get; }

        public MissionStateEnum MissionStateEnum { get; }


        public void CompleteMission(string missionName)
        {
            throw new System.NotImplementedException();
        }
    }
}
