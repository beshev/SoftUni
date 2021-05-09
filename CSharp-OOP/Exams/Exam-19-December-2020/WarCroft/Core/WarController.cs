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
        private List<Character> characters;
        private Stack<Item> items;

        public WarController()
        {
            this.characters = new List<Character>();
            this.items = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            string type = args[0];
            string name = args[1];

            Character character = null;
            if (type == "Warrior")
            {
                character = new Warrior(name);
            }
            else if (type == "Priest")
            {
                character = new Priest(name);
            }

            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, type));
            }
            this.characters.Add(character);
            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string name = args[0];
            Item item = null;
            if (name == "HealthPotion")
            {
                item = new HealthPotion();
            }
            else if (name == "FirePotion")
            {
                item = new FirePotion();
            }

            if (item == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, name));
            }

            this.items.Push(item);
            return string.Format(SuccessMessages.AddItemToPool, name);
        }

        public string PickUpItem(string[] args)
        {
            string name = args[0];
            Character character = this.characters.FirstOrDefault(x => x.Name == name);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, name));
            }

            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            Item item = this.items.Pop();
            character.Bag.AddItem(item);
            return string.Format(SuccessMessages.PickUpItem, name, item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string charName = args[0];
            string itemName = args[1];

            Character character = this.characters.FirstOrDefault(x => x.Name == charName);
            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty,charName));
            }

            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);
            return string.Format(SuccessMessages.UsedItem, charName, itemName);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in this.characters.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                string status = "Alive";
                if (character.IsAlive == false)
                {
                    status = "Dead";
                }
                sb.AppendLine(string.Format(SuccessMessages.CharacterStats,
                    character.Name,
                    character.Health,
                    character.BaseHealth,
                    character.Armor,
                    character.BaseArmor,
                    status));
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string defenderName = args[1];

            Character attacker = this.characters.FirstOrDefault(x => x.Name == attackerName);
            Character defender = this.characters.FirstOrDefault(x => x.Name == defenderName);

            if (attacker == null || defender == null)
            {
                string name = attackerName;
                if (attacker != null)
                {
                    name = defenderName;
                }

                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, name));
            }

            if (attacker is IHealer)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attacker.Name));
            }

            (attacker as IAttacker).Attack(defender);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(SuccessMessages.AttackCharacter,
                attacker.Name,
                defender.Name,
                attacker.AbilityPoints,
                defender.Name,
                defender.Health,
                defender.BaseHealth,
                defender.Armor,
                defender.BaseArmor));

            if (defender.IsAlive == false)
            {
                sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, defender.Name));
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingName = args[1];

            Character healer = this.characters.FirstOrDefault(x => x.Name == healerName);
            Character healing = this.characters.FirstOrDefault(x => x.Name == healingName);

            if (healer == null || healing == null)
            {
                string name = healerName;
                if (healer != null)
                {
                    name = healingName;
                }
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, name));
            }

            if (healer is IAttacker)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healer.Name));
            }

            (healer as IHealer).Heal(healing);

            return string.Format(SuccessMessages.HealCharacter,
                healer.Name,
                healing.Name,
                healer.AbilityPoints,
                healing.Name,
                healing.Health);
        }
    }
}
