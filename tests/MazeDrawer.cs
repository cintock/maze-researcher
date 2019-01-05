﻿/*
 * Author: cintock
 * Date: 05.01.2019
 * Created by SharpDevelop.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace tests
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
		
		public Bitmap Draw(IMaze maze, MazeSolution solution)
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
						if ((currentCell & MazeSide.Top) != MazeSide.None)
						{
							gr.DrawLine(bluePen, BaseX, BaseY, BaseX + 10, BaseY);
						}

						if ((currentCell & MazeSide.Bottom) != MazeSide.None)
						{
							gr.DrawLine(bluePen, BaseX, BaseY + 10, BaseX + 10, BaseY + 10);
						}
						
						if ((currentCell & MazeSide.Right) != MazeSide.None)
						{
							gr.DrawLine(bluePen, BaseX + 10, BaseY, BaseX + 10, BaseY + 10);
						}				

						if ((currentCell & MazeSide.Left) != MazeSide.None)
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
