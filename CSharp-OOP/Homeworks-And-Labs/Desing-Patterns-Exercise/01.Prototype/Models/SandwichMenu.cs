using System.Collections.Generic;

namespace _01.Prototype.Models
{
    public class SandwichMenu
    {
        private Dictionary<string, SandwichPrototype> sandwiches = new Dictionary<string, SandwichPrototype>();

        public SandwichPrototype this[string name]
        {
            get { return this.sandwiches[name]; }
            set { this.sandwiches.Add(name, value); }
        }
    }
}
