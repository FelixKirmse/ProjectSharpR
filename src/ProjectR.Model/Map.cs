using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class Map<T> : IMap<T>
    {
        private const int ColumnCount = 1000;
        private const int RowCount = 1000;
        private readonly T[] _map = new T[RowCount * ColumnCount];

        public int Columns { get { return 1000; } }
        public int Rows { get { return 1000; } }

        public T this[int row, int col]
        {
            get { return _map[row * ColumnCount + col]; }
            set { _map[row * ColumnCount + col] = value; }
        }
    }
}