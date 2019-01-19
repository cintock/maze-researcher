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
		Random rnd;
		
		public EllerModMazeGenerator()
		{
			rnd = new Random();
		}
				
		private void CreateMazeData()
		{
			mazeLineData = new List<int>(new int[colCount]);
			maze = new MazeData(rowCount, colCount);
		}
		
        private static Queue<int> CalcUnallocatedNumbers(IList<int> numbersArray)
        {
            Queue<int> unallocatedNumbers = new Queue<int>(numbersArray.Count);

            HashSet<int> usedNumbers = new HashSet<int>(numbersArray);

            int num = 1;
            for (int i = 0; i < numbersArray.Count; i++)
            {
                while (usedNumbers.Contains(num))
                {
                    num++;
                }
                unallocatedNumbers.Enqueue(num++);
            }

            return unallocatedNumbers;
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

            // todo: надо принимать список без преобразования, потом логирование
            // поменяется, и надо будет подумать
            DebugConsole.Instance().LogNumLine("InitRow", mazeLineData.ToArray());
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
					if (rnd.Next() % 2 == 0)
					{
						maze.AddSides(row, c, MazeSide.Right);
					}
					else
					{
						mazeLineData[c + 1] = mazeLineData[c];
					}
				}
			}
			DebugConsole.Instance().LogNumLine("CrRightBor", mazeLineData.ToArray());
		}
		#endregion
		
		#region Step 4
		private void CreateBottomBorders(int row)
		{
            var lineSegments = new List<LineSegment>(mazeLineData.Count);
            int startIndex = 0;
			while (startIndex < colCount - 1)
			{
                int endIndex;
				for (endIndex = startIndex + 1; endIndex < colCount; endIndex++)
				{
					if (mazeLineData[startIndex] != mazeLineData[endIndex])
					{
						break;
					}
				}

                lineSegments.Add(new LineSegment(startIndex, endIndex - 1));
		
				startIndex = endIndex;
			}
						
			foreach (LineSegment segment in lineSegments)
			{
                int length = segment.Length();
                if (length > 1)
				{
					int openBottomPos = rnd.Next(length - 1);
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
			DebugConsole.Instance().LogNumLine("PrepNextRow", mazeLineData.ToArray());
			
		}
		#endregion
		
		public IMazeView Generate(int row, int col)
		{
			rowCount = row;
			colCount = col;

			CreateMazeData();
			
			DebugConsole.Instance().Log(Environment.NewLine);
			
			for (int r = 0; r < rowCount - 1; r++)
			{
				DebugConsole.Instance().Log(Environment.NewLine);
				
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
