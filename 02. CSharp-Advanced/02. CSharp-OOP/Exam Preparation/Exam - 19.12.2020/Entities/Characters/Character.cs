using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        // TODO: Implement the rest of the class.

        private string name;

        protected Character(string name, double health, double armor, double abilityPoints, IBag bag)
        {
            this.Name = name;

            this.BaseHealth = health;
            this.Health = this.BaseHealth;

            this.BaseArmor = armor;
            this.Armor = this.BaseArmor;

            this.AbilityPoints = abilityPoints;

            this.Bag = bag;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                this.name = value;
            }
        }

        public double BaseHealth { get; private set; }

        public double Health { get; set; }

        public double BaseArmor { get; private set; }

        public double Armor { get; private set; }

        public double AbilityPoints { get; set; }

        public IBag Bag { get; private set; }

        public bool IsAlive { get; set; } = true;

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            this.Armor -= hitPoints;
            if (this.Armor <= 0)
            {
                hitPoints = Math.Abs(this.Armor);

                this.Armor = 0;

                this.Health -= hitPoints;
                if (this.Health <= 0)
                {
                    this.Health = 0;

                    this.IsAlive = false;
                }
            }
        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();

            item.AffectCharacter(this);
        }

        public void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}