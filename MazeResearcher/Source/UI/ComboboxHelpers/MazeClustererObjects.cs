using Maze.Implementation;

namespace Maze.UI
{
    enum MazeClusterersEnum
    {
        MazeClustererRecursion,
        MazeClustererCyclic
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
                MazeClusterersEnum.MazeClustererCyclic, 
                new MazeClustererCyclic(), 
                "Циклический алгоритм");
        }

        public static MazeClustererObjects Instance()
        {
            return instance;
        }
    }
}
