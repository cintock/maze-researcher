﻿/*
 * Author: cintock
 * Date: 05.01.2019
 * Created by SharpDevelop.
 */

namespace Maze.Logic
{
    /// <summary>
    /// Класс для хранения лабиринта
    /// </summary>
    public class MazeData : BaseMazeData
    {
        private readonly MazeSide[,] mazeMatrix;

        public MazeData(int row, int col) :
            base(row, col)
        {
            mazeMatrix = new MazeSide[rowCount, colCount];
        }

        public override MazeSide GetCell(int row, int col)
        {
            CheckCellExists(row, col);
            MazeSide cell = AddExternalBorders(row, col, mazeMatrix[row, col]);
            return cell;
        }

        private void UpdateNeighbourCells(int row, int col, MazeSide sides)
        {
            if (sides.HasFlag(MazeSide.Top))
            {
                int upperRow = row - 1;
                if (IsCellExists(upperRow, col))
                {
                    mazeMatrix[upperRow, col] |= MazeSide.Bottom;
                }
            }

            if (sides.HasFlag(MazeSide.Bottom))
            {
                int lowerRow = row + 1;
                if (IsCellExists(lowerRow, col))
                {
                    mazeMatrix[lowerRow, col] |= MazeSide.Top;
                }
            }

            if (sides.HasFlag(MazeSide.Right))
            {
                int rightCol = col + 1;
                if (IsCellExists(row, rightCol))
                {
                    mazeMatrix[row, rightCol] |= MazeSide.Left;
                }
            }

            if (sides.HasFlag(MazeSide.Left))
            {
                int leftCol = col - 1;
                if (IsCellExists(row, leftCol))
                {
                    mazeMatrix[row, leftCol] |= MazeSide.Right;
                }
            }
        }

        public void AddSides(int row, int col, MazeSide sides)
        {
            CheckCellExists(row, col);
            mazeMatrix[row, col] |= sides;
            UpdateNeighbourCells(row, col, sides);
        }
    }
}
