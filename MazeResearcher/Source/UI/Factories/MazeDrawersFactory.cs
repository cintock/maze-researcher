using Maze.Logic;

namespace Maze.UI
{
    public enum MazeDrawersEnum
    {
        SimpleMazeDrawer,
        StandardMazeDrawer,
        CellDebugMazeDrawer,
        EmptyMazeDrawer,
        SolidSidesDrawer
    }

    public class MazeDrawersFactory
    {
        private MazeDrawersFactory()
        {

        }

        private static MazeDrawersFactory instance = new MazeDrawersFactory();

        public static MazeDrawersFactory Instance { get { return instance; } }

        public IMazeDrawer Create(MazeDrawersEnum drawer)
        {
            IMazeDrawer mazeDrawer;

            switch (drawer)
            {
                case MazeDrawersEnum.SimpleMazeDrawer:
                    mazeDrawer = new SimpleMazeDrawer();
                    break;

                case MazeDrawersEnum.StandardMazeDrawer:
                    mazeDrawer = new StandardMazeDrawer();
                    break;

                case MazeDrawersEnum.CellDebugMazeDrawer:
                    mazeDrawer = new CellDebugMazeDrawer();
                    break;

                case MazeDrawersEnum.EmptyMazeDrawer:
                    mazeDrawer = new EmptyMazeDrawer();
                    break;

                case MazeDrawersEnum.SolidSidesDrawer:
                    mazeDrawer = new SolidSidesDrawer();
                    break;

                default:
                    throw new MazeException("Не предусмотрено создание отображения лабиринта такого типа");
            }

            return mazeDrawer;
        }
    }
}
