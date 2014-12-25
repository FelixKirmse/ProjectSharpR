namespace ProjectR.Interfaces.Factories
{
    public static class Factories
    {
        public static IRFactory RFactory { get; private set; }

        public static void Initialize(IRFactory rFactory)
        {
            RFactory = rFactory;
        }
    }
}