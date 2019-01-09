/*
 * Author: cintock
 * Date: 05.01.2019
 * Created by SharpDevelop.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Maze.Implementation
{
	/// <summary>
	/// Description of MazeDrawer.
	/// </summary>
	public class MazeDrawer : IMazeDrawer
	{
		Pen bluePen = new Pen(Color.Blue, 1);	
		Brush redBrush = new SolidBrush(Color.Red);			
		
		public MazeDrawer()
		{
		}
		
		public Bitmap Draw(IMazeData maze, MazeClusters solution = null)
		{
			Bitmap imageBitmap = new Bitmap(maze.colCount * 10 + 1, maze.rowCount * 10 + 1);
			using (Graphics gr = Graphics.FromImage(imageBitmap))
			{
				gr.Clear(Color.White);
				for (Int32 row = 0; row < maze.rowCount; row++)
				{
					for (Int32 col = 0; col < maze.colCount; col++)
					{
						Single BaseX = col * 10;
						Single BaseY = row * 10;
						MazeSide currentCell = maze.GetCell(row, col);
						if (currentCell.HasFlag(MazeSide.Top))
						{
							gr.DrawLine(bluePen, BaseX, BaseY, BaseX + 10, BaseY);
						}

						if (currentCell.HasFlag(MazeSide.Bottom))
						{
							gr.DrawLine(bluePen, BaseX, BaseY + 10, BaseX + 10, BaseY + 10);
						}
						
						if (currentCell.HasFlag(MazeSide.Right))
						{
							gr.DrawLine(bluePen, BaseX + 10, BaseY, BaseX + 10, BaseY + 10);
						}				

						if (currentCell.HasFlag(MazeSide.Left))
						{
							gr.DrawLine(bluePen, BaseX, BaseY, BaseX, BaseY + 10);
						}	

						if (solution != null)
						{
							if (solution.IsChecked(row, col))
							{
								gr.FillEllipse(redBrush, BaseX + 2, BaseY + 2, 6, 6);
							}
						}
					}
				}
			}
			return imageBitmap;
		}
		
	}
}
