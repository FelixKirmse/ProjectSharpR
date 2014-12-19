namespace ProjectR
{
    public class Program
    {
        public static int Main(string[] args)
        {
            IProjectR game = new ProjectR();
            game.SetupGameStructure();
            game.RunGame();
            return 0;
        }
    }
}