namespace _02.Data
{
    using _02.Data.Interfaces;
    using _02.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Data : IRepository
    {
        private OrderedSet<IEntity> entities;
        private Dictionary<int, List<IEntity>> parents;

        public Data()
        {
            this.entities = new OrderedSet<IEntity>();
            parents = new Dictionary<int, List<IEntity>>();
        }

        public Data(OrderedSet<IEntity> entities)
        {
            this.entities = entities;
        }

        public int Size => this.entities.Count;

        public void Add(IEntity entity)
        {
            this.entities.Add(entity);

            if (entity.ParentId != null)
            {
                if (!this.parents.ContainsKey(entity.ParentId.Value))
                {
                    this.parents.Add(entity.ParentId.Value, new List<IEntity>() { entity });
                }
                else
                {
                    this.parents[entity.ParentId.Value].Add(entity);
                }
            }
        }

        public IRepository Copy()
        {
            return new Data(this.entities);
        }

        public IEntity DequeueMostRecent()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Operation on empty Data");
            }

            return this.entities.RemoveFirst();
        }

        public List<IEntity> GetAll()
        {
            return this.entities.ToList();
        }

        public List<IEntity> GetAllByType(string type)
        {
            if (type != "Invoice" && type != "StoreClient" && type != "User")
            {
                throw new InvalidOperationException("Invalid type: " + type);
            }

            var result = new List<IEntity>();

            for (int i = 0; i < this.entities.Count; i++)
            {
                if (this.entities[i].GetType().Name == type)
                {
                    result.Add(entities[i]);
                }
            }

            return result;
        }

        public IEntity GetById(int id)
        {
            return GetId(this.entities, 0, this.Size - 1, id);
        }

        public List<IEntity> GetByParentId(int parentId)
        {
            var result = new List<IEntity>();

            if (this.parents.ContainsKey(parentId))
            {
                result = this.parents[parentId];
            }

            return result;
        }

        public IEntity PeekMostRecent()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Operation on empty Data");
            }

            return this.entities.GetFirst();
        }

        private IEntity GetId(OrderedSet<IEntity> entities, int start, int end, int id)
        {
            if (start > end)
            {
                return null;
            }

            int middle = (start + end) / 2;

            if (entities[middle].Id < id)
            {
                return GetId(entities, 0, middle - 1, id);
            }
            else if (entities[middle].Id > id)
            {
                return GetId(entities, middle + 1, end, id);
            }
            else
            {
                return this.entities[middle];
            }
        }
    }
}
