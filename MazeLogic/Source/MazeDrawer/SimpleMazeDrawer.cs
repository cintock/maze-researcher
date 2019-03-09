/*
 * Author: cintock
 * Date: 05.01.2019
 * Created by SharpDevelop.
 */
using System;
using System.IO;
using System.Numerics;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Maze.Logic
{
    /// <summary>
    /// Класс для рисования лабиринта.
    /// Не поддерживает настройки рисования.
    /// Рисование по всем границам - без оптимизации.
    /// </summary>
    public class SimpleMazeDrawer : IMazeDrawer
    {
        private readonly uint backgroundColor = 0xffffff;
        private readonly uint linesColor = 0x0000ff;
        private IMazeView maze;
        private MazeClusters clusters;

        private readonly int cellSize = 10;
        private readonly int rectSize = 6;

        public SimpleMazeDrawer()
        {
        }

        private void DrawMaze(SimpleDrawer drawer)
        {
            for (int row = 0; row < maze.RowCount; row++)
            {
                for (int col = 0; col < maze.ColCount; col++)
                {
                    int BaseX = col * cellSize;
                    int BaseY = row * cellSize;
                    MazeSide currentCell = maze.GetCell(row, col);

                    if (currentCell.HasFlag(MazeSide.Top))
                    {
                        drawer.DrawLine(BaseX, BaseY, BaseX + cellSize, BaseY, 
                            linesColor);
                    }

                    if (currentCell.HasFlag(MazeSide.Bottom))
                    {
                        drawer.DrawLine(BaseX, BaseY + cellSize,
                            BaseX + cellSize, BaseY + cellSize,
                            linesColor);
                    }

                    if (currentCell.HasFlag(MazeSide.Right))
                    {
                        drawer.DrawLine(BaseX + cellSize, BaseY,
                            BaseX + cellSize, BaseY + cellSize,
                            linesColor);
                    }

                    if (currentCell.HasFlag(MazeSide.Left))
                    {
                        drawer.DrawLine(BaseX, BaseY, BaseX, BaseY + cellSize,
                            linesColor);
                    }
                }
            }
        }

        private void DrawClusters(SimpleDrawer drawer)
        {
            int clustersNumber = clusters.Count();
            uint[] colors = new uint[clustersNumber];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = Palette.GetColor(i + 1);
            }

            for (int row = 0; row < maze.RowCount; row++)
            {
                for (int col = 0; col < maze.ColCount; col++)
                {
                    int BaseX = col * cellSize;
                    int BaseY = row * cellSize;

                    if (!clusters.IsNonclustered(row, col))
                    {
                        int rectShift = cellSize / 2 - rectSize / 2;
                        int colorIndex = clusters.GetClusterIndex(row, col) - 1;
                        drawer.DrawFilledRect(BaseX + rectShift,
                            BaseY + rectShift,
                            rectSize, rectSize, colors[colorIndex]);
                    }
                }
            }
        }

        public byte[] Draw(IMazeView maze, MazeClusters clusters = null)
        {
            this.maze = maze;
            this.clusters = clusters;

            using (SimpleDrawer drawer = new SimpleDrawer(
                maze.ColCount * cellSize + 1, maze.RowCount * cellSize + 1, 
                backgroundColor))
            {
                DrawMaze(drawer);

                if (clusters != null)
                {
                    DrawClusters(drawer);
                }

                return drawer.ReadBmpImage();
            }
        }

        public void SetDrawingSettings(MazeDrawingSettings settings)
        {
            // в этом классе не поддерживаем настройки отображения
        }
    }
}
