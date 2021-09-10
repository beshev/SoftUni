namespace _01.DogVet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DogVet : IDogVet
    {
        private Dictionary<string, Dog> dogs;
        private Dictionary<string, Dictionary<string,Dog>> ownerDogs;

        public DogVet()
        {
            this.dogs = new Dictionary<string, Dog>();
            this.ownerDogs = new Dictionary<string, Dictionary<string, Dog>>();
        }

        public int Size => this.dogs.Count;

        public void AddDog(Dog dog, Owner owner)
        {
            if (this.dogs.ContainsKey(dog.Id) ||
                this.ownerDogs.ContainsKey(owner.Id) && this.ownerDogs[owner.Id].ContainsKey(dog.Name))
            {
                throw new ArgumentException();
            }

            this.dogs.Add(dog.Id, dog);
            dog.Owner = owner;

            if (!this.ownerDogs.ContainsKey(owner.Id))
            {
                this.ownerDogs.Add(owner.Id, new Dictionary<string, Dog>());
            }

            this.ownerDogs[owner.Id].Add(dog.Name,dog);
        }

        public bool Contains(Dog dog)
        {
            return this.dogs.ContainsKey(dog.Id);
        }

        public Dog GetDog(string name, string ownerId)
        {
            if (!this.ownerDogs.ContainsKey(ownerId) || !this.ownerDogs[ownerId].ContainsKey(name))
            {
                throw new ArgumentException();
            }

            return this.ownerDogs[ownerId][name];
        }

        public Dog RemoveDog(string name, string ownerId)
        {
            if (!this.ownerDogs.ContainsKey(ownerId) || !this.ownerDogs[ownerId].ContainsKey(name))
            {
                throw new ArgumentException();
            }

            var dog = this.ownerDogs[ownerId][name];

            this.ownerDogs[ownerId].Remove(dog.Name);
            this.dogs.Remove(dog.Id);

            return dog;
        }

        public IEnumerable<Dog> GetDogsByOwner(string ownerId)
        {
            if (!this.ownerDogs.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }

            return this.ownerDogs[ownerId].Values;
        }

        public IEnumerable<Dog> GetDogsByBreed(Breed breed)
        {
            var result = this.dogs.Values.Where(x => x.Breed == breed);

            if (result.Count() == 0)
            {
                throw new ArgumentException();
            }

            return result;
        }

        public void Vaccinate(string name, string ownerId)
        {
            if (!this.ownerDogs.ContainsKey(ownerId) || !this.ownerDogs[ownerId].ContainsKey(name))
            {
                throw new ArgumentException();
            }

            var dog = this.ownerDogs[ownerId][name];
            dog.Vaccines++;
        }

        public void Rename(string oldName, string newName, string ownerId)
        {
            if (!this.ownerDogs.ContainsKey(ownerId) || !this.ownerDogs[ownerId].ContainsKey(oldName))
            {
                throw new ArgumentException();
            }

            var dog = this.ownerDogs[ownerId][oldName];
            dog.Name = newName;

            this.ownerDogs[ownerId].Remove(oldName);
            this.ownerDogs[ownerId].Add(dog.Name, dog);
        }

        public IEnumerable<Dog> GetAllDogsByAge(int age)
        {
            var result = this.dogs.Values.Where(x => x.Age == age);

            if (result.Count() == 0)
            {
                throw new ArgumentException();
            }

            return result;
        }

        public IEnumerable<Dog> GetDogsInAgeRange(int lo, int hi)
        {
            var result = this.dogs.Values.Where(x => x.Age >= lo && x.Age <= hi);

            return result;
        }

        public IEnumerable<Dog> GetAllOrderedByAgeThenByNameThenByOwnerNameAscending()
        {
            return this.dogs.Values.OrderBy(x => x.Age).ThenBy(x => x.Name).ThenBy(x => x.Owner.Name);
        }
    }
}