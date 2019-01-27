using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Logic
{
    // todo: доделать

    public class SolidSidesDrawer : IMazeDrawer
    {
        private MazeDrawingSettings drawingSettings;
        private int rowCount;
        private int colCount;
        private Brush sideBrush;

        public Bitmap Draw(IMazeView maze, MazeClusters clusters = null)
        {
            CreateBrushes();

            rowCount = maze.RowCount;
            colCount = maze.ColCount;

            int width = colCount * ((drawingSettings.CellWidth + 2) * 2);
            int height = rowCount * ((drawingSettings.CellHeight + 2) * 2);
            Bitmap bitmap = new Bitmap(width, height);

            using (Graphics gr = Graphics.FromImage(bitmap))
            {
                if (clusters != null)
                {
                    DrawClusters(gr, clusters);
                }

                DrawMaze(gr, maze);

                DrawBorders(gr);
            }

            return bitmap;
        }

        private void CreateBrushes()
        {
            sideBrush = new SolidBrush(drawingSettings.SideColor);
        }

        private void DrawClusters(Graphics painter, MazeClusters clusters)
        {

        }

        private void DrawMaze(Graphics painter, IMazeView maze)
        {
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    MazeSide cell = maze.GetCell(row, col);
                    int drawRow = row * 2 + 1;
                    int drawCol = col * 2 + 1;

                    if (cell.HasFlag(MazeSide.Right))
                    {
                        DrawWall(painter, drawRow - 1, drawCol + 1);
                        DrawWall(painter, drawRow, drawCol + 1);
                        DrawWall(painter, drawRow + 1, drawCol + 1);
                    }

                    if (cell.HasFlag(MazeSide.Bottom))
                    {
                        DrawWall(painter, drawRow + 1, drawCol - 1);
                        DrawWall(painter, drawRow + 1, drawCol);
                        DrawWall(painter, drawRow + 1, drawCol + 1);
                    }

                    if (cell.HasFlag(MazeSide.Left))
                    {
                        DrawWall(painter, drawRow - 1, drawCol - 1);
                        DrawWall(painter, drawRow, drawCol - 1);
                        DrawWall(painter, drawRow + 1, drawCol - 1);
                    }

                    if (cell.HasFlag(MazeSide.Top))
                    {
                        DrawWall(painter, drawRow - 1, drawCol - 1);
                        DrawWall(painter, drawRow - 1, drawCol);
                        DrawWall(painter, drawRow - 1, drawCol + 1);
                    }
                }
            }
        }

        private void DrawWall(Graphics painter, int drawRow, int drawCol)
        {
            RectangleF rect = new RectangleF(
                drawCol * drawingSettings.CellWidth,
                drawRow * drawingSettings.CellHeight,
                drawingSettings.CellWidth, drawingSettings.CellHeight);

            painter.FillRectangle(sideBrush, rect);
        }

        private void DrawBorders(Graphics painter)
        {

        }

        public void SetDrawingSettings(MazeDrawingSettings settings)
        {
            drawingSettings = settings;
        }
    }
}
