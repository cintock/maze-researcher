using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maze.Implementation;

namespace Maze.UI
{
    enum MazeClusterersEnum
    {
        MazeClustererRecursion,
        MazeClusterer
    }

    class MazeClustererObjects : ObjectsDescription<MazeClusterersEnum, IMazeClusterer>
    {
        private static readonly MazeClustererObjects instance = new MazeClustererObjects();

        private MazeClustererObjects()
        {
            RegisterObject(
                MazeClusterersEnum.MazeClustererRecursion,
                new MazeClustererRecursion(), 
                "Простой рекурсивный алгоритм");

            RegisterObject(
                MazeClusterersEnum.MazeClusterer, 
                new MazeClusterer(), 
                "Новый алгоритм поиска областей");
        }

        public static MazeClustererObjects Instance()
        {
            return instance;
        }
    }
}
