/*
 * Author: cintock
 * Date: 07.01.2019
 * Created by SharpDevelop.
 */
using System;
using System.Collections.Generic;

namespace Maze.Implementation
{
    internal struct LineSegment
    {
        public LineSegment(int first, int last)
        {
            if (first <= last)
            {
                FirstPos = first;
                LastPos = last;
            }
            else
            {
                throw new ArgumentException(
                    "Начальная позиция должна быть меньше или равна конечной");
            }
        }

        public int FirstPos { get; }
        public int LastPos { get; }

        public int Length()
        {
            return LastPos - FirstPos + 1;
        }
    }

    /// <summary>
    /// Генерация лабиринта по модифицированному алгоритму Эллера.
    /// Самая нижняя строка всегда пустая, потому что из области на каждом
    /// уровне всегда оставляем только один выход, поэтому они сходятся внизу.
    /// </summary>
    public class EllerModMazeGenerator : IMazeGenerator
	{
        int rowCount;
		int colCount;
		List<int> mazeLineData;
		MazeData maze;

		Random randomValues = new Random();
		
		public EllerModMazeGenerator()
		{
		}
				
		private void InitMaze(int row, int col)
		{
            CheckDimensions(row, col);
            rowCount = row;
            colCount = col;
            mazeLineData = new List<int>(new int[colCount]);
			maze = new MazeData(rowCount, colCount);
		}

        private void CheckDimensions(int row, int col)
        {
            if ((row < 1) || (col < 1))
            {
                throw new ArgumentOutOfRangeException(
                    "Размеры лабиринта должны быть положительными значениями");
            }
        }
		
        private bool RandomBool()
        {
            return (randomValues.Next() % 2 == 0);
        }

        private static Queue<int> CalcUnallocatedNumbers(IList<int> valuesArray)
        {
            int requiredValuesCount = valuesArray.Count;

            Queue<int> unallocatedNumbers = new Queue<int>(requiredValuesCount);

            HashSet<int> usedValues = new HashSet<int>(valuesArray);

            int num = 1;
            for (int i = 0; i < requiredValuesCount; i++)
            {
                while (usedValues.Contains(num))
                {
                    num++;
                }
                unallocatedNumbers.Enqueue(num++);
            }

            return unallocatedNumbers;
        }

        private static List<LineSegment> DivideSegments(List<int> line)
        {
            int lineLength = line.Count;
            var lineSegments = new List<LineSegment>(lineLength);
            int startIndex = 0;

            while (startIndex < lineLength - 1)
            {
                int endIndex;
                for (endIndex = startIndex + 1; endIndex < lineLength; endIndex++)
                {
                    if (line[startIndex] != line[endIndex])
                    {
                        break;
                    }
                }

                lineSegments.Add(new LineSegment(startIndex, endIndex - 1));

                startIndex = endIndex;
            }

            return lineSegments;
        }

		#region Step 2
		private void InitRow(int row)
		{
            Queue<int> unallocatedNums = CalcUnallocatedNumbers(mazeLineData);

			for (int c = 0; c < colCount; c++)
			{
				if (mazeLineData[c] == 0)
				{
					mazeLineData[c] = unallocatedNums.Dequeue();
				}
			}
		}
		#endregion
		
		#region Step 3
		private void CreateRightBorders(int row)
		{
			for (int c = 0; c < colCount - 1; c++)
			{
				if (mazeLineData[c] == mazeLineData[c + 1])
				{
					maze.AddSides(row, c, MazeSide.Right);
				}
				else
				{
					if (RandomBool())
					{
						maze.AddSides(row, c, MazeSide.Right);
					}
					else
					{
						mazeLineData[c + 1] = mazeLineData[c];
					}
				}
			}
		}
		#endregion		

		#region Step 4
		private void CreateBottomBorders(int row)
		{
            List<LineSegment> lineSegments = DivideSegments(mazeLineData);
						
			foreach (LineSegment segment in lineSegments)
			{
                int length = segment.Length();
                if (length > 1)
				{
					int openBottomPos = randomValues.Next(length - 1);
					for (int c = segment.FirstPos; c <= segment.LastPos; c++)
					{
						if (c != segment.FirstPos + openBottomPos)
						{
                            maze.AddSides(row, c, MazeSide.Bottom);
						}
					}
				}
			}
		}
		#endregion
		
		#region Step 5
		private void PrepareNextRow(int row)
		{
			for (int c = 0; c < colCount; c++)
			{
				if (maze.GetCell(row, c).HasFlag(MazeSide.Bottom))
				{
					mazeLineData[c] = 0;
				}
			}			
		}
		#endregion
		
		public IMazeView Generate(int row, int col)
		{
			InitMaze(row, col);
			
			for (int r = 0; r < rowCount - 1; r++)
			{
				InitRow(r);			
				CreateRightBorders(r);			
				CreateBottomBorders(r);
			
				if (r < rowCount - 2)
				{
					PrepareNextRow(r);
				}
			}

			return maze;
		}
	}
}
