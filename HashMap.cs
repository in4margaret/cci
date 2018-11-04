using System;
using System.Collections.Generic;


namespace cci
{
    class HashMap<Key, Value>
    {
        // todo in generics
        private LinkedList<KeyValue<Key, Value>>[] buckets = new LinkedList<KeyValue<Key, Value>>[39];

        public void Add(Key key, Value value)
        {
            var insertValue = GetBucketIndex(key);
            LinkedList<KeyValue<Key, Value>> current = buckets[insertValue];
            if (current == null)
            {
                current = new LinkedList<KeyValue<Key, Value>>();
                buckets[insertValue] = current;
            }
            foreach (var item in current)
            {
                if (item.key.Equals(key))
                {
                    item.value = value;
                    return;
                }
            }
            KeyValue<Key, Value> newElement = new KeyValue<Key, Value> { key = key, value = value };
            current.AddLast(newElement);
        }

        public void DeleteValue(Key key)
        {
            var current = buckets[GetBucketIndex(key)];
            if (current == null)
            {
                return;
            }
            var node = current.First;
            while (node != null)
            {
                var nextNode = node.Next;
                if (node.Value.key.Equals(key))
                {
                    current.Remove(node);
                    return;
                }
                node = nextNode;
            }
        }
        public Value GetValue(Key key)
        {
            var current = buckets[GetBucketIndex(key)];
            if (current == null)
            {
                return default(Value);
            }
            foreach (var item in current)
            {
                if (item.key.Equals(key))
                {
                    return item.value;
                }
            }
            return default(Value);
        }

        private int GetBucketIndex(Key key)
        {
            var numberValue = Math.Abs(key.GetHashCode());
            var insertValue = numberValue % buckets.Length;
            return insertValue;
        }
    }

    class KeyValue<Key, Value>
    {
        public Key key;
        public Value value;

    }
}