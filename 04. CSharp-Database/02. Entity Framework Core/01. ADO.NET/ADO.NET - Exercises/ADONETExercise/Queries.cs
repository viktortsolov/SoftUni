namespace ADONETExercise
{
    public static class Queries
    {
        public const string VILLAINS_WITH_MORE_THAN_3_MINIONS = 
            @"  SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                    FROM Villains AS v 
                JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                 GROUP BY v.Id, v.Name 
                 HAVING COUNT(mv.VillainId) > 3 
                 ORDER BY COUNT(mv.VillainId)";

        public const string VILLAIN_NAME_BY_ID =
            @"SELECT Name 
                FROM Villains 
               WHERE Id = @Id";

        public const string VILLAIN_MINIONS_INFO_BY_ID =
            @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

        public const string ID_BY_TOWN_NAME =
            @"SELECT Id From Towns
               WHERE Name = @townName";

        public const string INSERT_TOWN =
            @"INSERT INTO Towns (Name) Values (@townName)";

        public const string ID_BY_VILLAIN_NAME =
            @"SELECT Id FROM Villains
               WHERE Name = @Name";

        public const string INSERT_VILLAINS =
            @"INSERT INTO Villains (Name, EvilnessFactorId)
                VALUES (@villainName, 4)";

        public const string INSERT_MINION =
            @"INSERT INTO Minions (Name, Age, TownId) 
                VALUES (@name, @age, @townId)";

        public const string ID_BY_MINION_NAME =
            @"SELECT Id 
                FROM Minions 
               WHERE Name = @name";

        public const string INSERT_MINION_VILLAIN =
            @"INSERT INTO MinionsVillains (VillainId, MinionId) 
                VALUES (@villainId, @minionId)";
    }
}
