namespace HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
    {
        private LinkedList<KeyValue<TKey, TValue>>[] elements;
        private const float LoadFactor = 0.75f;
        private const int InitialCapacity = 16;

        public HashTable()
        {
            this.elements = new LinkedList<KeyValue<TKey, TValue>>[InitialCapacity];
        }

        public HashTable(int capacity)
        {
            this.elements = new LinkedList<KeyValue<TKey, TValue>>[capacity];
        }

        public int Count { get; private set; }

        public int Capacity => elements.Length;

        public IEnumerable<TKey> Keys
        {
            get
            {
                return this.elements.Where(x => x != null).SelectMany(x => x.Select(k => k.Key));
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                return this.elements.Where(x => x != null).SelectMany(x => x.Select(v => v.Value));
            }
        }

        public TValue this[TKey key]
        {
            get => this.Get(key);
            set => this.AddOrReplace(key, value);
        }

        public void Add(TKey key, TValue value)
        {
            // Note: throw an exception on duplicated key
            ResizeIfNeeded();

            var index = this.GetIndex(key);

            if (this.elements[index] == null)
            {
                this.elements[index] = new LinkedList<KeyValue<TKey, TValue>>();
            }

            foreach (var element in this.elements[index])
            {
                if (element.Key.Equals(key))
                {
                    throw new ArgumentException();
                }
            }

            var newLelemnt = new KeyValue<TKey, TValue>(key, value);
            this.elements[index].AddLast(newLelemnt);
            this.Count++;
        }

        public bool AddOrReplace(TKey key, TValue value)
        {
            ResizeIfNeeded();

            var index = this.GetIndex(key);

            if (this.elements[index] == null)
            {
                this.elements[index] = new LinkedList<KeyValue<TKey, TValue>>();
            }

            foreach (var element in this.elements[index])
            {
                if (element.Key.Equals(key))
                {
                    element.Value = value;
                    return false;
                }
            }

            var newLelemnt = new KeyValue<TKey, TValue>(key, value);
            this.elements[index].AddLast(newLelemnt);
            this.Count++;
            return true;
        }

        public TValue Get(TKey key)
        {
            // Note: throw an exception on missing key
            var element = this.Find(key);
            if (element == null)
            {
                throw new KeyNotFoundException();
            }

            return element.Value;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var element = this.Find(key);

            if (element == null)
            {
                value = default(TValue);
                return false;
            }

            value = element.Value;
            return true;
        }

        public KeyValue<TKey, TValue> Find(TKey key)
        {
            var index = this.GetIndex(key);

            if (this.elements[index] != null)
            {
                foreach (var element in this.elements[index])
                {
                    if (element.Key.Equals(key))
                    {
                        return element;
                    }
                }
            }

            return null;
        }

        public bool ContainsKey(TKey key)
        {
            var element = this.Find(key);

            return element != null;
        }

        public bool Remove(TKey key)
        {
            int index = this.GetIndex(key);
            var element = this.Find(key);

            if (element == null)
            {
                return false;
            }

            this.Count--;
            this.elements[index].Remove(element);
            return true;
        }

        public void Clear()
        {
            Array.Clear(this.elements, 0, this.elements.Length);
            this.Count = 0;
        }

        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            foreach (var list in this.elements.Where(x => x != null))
            {
                foreach (var element in list)
                {
                    yield return element;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void ResizeIfNeeded()
        {
            if ((float)(this.Count + 1) / this.Capacity >= LoadFactor)
            {
                var newHashTable = new HashTable<TKey, TValue>(this.Capacity * 2);

                foreach (var element in this)
                {
                    newHashTable.Add(element.Key, element.Value);
                }

                this.elements = newHashTable.elements;
                this.Count = newHashTable.Count;
            }
        }

        private int GetIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode() % this.elements.Length);
        }
    }
}
