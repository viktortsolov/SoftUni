using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private readonly List<Character> party;
        private readonly Stack<Item> pool;

        public WarController()
        {
            party = new List<Character>();
            pool = new Stack<Item>();
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
                pool.Push(item);

                return string.Format(SuccessMessages.AddItemToPool, itemName);
            }
            else if (itemName == "FirePotion")
            {
                item = new FirePotion();
                pool.Push(item);

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

            if (pool.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            var item = pool.Peek();
            character.Bag.AddItem(item);

            pool.Pop();

            return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            var character = party.FirstOrDefault(x => x.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            character.UseItem(character.Bag.GetItem(itemName));

            return string.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in party.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                string status = string.Empty;
                if (character.IsAlive)
                {
                    status = "Alive";
                }
                else
                {
                    status = "Dead";
                }
                sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {status}");
            }

            string result = sb.ToString().TrimEnd();
            return result;
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            var attacker = party.FirstOrDefault(x => x.Name == attackerName);
            var receiver = party.FirstOrDefault(x => x.Name == receiverName);
            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
            else if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            if (attacker.GetType().Name != "Warrior")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attacker.Name));
            }

            Warrior warrior = (Warrior)attacker;
            warrior.Attack(receiver);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(SuccessMessages.AttackCharacter, attackerName, receiverName, attacker.AbilityPoints, receiverName, receiver.Health, receiver.BaseHealth, receiver.Armor, receiver.BaseArmor));
            if (receiver.IsAlive == false)
            {
                sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, receiverName));
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            var healer = party.FirstOrDefault(x => x.Name == healerName);
            var healingReceiver = party.FirstOrDefault(x => x.Name == healingReceiverName);
            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }
            else if (healingReceiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }

            if (healer.GetType().Name != "Priest")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

            Priest priest = (Priest)healer;
            priest.Heal(healingReceiver);

            return string.Format(SuccessMessages.HealCharacter, healer.Name, healingReceiver.Name, healer.AbilityPoints, healingReceiver.Name, healingReceiver.Health);
        }
    }
}
