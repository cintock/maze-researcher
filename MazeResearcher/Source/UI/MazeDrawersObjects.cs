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
        StandardMazeDrawer
    }

    internal class MazeDrawersObjects :
        ObjectsDescription<MazeDrawersEnum, IMazeDrawer>
    {
        static MazeDrawersObjects mazeDrawersNamedList =
            new MazeDrawersObjects();

        private MazeDrawersObjects()
        {
        }

        public static MazeDrawersObjects Instance()
        {
            return mazeDrawersNamedList;
        }

        protected override void RegisterObjects()
        {
            RegisterObject(MazeDrawersEnum.SimpleMazeDrawer, 
                new SimpleMazeDrawer(), 
                "Простая отрисовка (без настроек, для отладки)");

            RegisterObject(MazeDrawersEnum.StandardMazeDrawer, 
                new StandardMazeDrawer(),
                "Стандартная отрисовка");
        }
    }
}
