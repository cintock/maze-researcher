/*
 * Author: cintock
 * Date: 05.01.2019
 * Created by SharpDevelop.
 */
using System.Drawing;

namespace Maze.Logic
{
    /// <summary>
    /// Интерфейс для рисования лабиринта
    /// </summary>
    public interface IMazeDrawer
    {
        void SetDrawingSettings(MazeDrawingSettings settings);

        // todo: надо отказаться от использования Bitmap
        Bitmap Draw(IMazeView maze, MazeClusters clusters = null);
    }
}
