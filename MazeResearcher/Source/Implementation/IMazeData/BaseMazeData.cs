﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze.Implementation
{
    public abstract class BaseMazeData : IMazeView
    {
        protected readonly int rowCount;
        protected readonly int colCount;

        public int RowCount
        {
            get
            {
                return rowCount;
            }
        }

        public int ColCount
        {
            get
            {
                return colCount;
            }
        }

        public BaseMazeData(int row, int col)
        {
            CheckDimensions(row, col);
            rowCount = row;
            colCount = col;
        }

        protected MazeSide AddExternalBorders(int row, int col, MazeSide cell)
        {
            if (row == 0)
            {
                cell |= MazeSide.Top;
            }

            if (row == rowCount - 1)
            {
                cell |= MazeSide.Bottom;
            }

            if (col == 0)
            {
                cell |= MazeSide.Left;
            }

            if (col == colCount - 1)
            {
                cell |= MazeSide.Right;
            }

            return cell;
        }

        public bool IsCellExists(int row, int col)
        {
            return ((row >= 0) && (row < rowCount) && 
                (col >= 0) && (col < colCount));
        }

        private static void CheckDimensions(int row, int col)
        {
            if (!((row > 0) && (col > 0)))
            {
                throw new IndexOutOfRangeException("Некорректная размерность лабиринта");
            }
        }

        protected void CheckCellExists(int row, int col)
        {
            if (!IsCellExists(row, col))
            {
                throw new IndexOutOfRangeException("Ячейка лабиринта не существует");
            }
        }

        public abstract  MazeSide GetCell(int row, int col);
    }
}
