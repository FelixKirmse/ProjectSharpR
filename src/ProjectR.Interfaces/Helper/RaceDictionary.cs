using System.Collections;
using System.Collections.Generic;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Interfaces.Helper
{
    public class RaceDictionary : IRaceDictionary
    {
        private readonly IDictionary<Stat, double> _stats = new Dictionary<Stat, double>();

        public RaceDictionary()
        {
            for (var stat = Stat.HP; stat < Stat.Count; ++stat)
            {
                _stats.Add(stat, 1d);
            }
        }

        public void Add(KeyValuePair<Stat, double> item)
        {
            _stats[item.Key] = item.Value;
        }

        public void Add(Stat key, double value)
        {
            _stats[key] = value;
        }

        public IEnumerator<KeyValuePair<Stat, double>> GetEnumerator()
        {
            return _stats.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) _stats).GetEnumerator();
        }

        public void Clear()
        {
            _stats.Clear();
        }

        public bool Contains(KeyValuePair<Stat, double> item)
        {
            return _stats.Contains(item);
        }

        public void CopyTo(KeyValuePair<Stat, double>[] array, int arrayIndex)
        {
            _stats.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<Stat, double> item)
        {
            return _stats.Remove(item);
        }

        public int Count { get { return _stats.Count; } }

        public bool IsReadOnly { get { return _stats.IsReadOnly; } }

        public bool ContainsKey(Stat key)
        {
            return _stats.ContainsKey(key);
        }

        public bool Remove(Stat key)
        {
            return _stats.Remove(key);
        }

        public bool TryGetValue(Stat key, out double value)
        {
            return _stats.TryGetValue(key, out value);
        }

        public double this[Stat key] { get { return _stats[key]; } set { _stats[key] = value; } }

        public ICollection<Stat> Keys { get { return _stats.Keys; } }

        public ICollection<double> Values { get { return _stats.Values; } }
    }
}