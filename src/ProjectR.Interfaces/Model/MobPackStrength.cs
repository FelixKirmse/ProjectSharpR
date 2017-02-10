using libtcod;

namespace ProjectR.Interfaces.Model
{
    public enum MobPackStrength
    {
        Equal,
        Stronger,
        Challenging,
        Elite,
        Boss,
        EndBoss,
        TheEndOfAllThings
    }

    public static class MobPackStrengthExtensions
    {
        public static TCODColor GetAssociatedColour(this MobPackStrength strength)
        {
            switch (strength)
            {
                default:
                    return TCODColor.white;

                case MobPackStrength.Stronger:
                    return TCODColor.lightGreen;

                case MobPackStrength.Challenging:
                    return TCODColor.lighterBlue;

                case MobPackStrength.Elite:
                    return TCODColor.lightMagenta;

                case MobPackStrength.Boss:
                    return TCODColor.lightYellow;

                case MobPackStrength.EndBoss:
                    return TCODColor.lightRed;

                case MobPackStrength.TheEndOfAllThings:
                    return TCODColor.lightTurquoise;
            }
        }
    }
}