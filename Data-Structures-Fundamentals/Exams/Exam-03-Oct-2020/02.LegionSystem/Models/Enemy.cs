using _02.LegionSystem.Interfaces;

namespace _02.LegionSystem.Models
{
    public class Enemy : IEnemy
    {


        public Enemy(int attackSpeed, int health)
        {
            this.AttackSpeed = attackSpeed;
            this.Health = health;
        }

        public int AttackSpeed { get; set; }

        public int Health { get; set; }

        public int CompareTo(object obj)
        {
            var other = (IEnemy)obj;

            return other.AttackSpeed - this.AttackSpeed;
        }
    }
}
