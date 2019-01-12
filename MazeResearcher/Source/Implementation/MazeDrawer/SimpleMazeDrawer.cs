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
	/// Класс для рисования лабиринта.
    /// Не поддерживает настройки рисования.
    /// Рисование по всем границам - без оптимизации.
	/// </summary>
	public class SimpleMazeDrawer : IMazeDrawer
	{
		private readonly Color backgroundColor = Color.White;
		private readonly Pen bluePen = new Pen(Color.Blue, 1);
		private readonly Int32 cellSize = 10;
		private readonly Int32 circleSize = 6;

        public SimpleMazeDrawer()
		{
		}
		
		private void DrawMaze(Graphics painter, IMazeData maze)
		{
			for (Int32 row = 0; row < maze.RowCount; row++)
			{
				for (Int32 col = 0; col < maze.ColCount; col++)
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
			Int32 clustersNumber = clusters.Count();
			Brush[] brushes = new Brush[clustersNumber];
			for (Int32 i = 0; i < brushes.Length; i++)
			{
				brushes[i] = new SolidBrush(Palette.GetColor(i + 1));
			}
			
			for (Int32 row = 0; row < maze.RowCount; row++)
			{
				for (Int32 col = 0; col < maze.ColCount; col++)
				{							
					Int32 BaseX = col * cellSize;
					Int32 BaseY = row * cellSize;

					if (!clusters.IsNonclustered(row, col))
					{
						Int32 circleShift = cellSize / 2 - circleSize / 2;
						Int32 brushIndex = clusters.GetClusterIndex(row, col) - 1;
						painter.FillEllipse(brushes[brushIndex],
						                    BaseX + circleShift,
						                    BaseY + circleShift,
						                    circleSize, circleSize);
					}
				}
			}
		}
		
		public Bitmap Draw(IMazeData maze, MazeClusters clusters = null)
		{
			Bitmap imageBitmap = new Bitmap(maze.ColCount * cellSize + 1, maze.RowCount * cellSize + 1);
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

        public void SetDrawingSettings(MazeDrawingSettings settings)
        {
            // в этом классе не поддерживаем настройки отображения
        }
    }
}
