﻿/*
 * Author: cintock
 * Date: 05.01.2019
 * Created by SharpDevelop.
 */

namespace Maze.Logic
{
    internal struct MazePoint
    {
        public MazePoint(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; }
        public int Col { get; }
    }
}
