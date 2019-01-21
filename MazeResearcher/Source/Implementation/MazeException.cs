using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze.Implementation
{
    class MazeException : Exception
    {
        public MazeException()
        {
        }

        public MazeException(string message) : 
            base(message)
        {
        }

        public MazeException(string message, Exception inner) :
            base(message, inner)
        {
        }
    }
}
