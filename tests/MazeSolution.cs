/*
 * Author: cintock
 * Date: 05.01.2019
 * Created by SharpDevelop.
 */
using System;

namespace tests
{
	/// <summary>
	/// Description of MazeSolution.
	/// </summary>
	public class MazeSolution
	{
		private Byte[,] attainableCells;
		
		public MazeSolution()
		{
		}
		
		public void InitSizeFromMaze(IMaze maze)
		{
			attainableCells = new Byte[maze.rowCount, maze.colCount];
		}
		
		public Boolean IsChecked(Int32 row, Int32 col)
		{
			return (attainableCells[row, col] != 0);				
		}
		
		public void SetChecked(Int32 row, Int32 col)
		{
			attainableCells[row, col] = 1;
		}		
	}
}
