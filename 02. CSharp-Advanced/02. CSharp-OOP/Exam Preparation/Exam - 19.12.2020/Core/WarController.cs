using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private readonly List<Character> party;
        private readonly List<Item> pool;

        public WarController()
        {
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            Character character;
            if (characterType == "Warrior")
            {
                character = new Warrior(name);
                party.Add(character);

                return string.Format(SuccessMessages.JoinParty, name);
            }
            else if (characterType == "Priest")
            {
                character = new Priest(name);
                party.Add(character);

                return string.Format(SuccessMessages.JoinParty, name);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item;
            if (itemName == "HealthPotion")
            {
                item = new HealthPotion();
                pool.Add(item);

                return string.Format(SuccessMessages.AddItemToPool, itemName);
            }
            else if (itemName == "FirePotion")
            {
                item = new FirePotion();
                pool.Add(item);

                return string.Format(SuccessMessages.AddItemToPool, itemName);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            var character = party.FirstOrDefault(x => x.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
        }

        public string UseItem(string[] args)
        {
            throw new NotImplementedException();
        }

        public string GetStats()
        {
            throw new NotImplementedException();
        }

        public string Attack(string[] args)
        {
            throw new NotImplementedException();
        }

        public string Heal(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
