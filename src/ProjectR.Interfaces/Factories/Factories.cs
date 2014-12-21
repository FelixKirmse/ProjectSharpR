namespace ProjectR.Interfaces.Factories
{
    public static class Factories
    {
        public static void Initialize(IRFactory rFactory)
        {
            RFactory = rFactory;
        }

        public static IRFactory RFactory { get; private set; }
    }
}