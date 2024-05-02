using Models;
using MongoDB.Driver;

namespace Migrations
{
    public class KnightsContextSeed
    {
        public static void SeedData(IMongoCollection<Knight> mongoCollection)
        {
            bool existKnight = mongoCollection.Find(p => true).Any();

            if (!existKnight)
                mongoCollection.InsertManyAsync(GetPreconfiguredKnights());
        }

        private static IEnumerable<Knight> GetPreconfiguredKnights()
        {
            return
            [
                new() 
                {
                    Name = "Wyll",
                    Nickname = "Blade of Frontier",
                    Birthday = new DateTime(2000, 1, 1),
                    Weapons = [
                        new() { Name = "Sword", Mod = 6, Attr = "Charisma", Equipped = true }
                    ],
                    Attributes = new Attributes
                    {
                        Str = 8,
                        Dex = 13,
                        Con = 14,
                        Int = 13,
                        Wis = 10,
                        Cha = 17
                    },
                    KeyAttribute = "Charisma"
                },
                new() 
                {
                    Name = "Astarion",
                    Nickname = "the Decadent",
                    Birthday = new DateTime(1837, 1, 1),
                    Weapons = [
                        new() { Name = "Crossbow", Mod = 4, Attr = "Dexterity", Equipped = true },
                        new() { Name = "Shield", Mod = 3, Attr = "Constitution", Equipped = false }
                    ],
                    Attributes = new Attributes
                    {
                        Str = 8,
                        Dex = 17,
                        Con = 14,
                        Int = 13,
                        Wis = 13,
                        Cha = 10
                    },
                    KeyAttribute = "Dexterity"
                },
                new()
                {
                    Name = "Karlach",
                    Nickname = "Fury of Avernus",
                    Birthday = new DateTime(2020, 1, 1),
                    Weapons =
                    [
                        new() { Name = "Battleaxe", Mod = 8, Attr = "Strength", Equipped = true }
                    ],
                    Attributes = new Attributes
                    {
                        Str = 17,
                        Dex = 13,
                        Con = 15,
                        Int = 8,
                        Wis = 12,
                        Cha = 10
                    },
                    KeyAttribute = "Strength"
                },
                new()
                {
                    Name = "Shadowheart",
                    Nickname = "Dark Justiciar",
                    Birthday = new DateTime(1992, 1, 1),
                    Weapons =
                    [
                        new() { Name = "Mace", Mod = 2, Attr = "Strenght", Equipped = true }
                    ],
                    Attributes = new Attributes
                    {
                        Str = 13,
                        Dex = 13,
                        Con = 14,
                        Int = 10,
                        Wis = 17,
                        Cha = 8
                    },
                    KeyAttribute = "Wisdom"
                },
            ];
        }
    }
}