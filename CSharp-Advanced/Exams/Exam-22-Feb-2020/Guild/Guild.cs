using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }

        public string Name { get; }

        public int Capacity { get; }

        public int Count { get { return this.roster.Count; } }

        public void AddPlayer(Player player)
        {
            if (this.roster.Count < Capacity)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player current = this.roster.FirstOrDefault(p => p.Name == name);
            if (current != null)
            {
                this.roster.Remove(current);
                return true;
            }
            return false;
        }

        public void PromotePlayer(string name)
        {
            Player current = this.roster.FirstOrDefault(p => p.Name == name);
            if (current != null && current.Rank != "Member")
            {
                current.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player current = this.roster.FirstOrDefault(p => p.Name == name);
            if (current != null && current.Rank != "Trial")
            {
                current.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            Player[] result = this.roster.FindAll(p => p.Class == @class).ToArray();
            this.roster.RemoveAll(p => p.Class == @class);
            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in roster)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
