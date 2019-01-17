using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maze.Implementation;

namespace Maze.UI
{
    internal enum MazeDrawersEnum
    {
        SimpleMazeDrawer,
        StandardMazeDrawer,
        CellDebugMazeDrawer
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
        }

        public static MazeDrawersObjects Instance()
        {
            return mazeDrawersNamedList;
        }
    }
}
