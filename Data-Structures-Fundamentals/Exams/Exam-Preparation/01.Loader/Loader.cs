namespace _01.Loader
{
    using _01.Loader.Interfaces;
    using _01.Loader.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Loader : IBuffer
    {
        private List<IEntity> entities;

        public Loader()
        {
            this.entities = new List<IEntity>();
        }

        public int EntitiesCount => this.entities.Count;

        public void Add(IEntity entity)
        {
            this.entities.Add(entity);
        }

        public void Clear()
        {
            this.entities.Clear();
        }

        public bool Contains(IEntity entity)
        {
            return this.entities.Contains(entity);
        }

        public IEntity Extract(int id)
        {
            for (int i = 0; i < this.entities.Count; i++)
            {
                if (this.entities[i].Id == id)
                {
                    var current = this.entities[i];
                    this.entities.Remove(current);
                    return current;
                }
            }

            return null;
        }

        public IEntity Find(IEntity entity)
        {
            if (entities.Contains(entity))
            {
                return entity;
            }

            return null;
        }

        public List<IEntity> GetAll()
        {
            return new List<IEntity>(entities);
        }

        public IEnumerator<IEntity> GetEnumerator()
        {
            return this.entities.GetEnumerator();
        }

        public void RemoveSold()
        {
            var withoutSold = new List<IEntity>();

            for (int i = 0; i < this.entities.Count; i++)
            {
                if (this.entities[i].Status != BaseEntityStatus.Sold)
                {
                    withoutSold.Add(this.entities[i]);
                }
            }

            this.entities = withoutSold;
        }

        public void Replace(IEntity oldEntity, IEntity newEntity)
        {
            var indexOfOld = this.entities.IndexOf(oldEntity);

            VadilIndex(indexOfOld);

            this.entities[indexOfOld] = newEntity;
        }

        public List<IEntity> RetainAllFromTo(BaseEntityStatus lowerBound, BaseEntityStatus upperBound)
        {
            List<IEntity> result = new List<IEntity>();

            for (int i = 0; i < this.entities.Count; i++)
            {
                if (this.entities[i].Status >= lowerBound && this.entities[i].Status <= upperBound)
                {
                    result.Add(this.entities[i]);
                }
            }

            return result;
        }

        public void Swap(IEntity first, IEntity second)
        {
            var indexOfFirst = this.entities.IndexOf(first);
            var indexOfSecond = this.entities.IndexOf(second);

            VadilIndex(indexOfFirst);
            VadilIndex(indexOfSecond);

            var temp = first;
            this.entities[indexOfFirst] = second;
            this.entities[indexOfSecond] = temp;
        }

        public IEntity[] ToArray()
        {
            return this.entities.ToArray();
        }

        public void UpdateAll(BaseEntityStatus oldStatus, BaseEntityStatus newStatus)
        {
            for (int i = 0; i < this.entities.Count; i++)
            {
                if (this.entities[i].Status == oldStatus)
                {
                    this.entities[i].Status = newStatus;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.entities.GetEnumerator();
        }

        private void VadilIndex(int index)
        {
            if (index < 0)
            {
                throw new InvalidOperationException("Entity not found");
            }
        }

    }
}
