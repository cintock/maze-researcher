/*
 * Author: cintock
 * Date: 05.01.2019
 * Created by SharpDevelop.
 */
using System;

namespace Maze.Implementation
{
	/// <summary>
	/// Description of MazeSolution.
	/// </summary>
	public class MazeClusters
	{
		private Byte[,] attainableCells;
		
		public MazeClusters(Int32 row, Int32 col)
		{
			attainableCells = new Byte[row, col];
		}
		
		public MazeClusters(IMazeData maze)
			: this(maze.RowCount, maze.ColCount)
		{			
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
