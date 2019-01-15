/*
 * Author: cintock
 * Date: 07.01.2019
 * Created by SharpDevelop.
 */
using System;
using System.Collections.Generic;

namespace Maze.Implementation
{
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
			/*
			Dictionary<Int32, Int32> countNums = new Dictionary<Int32, Int32>();
			for (Int32 c = 0; c < colCount; c++)
			{
				if (countNums.ContainsKey(arrData[row][c]))
				{
					countNums[arrData[row][c]]++;
				}
				else
				{
					countNums.Add(arrData[row][c], 1);
				}
			}
			
			for (Int32 c = 0; c < colCount; c++)
			{
				if (countNums[arrData[row][c]] > 1)
				{
					if (rnd.Next() % 2 == 0)
					{
						maze.SetCell(row, c, maze.GetCell(row, c) | MazeSide.Bottom);
						countNums[arrData[row][c]]--;
					}
				}
			}			
			*/
			
			// todo: это надо переписать нормально
			
			var pairs = new List<Tuple<Int32, Int32>>();
			Int32 current = 0;
			while (current < colCount - 1)
			{
				Int32 curEnd;
				for (curEnd = current + 1; curEnd < colCount; curEnd++)
				{
					if (mazeLineData[current] != mazeLineData[curEnd])
					{
						break;
					}
				}
				curEnd--;
				DebugConsole.Instance().Log(String.Format("{0}: {1} - {2}", 
				                                          mazeLineData[current], current, curEnd));
				
				pairs.Add(new Tuple<int, int>(current, curEnd));
				current = curEnd + 1;
			}
						
			foreach (Tuple<int, int> pair in pairs)
			{
				Int32 len = pair.Item2 - pair.Item1 + 1;
				if (len > 1)
				{
					Int32 ex = rnd.Next(len - 1);
					for (Int32 c = pair.Item1; c <= pair.Item2; c++)
					{
						if (c != ex + pair.Item1)
						{
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
