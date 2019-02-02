using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maze.Logic;

namespace Maze.UI
{
    internal class MazeGeneratorsFactory
    {
        private MazeGeneratorsFactory()
        {

        }

        private static MazeGeneratorsFactory instance = new MazeGeneratorsFactory();

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
                    throw new ArgumentException(
                        "Не предусмотрено создание генератора лабиринта этого типа");
            }
            return mazeGenerator;
        }
    }
}
