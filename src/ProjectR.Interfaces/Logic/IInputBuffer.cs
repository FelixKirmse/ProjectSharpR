namespace ProjectR.Interfaces.Logic
{
    public interface IInputBuffer
    {
        void AddChar(char character);
        void RemoveChar();

        string GetString();
        void Reset();
        int GetLength();
    }
}