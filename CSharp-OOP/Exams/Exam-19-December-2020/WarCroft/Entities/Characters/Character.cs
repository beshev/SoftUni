using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        // TODO: Implement the rest of the class.

        private string _name;

        protected Character
            (string name, double baseHealth, double baseArmor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseHealth = baseHealth;
            this.Health = this.BaseHealth;
            this.BaseArmor = baseArmor;
            this.Armor = this.BaseArmor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public string Name
        {
            get => this._name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

                this._name = value;
            }
        }

        public double BaseHealth { get; }

        public double Health { get; set; }

        public double BaseArmor { get; }

        public double Armor { get; private set; }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; set; }

        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();
            this.Armor -= hitPoints;
            if (this.Armor < 0)
            {
                hitPoints = Math.Abs(this.Armor);
                this.Armor = 0;
                this.Health -= hitPoints;
            }

            this.CheckIsDead();
        }

        public void CheckIsDead()
        {
            if (this.Health <= 0)
            {
                this.Health = 0;
                this.IsAlive = false;
            }
        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();
            item.AffectCharacter(this);
        }
    }
}