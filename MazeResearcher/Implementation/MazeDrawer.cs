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
		readonly Color backgroundColor = Color.White;
		readonly Pen bluePen = new Pen(Color.Blue, 1);
		readonly Brush redBrush = new SolidBrush(Color.Red);		
		readonly Int32 sideLength = 10;
		
		public MazeDrawer()
		{
		}
		
		public Bitmap Draw(IMazeData maze, MazeClusters solution = null)
		{
			Bitmap imageBitmap = new Bitmap(maze.colCount * sideLength + 1, maze.rowCount * sideLength + 1);
			using (Graphics painter = Graphics.FromImage(imageBitmap))
			{
				painter.Clear(backgroundColor);
				for (Int32 row = 0; row < maze.rowCount; row++)
				{
					for (Int32 col = 0; col < maze.colCount; col++)
					{
						Single BaseX = col * sideLength;
						Single BaseY = row * sideLength;
						MazeSide currentCell = maze.GetCell(row, col);
						if (currentCell.HasFlag(MazeSide.Top))
						{
							painter.DrawLine(bluePen, BaseX, BaseY, BaseX + sideLength, BaseY);
						}

						if (currentCell.HasFlag(MazeSide.Bottom))
						{
							painter.DrawLine(bluePen, BaseX, BaseY + sideLength, 
							                 BaseX + sideLength, BaseY + sideLength);
						}
						
						if (currentCell.HasFlag(MazeSide.Right))
						{
							painter.DrawLine(bluePen, BaseX + sideLength, BaseY, 
							                 BaseX + sideLength, BaseY + sideLength);
						}				

						if (currentCell.HasFlag(MazeSide.Left))
						{
							painter.DrawLine(bluePen, BaseX, BaseY, 
							                 BaseX, BaseY + sideLength);
						}	

						if (solution != null)
						{
							if (solution.IsChecked(row, col))
							{
								painter.FillEllipse(redBrush, BaseX + 2, BaseY + 2, 6, 6);
							}
						}
					}
				}
			}
			return imageBitmap;
		}
		
	}
}
