namespace _02.LegionSystem
{
    using _02.LegionSystem.Interfaces;
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class Legion : IArmy
    {
        private OrderedSet<IEnemy> enemies;

        public Legion()
        {
            this.enemies = new OrderedSet<IEnemy>();
        }

        public int Size => this.enemies.Count;

        public bool Contains(IEnemy enemy)
        {
            return this.enemies.Contains(enemy);
        }

        public void Create(IEnemy enemy)
        {
            this.enemies.Add(enemy);
        }

        public IEnemy GetByAttackSpeed(int speed)
        {
            for (int i = 0; i < this.enemies.Count; i++)
            {
                var enemy = this.enemies[i];
                if (enemy.AttackSpeed == speed)
                {
                    return enemy;
                }
            }

            return null;
        }

        public List<IEnemy> GetFaster(int speed)
        {
            var result = new List<IEnemy>();

            foreach (var enemy in this.enemies)
            {
                if (enemy.AttackSpeed > speed)
                {
                    result.Add(enemy);
                }
            }

            return result;
        }

        public IEnemy GetFastest()
        {
            this.EnsureNotEmpty();

            return this.enemies.GetFirst();
        }

        public IEnemy[] GetOrderedByHealth()
        {
            var orderedBag = new OrderedBag<IEnemy>(this.enemies, OrderByHeath);

            return orderedBag.ToArray();
        }

        public List<IEnemy> GetSlower(int speed)
        {
            var result = new List<IEnemy>();

            foreach (var enemy in this.enemies)
            {
                if (enemy.AttackSpeed < speed)
                {
                    result.Add(enemy);
                }
            }

            return result;
        }

        public IEnemy GetSlowest()
        {
            return this.enemies.GetLast();
        }

        public void ShootFastest()
        {
            this.enemies.RemoveFirst();
        }

        public void ShootSlowest()
        {
            this.enemies.RemoveLast();
        }


        private int OrderByHeath(IEnemy first,IEnemy second)
        {
            return second.Health - first.Health;
        }

        private void EnsureNotEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }
        }
    }
}
