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
        public LineSegment(Int32 first, Int32 last)
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

        public Int32 FirstPos { get; }
        public Int32 LastPos { get; }

        public Int32 Length()
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
		Int32 rowCount;
		Int32 colCount;
		Int32[] mazeLineData;
		MazeData maze;
		Random rnd;
		
		public EllerModMazeGenerator()
		{
			rnd = new Random();
		}
				
		private void CreateMazeData()
		{
			mazeLineData = new Int32[colCount];
			maze = new MazeData(rowCount, colCount);
		}
		
		#region Step 2
		private void InitRow(Int32 row)
		{
			Int32[] availableNums = new Int32[colCount];
			Int32 num = 1;
			for (Int32 i = 0; i < colCount; i++)
			{				
				while (((IList<Int32>)mazeLineData).Contains(num))
				{
					num++;
				}
				availableNums[i] = num++;
			}
			
			Int32 index = 0;
			for (Int32 c = 0; c < colCount; c++)
			{
				if (mazeLineData[c] == 0)
				{
					mazeLineData[c] = availableNums[index++];
				}
			}
			
			DebugConsole.Instance().LogNumLine("InitRow", mazeLineData);
		}
		#endregion
		
		#region Step 3
		private void CreateRightBorders(Int32 row)
		{
			for (Int32 c = 0; c < colCount - 1; c++)
			{
				if (mazeLineData[c] == mazeLineData[c + 1])
				{
					maze.SetCell(row, c, MazeSide.Right);
				}
				else
				{
					if (rnd.Next() % 2 == 0)
					{
						maze.SetCell(row, c, MazeSide.Right);
					}
					else
					{
						mazeLineData[c + 1] = mazeLineData[c];
					}
				}
			}
			DebugConsole.Instance().LogNumLine("CrRightBor", mazeLineData);
		}
		#endregion
		
		#region Step 4
		private void CreateBottomBorders(Int32 row)
		{
            var lineSegments = new List<LineSegment>(mazeLineData.Length);
            Int32 startIndex = 0;
			while (startIndex < colCount - 1)
			{
                Int32 endIndex;
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
                Int32 length = segment.Length();
                if (length > 1)
				{
					Int32 openBottomPos = rnd.Next(length - 1);
					for (Int32 c = segment.FirstPos; c <= segment.LastPos; c++)
					{
						if (c != segment.FirstPos + openBottomPos)
						{
                            // todo: когда появится новый метод - поменять
                            maze.SetCell(row, c, maze.GetCell(row, c) | MazeSide.Bottom);
						}
					}
				}
			}
		}
		#endregion
		
		#region Step 5
		private void PrepareNextRow(Int32 row)
		{
			for (Int32 c = 0; c < colCount; c++)
			{
				if (maze.GetCell(row, c).HasFlag(MazeSide.Bottom))
				{
					mazeLineData[c] = 0;
				}
			}
			DebugConsole.Instance().LogNumLine("PrepNextRow", mazeLineData);
			
		}
		#endregion
		
		public IMazeData Generate(Int32 row, Int32 col)
		{
			rowCount = row;
			colCount = col;

			CreateMazeData();
			
			DebugConsole.Instance().Log(Environment.NewLine);
			
			for (Int32 r = 0; r < rowCount - 1; r++)
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
