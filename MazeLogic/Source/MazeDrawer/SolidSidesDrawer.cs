using System.Drawing;

namespace Maze.Logic
{
    public class SolidSidesDrawer : IMazeDrawer
    {
        private MazeDrawingSettings drawingSettings;
        private int rowCount;
        private int colCount;

        private Brush sideBrush;
        private Brush borderBrush;
        private Brush[] clustersBrushes;

        public Bitmap Draw(IMazeView maze, MazeClusters clusters = null)
        {
            CreateBrushes();

            rowCount = maze.RowCount;
            colCount = maze.ColCount;

            int width = drawingSettings.CellWidth * (colCount + (colCount - 1)) + 
                (2 * drawingSettings.CellWidth);

            int height = drawingSettings.CellHeight * (rowCount + (rowCount - 1)) + 
                (2 * drawingSettings.CellHeight);

            Bitmap bitmap = new Bitmap(width, height);

            using (Graphics gr = Graphics.FromImage(bitmap))
            {
                DrawBackground(gr);

                if (clusters != null)
                {
                    DrawClusters(gr, maze, clusters);
                }

                DrawMaze(gr, maze);

                DrawBorders(gr);
            }

            return bitmap;
        }

        private void CreateBrushes()
        {
            sideBrush = new SolidBrush(drawingSettings.SideColor);
            borderBrush = new SolidBrush(drawingSettings.BorderColor);
        }

        private void DrawBackground(Graphics graphics)
        {
            graphics.Clear(drawingSettings.BackgroundColor);
        }

        private void CreateClusterBrushes(MazeClusters clusters)
        {
            int count = clusters.Count();
            clustersBrushes = new Brush[count];
            for (int i = 0; i < count; i++)
            {
                clustersBrushes[i] = new SolidBrush(Palette.GetColor(i + 1));
            }
        }

        private void DrawClusters(Graphics painter, IMazeView maze, MazeClusters clusters)
        {
            CreateClusterBrushes(clusters);
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    int index = clusters.GetClusterIndex(row, col);

                    if (index != 0)
                    {
                        int drawRow = row * 2 + 1;
                        int drawCol = col * 2 + 1;

                        DrawCell(painter, clustersBrushes[index - 1], 
                            drawRow, drawCol);

                        MazeSide cell = maze.GetCell(row, col);

                        if (!cell.HasFlag(MazeSide.Bottom))
                        {
                            DrawCell(painter, clustersBrushes[index - 1],
                                drawRow + 1, drawCol);
                        }

                        if (!cell.HasFlag(MazeSide.Right))
                        {
                            DrawCell(painter, clustersBrushes[index - 1],
                                drawRow, drawCol + 1);
                        }

                        if (!cell.HasFlag(MazeSide.Bottom) && !cell.HasFlag(MazeSide.Right))
                        {
                            DrawCell(painter, clustersBrushes[index - 1],
                                drawRow + 1, drawCol + 1);
                        }
                    }
                }
            }
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
                        DrawCell(painter, sideBrush, drawRow - 1, drawCol + 1);
                        DrawCell(painter, sideBrush, drawRow, drawCol + 1);
                        DrawCell(painter, sideBrush, drawRow + 1, drawCol + 1);
                    }

                    if (cell.HasFlag(MazeSide.Bottom))
                    {
                        DrawCell(painter, sideBrush, drawRow + 1, drawCol - 1);
                        DrawCell(painter, sideBrush, drawRow + 1, drawCol);
                        DrawCell(painter, sideBrush, drawRow + 1, drawCol + 1);
                    }

                    if (cell.HasFlag(MazeSide.Left))
                    {
                        DrawCell(painter, sideBrush, drawRow - 1, drawCol - 1);
                        DrawCell(painter, sideBrush, drawRow, drawCol - 1);
                        DrawCell(painter, sideBrush, drawRow + 1, drawCol - 1);
                    }

                    if (cell.HasFlag(MazeSide.Top))
                    {
                        DrawCell(painter, sideBrush, drawRow - 1, drawCol - 1);
                        DrawCell(painter, sideBrush, drawRow - 1, drawCol);
                        DrawCell(painter, sideBrush, drawRow - 1, drawCol + 1);
                    }
                }
            }
        }

        private void DrawCell(Graphics painter, Brush brush, int drawRow, int drawCol)
        {
            RectangleF rect = new RectangleF(
                drawCol * drawingSettings.CellWidth,
                drawRow * drawingSettings.CellHeight,
                drawingSettings.CellWidth, drawingSettings.CellHeight);

            painter.FillRectangle(brush, rect);
        }

        private void DrawBorders(Graphics painter)
        {
            int drawRowMax = rowCount * 2 + 1;
            int drawColMax = colCount * 2 + 1;
            for (int row = 0; row < drawRowMax; row++)
            {
                DrawCell(painter, borderBrush, row, 0);
                DrawCell(painter, borderBrush, row, drawColMax - 1);
            }
            for (int col = 0; col < drawColMax; col++)
            {
                DrawCell(painter, borderBrush, 0, col);
                DrawCell(painter, borderBrush, drawRowMax - 1, col);
            }
        }

        public void SetDrawingSettings(MazeDrawingSettings settings)
        {
            drawingSettings = settings;
        }
    }
}
