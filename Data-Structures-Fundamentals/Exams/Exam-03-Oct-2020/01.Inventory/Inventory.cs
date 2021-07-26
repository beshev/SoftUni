namespace _01.Inventory
{
    using _01.Inventory.Interfaces;
    using _01.Inventory.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Inventory : IHolder
    {
        private List<IWeapon> weapons;
        private Node<IWeapon> root;
        public Inventory()
        {
            this.weapons = new List<IWeapon>();
        }


        public int Capacity => this.weapons.Count;


        public void Add(IWeapon weapon)
        {
            this.weapons.Add(weapon);
        }

        public void Clear()
        {
            this.weapons.Clear();
        }

        public bool Contains(IWeapon weapon)
        {
            return this.weapons.Contains(weapon);
        }

        public void EmptyArsenal(Category category)
        {
            foreach (var weapon in this.weapons)
            {
                if (weapon.Category == category)
                {
                    weapon.Ammunition = 0;
                }
            }
        }

        public bool Fire(IWeapon weapon, int ammunition)
        {
            var curr = this.GetById(weapon.Id);

            ValideteIfNull(curr);

            if (curr.Ammunition < ammunition)
            {
                return false;
            }

            curr.Ammunition -= ammunition;


            return true;
        }

        public IWeapon GetById(int id)
        {
            if (this.root == null)
            {
                BalanseTree();
            }

            return BSTGetById(id, this.root);
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < this.weapons.Count; i++)
            {
                yield return this.weapons[i];
            }
        }

        public int Refill(IWeapon weapon, int ammunition)
        {
            var curr = this.GetById(weapon.Id);


            ValideteIfNull(curr);

            if (curr.Ammunition + ammunition > curr.MaxCapacity)
            {
                ammunition = curr.MaxCapacity - curr.Ammunition;
            }

            curr.Ammunition += ammunition;

            return ammunition;
        }

        public IWeapon RemoveById(int id)
        {
            var weapon = this.GetById(id);

            ValideteIfNull(weapon);

            this.weapons.Remove(weapon);

            return weapon;
        }

        public int RemoveHeavy()
        {
            var removedWeapons = this.weapons.RemoveAll(x => x.Category == Category.Heavy);

            return removedWeapons;
        }

        public List<IWeapon> RetrieveAll()
        {
            return this.weapons.Select(x => x).ToList();
        }


        public List<IWeapon> RetriveInRange(Category lower, Category upper)
        {
            return this.weapons.Where(x => x.Category >= lower && x.Category <= upper).ToList();
        }

        public void Swap(IWeapon firstWeapon, IWeapon secondWeapon)
        {
            var first = GetById(firstWeapon.Id);
            var second = GetById(secondWeapon.Id);

            ValideteIfNull(first);
            ValideteIfNull(second);

            if (first.Category == second.Category)
            {
                var firstIndex = this.weapons.IndexOf(first);
                var secondIndex = this.weapons.IndexOf(second);

                var temp = first;
                this.weapons[firstIndex] = this.weapons[secondIndex];
                this.weapons[secondIndex] = first;
            }
        }


        private void ValideteIfNull(IWeapon weapon)
        {
            if (weapon == null)
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }
        }

        public virtual Node<IWeapon> buildTreeUtil(List<IWeapon> nodes, int start, int end)
        {
            // base case
            if (start > end)
            {
                return null;
            }

            /* Get the middle element and make it root */
            int mid = (start + end) / 2;
            Node<IWeapon> node = new Node<IWeapon>(nodes[mid]);

            /* Using index in Inorder traversal, construct
               left and right subtress */
            node.leftChild = buildTreeUtil(nodes, start, mid - 1);
            node.rightChild = buildTreeUtil(nodes, mid + 1, end);

            return node;
        }



        //-------------------------\\
        private List<IWeapon> BSTGetAll(Node<IWeapon> root)
        {
            List<IWeapon> result = new List<IWeapon>();

            result.Add(root.Value);

            if (root.leftChild != null)
            {
                result.AddRange(BSTGetAll(root.leftChild));
            }

            if (root.rightChild != null)
            {
                result.AddRange(BSTGetAll(root.rightChild));
            }

            return result;
        }


        private void BalanseTree()
        {
            this.root = buildTreeUtil(this.weapons.OrderBy(x => x.Id).ToList(), 0, this.weapons.Count - 1);
        }


        private IWeapon BSTGetById(int id, Node<IWeapon> root)
        {
            if (root == null)
            {
                return null;
            }

            if (root.Value.Id.Equals(id))
            {
                return root.Value;
            }


            if (id.CompareTo(root.Value.Id) < 0)
            {
                return BSTGetById(id, root.leftChild);
            }
            else
            {
                return BSTGetById(id, root.rightChild);
            }

        }
        //-------------------------\\

    }
}
