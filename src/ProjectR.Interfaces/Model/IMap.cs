namespace ProjectR.Interfaces.Model
{
    public interface IMap<T>
    {
        int Columns { get; }
        int Rows { get; }

        T this[int row, int col] { get; set; }
    }
}