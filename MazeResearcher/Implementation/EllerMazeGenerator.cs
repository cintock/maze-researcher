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
	/// Description of EllerMazeGenerator.
	/// </summary>
	public class EllerMazeGenerator : IMazeGenerator
	{
		Int32 rowCount;
		Int32 colCount;
		Int32[][] arrData;
		MazeData maze;
		Random rnd;
		
		public EllerMazeGenerator()
		{
			rnd = new Random();
		}
				
		private void CreateMazeData()
		{
			arrData = new Int32[rowCount][];
			for (Int32 r = 0; r < rowCount; r++)
			{
				arrData[r] = new Int32[colCount];
			}
			maze = new MazeData(rowCount, colCount);
		}
		
		#region Step 2
		private void InitRow(Int32 row)
		{
			Int32[] availableNums = new Int32[colCount];
			Int32 num = 1;
			for (Int32 i = 0; i < colCount; i++)
			{				
				while (((IList<Int32>)arrData[row]).Contains(num))
				{
					num++;
				}
				availableNums[i] = num++;
			}
			
			Int32 index = 0;
			for (Int32 c = 0; c < colCount; c++)
			{
				if (arrData[row][c] == 0)
				{
					arrData[row][c] = availableNums[index++];
				}
			}
			
			DebugConsole.Instance().LogNumLine("InitRow", arrData[row]);
		}
		#endregion
		
		#region Step 3
		private void CreateRightBorders(Int32 row)
		{
			for (Int32 c = 0; c < colCount - 1; c++)
			{
				if (arrData[row][c] == arrData[row][c + 1])
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
						arrData[row][c + 1] = arrData[row][c];
					}
				}
			}
			DebugConsole.Instance().LogNumLine("CrRightBor", arrData[row]);
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
			
			var pairs = new List<Tuple<Int32, Int32>>();
			Int32 current = 0;
			while (current < colCount - 1)
			{
				Int32 curEnd;
				for (curEnd = current + 1; curEnd < colCount; curEnd++)
				{
					if (arrData[row][current] != arrData[row][curEnd])
					{
						break;
					}
				}
				curEnd--;
				DebugConsole.Instance().Log(String.Format("{0}: {1} - {2}", 
				                                          arrData[row][current], current, curEnd));
				
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
			// на самом деле можно без копирования, и на самом деле
			// нам не нужен полный arrData
			// todo: можно переделать
			arrData[row + 1] = (Int32[])arrData[row].Clone();
			for (Int32 c = 0; c < colCount; c++)
			{
				if (maze.GetCell(row, c).HasFlag(MazeSide.Bottom))
				{
					arrData[row + 1][c] = 0;
				}
			}
			DebugConsole.Instance().LogNumLine("PrepNextRow", arrData[row + 1]);
			
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
			
				PrepareNextRow(r);
			}

			return maze;
		}
	}
}
