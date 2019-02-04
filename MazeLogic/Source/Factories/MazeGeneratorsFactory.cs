using System;

namespace Maze.Logic
{
    public enum MazeGeneratorsEnum
    {
        RandomMazeGenerator,
        EmptyMazeGenerator,
        EmptyDummyMazeGenerator,
        EllerModMazeGenerator
    }

    public class MazeGeneratorsFactory
    {
        private MazeGeneratorsFactory()
        {

        }

        private static readonly MazeGeneratorsFactory instance = new MazeGeneratorsFactory();

        public static MazeGeneratorsFactory Instance
        {
            get { return instance; }
        }

        public IMazeGenerator Create(MazeGeneratorsEnum generator)
        {
            IMazeGenerator mazeGenerator;
            switch (generator)
            {
                case MazeGeneratorsEnum.EllerModMazeGenerator:
                    mazeGenerator = new EllerModMazeGenerator();
                    break;

                case MazeGeneratorsEnum.EmptyMazeGenerator:
                    mazeGenerator = new EmptyMazeGenerator();
                    break;

                case MazeGeneratorsEnum.EmptyDummyMazeGenerator:
                    mazeGenerator = new EmptyDummyMazeGenerator();
                    break;

                case MazeGeneratorsEnum.RandomMazeGenerator:
                    mazeGenerator = new RandomMazeGenerator();
                    break;

                default:
                    throw new MazeException(
                        "Не предусмотрено создание генератора лабиринта этого типа");
            }
            return mazeGenerator;
        }
    }
}
