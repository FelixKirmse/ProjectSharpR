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
            var targetConsole = target ?? RootConsole;
            Clear();
            var viewPort = camera.ViewPort;

            for (var row = 0; row <= viewPort.Height; ++row)
            {
                for (var col = 0; col <= viewPort.Width; ++ col)
                {
                    var charCell = ' ';
                    var cellColour = TCODColor.white;

                    var mapRow = viewPort.Y + row;
                    var mapCol = viewPort.X + col;

                    var cell = map[mapRow, mapCol];

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

                    foreach (var pack in from pack in mobPackManager.MobPacks
                                         let packX = pack.Position.X
                                         let packY = pack.Position.Y
                                         where mapCol == packX && mapRow == packY && player.CanSee(packX, packY)
                                         select pack)
                    {
                        charCell = 'E';

                        switch (pack.Strength)
                        {
                            case MobPackStrength.Equal:
                                cellColour = TCODColor.white;
                                break;

                            case MobPackStrength.Stronger:
                                cellColour = TCODColor.lightGreen;
                                break;

                            case MobPackStrength.Challenging:
                                cellColour = TCODColor.lighterBlue;
                                break;

                            case MobPackStrength.Elite:
                                cellColour = TCODColor.lightMagenta;
                                break;

                            case MobPackStrength.Boss:
                                cellColour = TCODColor.lightYellow;
                                break;

                            case MobPackStrength.EndBoss:
                                cellColour = TCODColor.lightRed;
                                break;

                            case MobPackStrength.TheEndOfAllThings:
                                cellColour = TCODColor.lightTurquoise;
                                break;
                        }
                    }

                    if (mapCol == player.Position.X &&
                        mapRow == player.Position.Y)
                    {
                        charCell = '@';
                        cellColour = TCODColor.white;
                    }

                    var visitedMod = .2f;

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