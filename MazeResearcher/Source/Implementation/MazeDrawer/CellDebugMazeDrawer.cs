using System.Drawing;

namespace Maze.Implementation
{
    /// <summary>
    /// Класс для рисования границ всех ячеек.
    /// Нужен для отладки согласованности данных в лабиринте 
    /// (выявления случаев, когда в одной ячейке есть правая граница,
    /// а в ячейке правее нее нет левой и т. д.)
    /// </summary>
    public class CellDebugMazeDrawer : StandardMazeDrawer
    {
        public CellDebugMazeDrawer()
        {
        }

        protected override void DrawMaze(Graphics graphics, IMazeView maze)
        {
            const int borderShift = 2;
            Pen sizePen = new Pen(drawingSettings.SideColor, 1);
            int cellWidth = drawingSettings.CellWidth;
            int cellHeight = drawingSettings.CellHeight;
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    if (maze.GetCell(row, col).HasFlag(MazeSide.Right))
                    {
                        graphics.DrawLine(sizePen,
                            new Point((col + 1) * cellWidth - borderShift, (row) * cellHeight),
                            new Point((col + 1) * cellWidth - borderShift, (row + 1) * cellHeight));
                    }

                    if (maze.GetCell(row, col).HasFlag(MazeSide.Left))
                    {
                        graphics.DrawLine(sizePen,
                            new Point((col) * cellWidth + borderShift, (row) * cellHeight),
                            new Point((col) * cellWidth + borderShift, (row + 1) * cellHeight));
                    }

                    if (maze.GetCell(row, col).HasFlag(MazeSide.Bottom))
                    {
                        graphics.DrawLine(sizePen,
                            new Point((col) * cellWidth, (row + 1) * cellHeight - borderShift),
                            new Point((col + 1) * cellWidth, (row + 1) * cellHeight - borderShift));
                    }

                    if (maze.GetCell(row, col).HasFlag(MazeSide.Top))
                    {
                        graphics.DrawLine(sizePen,
                            new Point((col) * cellWidth, (row) * cellHeight + borderShift),
                            new Point((col + 1) * cellWidth, (row) * cellHeight + borderShift));
                    }
                }
            }
        }

        protected override void DrawBorder(Graphics graphics)
        {
            // не рисуем внешнюю границу, чтобы не загораживала 
            // крайние данные по ячейкам лабиринта
        }
    }
}
