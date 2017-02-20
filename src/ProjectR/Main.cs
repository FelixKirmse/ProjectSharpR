using System.Globalization;
using System.Threading;
using ProjectR.Factory;
using ProjectR.Interfaces.Factories;

namespace ProjectR
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

            Factories.Initialize(new RFactory());
            IProjectR game = new ProjectR();
            game.SetupGameStructure();
            game.RunGame();
            return 0;
        }
    }
}