/*
 * Author: cintock
 * Date: 05.01.2019
 * Created by SharpDevelop.
 */
using System;
using System.Drawing;

namespace Maze.Implementation
{
	/// <summary>
	/// Класс для рисования лабиринта
	/// </summary>
	public class MazeDrawer : IMazeDrawer
	{
		private readonly Color backgroundColor = Color.White;
		private readonly Pen bluePen = new Pen(Color.Blue, 1);
		private readonly Brush redBrush = new SolidBrush(Color.Red);		
		private readonly Int32 cellSize = 10;
		private readonly Int32 circleSize = 4;
		
		public MazeDrawer()
		{
		}
		
		private void DrawMaze(Graphics painter, IMazeData maze)
		{
			for (Int32 row = 0; row < maze.rowCount; row++)
			{
				for (Int32 col = 0; col < maze.colCount; col++)
				{
					Single BaseX = col * cellSize;
					Single BaseY = row * cellSize;
					MazeSide currentCell = maze.GetCell(row, col);
					
					if (currentCell.HasFlag(MazeSide.Top))
					{
						painter.DrawLine(bluePen, BaseX, BaseY, BaseX + cellSize, BaseY);
					}

					if (currentCell.HasFlag(MazeSide.Bottom))
					{
						painter.DrawLine(bluePen, BaseX, BaseY + cellSize, 
						                 BaseX + cellSize, BaseY + cellSize);
					}
					
					if (currentCell.HasFlag(MazeSide.Right))
					{
						painter.DrawLine(bluePen, BaseX + cellSize, BaseY, 
						                 BaseX + cellSize, BaseY + cellSize);
					}				

					if (currentCell.HasFlag(MazeSide.Left))
					{
						painter.DrawLine(bluePen, BaseX, BaseY, 
						                 BaseX, BaseY + cellSize);
					}	
				}
			}
		}
		
		private void DrawClusters(Graphics painter, IMazeData maze, MazeClusters clusters)
		{
			for (Int32 row = 0; row < maze.rowCount; row++)
			{
				for (Int32 col = 0; col < maze.colCount; col++)
				{							
					Int32 BaseX = col * cellSize;
					Int32 BaseY = row * cellSize;

					if (clusters.IsChecked(row, col))
					{
						Int32 circleShift = cellSize / 2 - circleSize / 2;
						painter.FillEllipse(redBrush,
						                    BaseX + circleShift,
						                    BaseY + circleShift,
						                    circleSize, circleSize);
					}
				}
			}
		}
		
		public Bitmap Draw(IMazeData maze, MazeClusters clusters = null)
		{
			Bitmap imageBitmap = new Bitmap(maze.colCount * cellSize + 1, maze.rowCount * cellSize + 1);
			using (Graphics painter = Graphics.FromImage(imageBitmap))
			{
				painter.Clear(backgroundColor);

				DrawMaze(painter, maze);
				
				if (clusters != null)
				{
					DrawClusters(painter, maze, clusters);
				}
			}
			
			return imageBitmap;
		}
		
	}
}
