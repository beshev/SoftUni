﻿namespace HashTable
{
    using System;

    public class KeyValue<TKey, TValue>
    {

        public KeyValue(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }

        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public override bool Equals(object other)
        {
            KeyValue<TKey, TValue> element = (KeyValue<TKey, TValue>)other;
            bool equals = Object.Equals(this.Key, element.Key) && Object.Equals(this.Value, element.Value);
            return equals;
        }

        public override int GetHashCode()
        {
            return this.CombineHashCodes(this.Key.GetHashCode(), this.Value.GetHashCode());
        }

        public override string ToString()
        {
            return $" [{this.Key} -> {this.Value}]";
        }

        private int CombineHashCodes(int h1, int h2)
        {
            return ((h1 << 5) + h1) ^ h2;
        }
    }
}
