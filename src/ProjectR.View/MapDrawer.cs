using System.Drawing;
using System.Linq;
using libtcod;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.View;

namespace ProjectR.View
{
    public class MapDrawer : RConsole, IMapDrawer
    {
        private int _posX;
        private int _posY;

        public MapDrawer()
            : base(RootConsole.Width, RootConsole.Height)
        {
        }

        public void SetPosition(int x, int y)
        {
            _posX = x;
            _posY = y;
        }

        public void DrawMap(IRMap map, IOverworldCamera camera, IOverworldPlayer player, IMobPackManager mobPackManager,
                            IStatistics statistics, IRConsole target = null)
        {
            IRConsole targetConsole = target ?? RootConsole;
            Clear();
            Rectangle viewPort = camera.ViewPort;

            for (int row = 0; row <= viewPort.Height; ++row)
            {
                for (int col = 0; col <= viewPort.Width; ++ col)
                {
                    char charCell = ' ';
                    TCODColor cellColour = TCODColor.white;

                    int mapRow = viewPort.Y + row;
                    int mapCol = viewPort.X + col;

                    RCell cell = map[mapRow, mapCol];

                    cellColour = GetRarityColour(cell, cellColour);

                    if (cell.Is(RCell.Wall))
                    {
                        charCell = '#';
                    }

                    if (cell.Is(RCell.Floor))
                    {
                        charCell = '.';
                    }

                    if (cell.Is(RCell.Door))
                    {
                        charCell = 'D';
                    }

                    if (cell.Is(RCell.Small))
                    {
                        charCell = 'S';
                    }

                    if (cell.Is(RCell.Normal))
                    {
                        charCell = 'N';
                    }

                    if (cell.Is(RCell.Big))
                    {
                        charCell = 'B';
                    }

                    if (cell.Is(RCell.Grand))
                    {
                        charCell = 'G';
                    }

                    if (cell.Is(RCell.Portal))
                    {
                        charCell = 'O';
                    }

                    foreach (IMobPack pack in from pack in mobPackManager.MobPacks
                                              let packX = pack.Position.X
                                              let packY = pack.Position.Y
                                              where mapCol == packX && mapRow == packY && player.CanSee(packX, packY)
                                              select pack)
                    {
                        charCell = 'E';

                        cellColour = pack.Strength.GetAssociatedColour();
                    }

                    if (mapCol == player.Position.X &&
                        mapRow == player.Position.Y)
                    {
                        charCell = '@';
                        cellColour = TCODColor.white;
                    }

                    float visitedMod = .2f;

                    if (player.CanSee(mapCol, mapRow))
                    {
                        if (!cell.Is(RCell.Visited))
                        {
                            statistics.AddToStatistic(Statistic.SquaresRevealed, 1);
                        }

                        visitedMod = 1f;
                        cell |= RCell.Visited;
                    }

                    if (cell.Is(RCell.Dark))
                    {
                        visitedMod *= 0.5f;
                    }

                    if (!cell.Is(RCell.Visited))
                    {
                        continue;
                    }

                    cellColour = cellColour.Multiply(visitedMod);

                    SetCharacter(col, row, charCell, cellColour);
                }
            }

            targetConsole.Blit(this, Bounds, _posX, _posY);
        }

        private static TCODColor GetRarityColour(RCell cell, TCODColor defaultColour)
        {
            if (cell.Is(RCell.Uncommon))
            {
                return TCODColor.lightGreen;
            }

            if (cell.Is(RCell.Rare))
            {
                return TCODColor.lighterBlue;
            }

            if (cell.Is(RCell.Epic))
            {
                return TCODColor.lightMagenta;
            }

            if (cell.Is(RCell.Legendary))
            {
                return TCODColor.lightYellow;
            }

            if (cell.Is(RCell.Artifact))
            {
                return TCODColor.lightRed;
            }

            return defaultColour;
        }
    }
}