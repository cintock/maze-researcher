namespace Maze.Logic
{
    public enum MazeClusterersEnum
    {
        MazeClustererRecursion,
        MazeClustererCyclic
    }

    public class MazeClusterersFactory
    {
        private MazeClusterersFactory()
        {
        }

        private static readonly MazeClusterersFactory instance = new MazeClusterersFactory();

        public static MazeClusterersFactory Instance { get { return instance; } }

        public IMazeClusterer Create(MazeClusterersEnum clusterer)
        {
            IMazeClusterer mazeClusterer;
            switch (clusterer)
            {
                case MazeClusterersEnum.MazeClustererRecursion:
                    mazeClusterer = new MazeClustererRecursion();
                    break;

                case MazeClusterersEnum.MazeClustererCyclic:
                    mazeClusterer = new MazeClustererCyclic();
                    break;

                default:
                    throw new MazeException(
                        "Не предусмотрено создание объекта поиска " +
                        "областей в лабиринте этого типа");

            }

            return mazeClusterer;
        }
    }
}
