using Maze.Logic;

namespace Maze.UI
{
    internal enum MazeDrawersEnum
    {
        SimpleMazeDrawer,
        StandardMazeDrawer,
        CellDebugMazeDrawer,
        EmptyMazeDrawer
    }

    internal class MazeDrawersObjects :
        ObjectsDescription<MazeDrawersEnum, IMazeDrawer>
    {
        static readonly MazeDrawersObjects mazeDrawersNamedList =
            new MazeDrawersObjects();

        private MazeDrawersObjects()
        {
            RegisterObject(MazeDrawersEnum.SimpleMazeDrawer,
                new SimpleMazeDrawer(),
                "Простая отрисовка (без настроек, для отладки)");

            RegisterObject(MazeDrawersEnum.StandardMazeDrawer,
                new StandardMazeDrawer(),
                "Стандартная отрисовка");

            RegisterObject(MazeDrawersEnum.CellDebugMazeDrawer,
                new CellDebugMazeDrawer(),
                "Отладка содержимого ячеек");

            RegisterObject(MazeDrawersEnum.EmptyMazeDrawer,
                new EmptyMazeDrawer(),
                "Пустое отображение (для отладки)");
        }

        public static MazeDrawersObjects Instance()
        {
            return mazeDrawersNamedList;
        }
    }
}
