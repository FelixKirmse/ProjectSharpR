using System.Text;
using ProjectR.Interfaces.Logic;

namespace ProjectR.Logic
{
    public class InputBuffer : IInputBuffer
    {
        private readonly char[] _buffer;
        private int _pos;

        public InputBuffer()
        {
            _pos = 0;
            _buffer = new char[255];
        }

        public void AddChar(char character)
        {
            _buffer[_pos] = character;
            ++_pos;
        }

        public void RemoveChar()
        {
            if (_pos != 0)
            {
                --_pos;
            }
        }

        public string GetString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < _pos; ++i)
            {
                sb.Append(_buffer[i]);
            }
            return sb.ToString();
        }

        public void Reset()
        {
            _pos = 0;
        }

        public int GetLength()
        {
            return _pos;
        }
    }
}