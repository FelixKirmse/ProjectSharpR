using System.Collections;
using System.Collections.Generic;

namespace ProjectR.Interfaces.Helper
{
    public class RandomContainer<T> : IEnumerable
    {
        private readonly Dictionary<T, int> _objects;
        private int _weightSum;

        public RandomContainer()
        {
            _objects = new Dictionary<T, int>();
            _weightSum = 0;
        }

        public IEnumerator GetEnumerator()
        {
            return _objects.GetEnumerator();
        }

        public void Add(T obj, int weight)
        {
            _objects[obj] = weight;
            _weightSum += weight;
        }

        public int GetWeight(T obj)
        {
            return _objects[obj];
        }

        public T Get()
        {
            var sumExtra = 0;
            var rand = RHelper.Roll(0, _weightSum - 1);
            foreach (var kvp in _objects)
            {
                if (rand < kvp.Value + sumExtra)
                {
                    return kvp.Key;
                }

                sumExtra += kvp.Value;
            }

            return default(T);
        }
    }
}