namespace ProjectR.Interfaces.Model
{
    public class BoolConsolidator
    {
        private bool _result;

        public void AddResult(bool result)
        {
            _result = _result && result;
        }

        public bool Result()
        {
            return _result;
        }
    }
}