﻿/*
 * Author: cintock
 * Date: 05.01.2019
 * Created by SharpDevelop.
 */

namespace Maze.Logic
{
    /// <summary>
    /// Интерфейс для рисования лабиринта
    /// </summary>
    public interface IMazeDrawer
    {
        void SetDrawingSettings(MazeDrawingSettings settings);

        // todo: надо отказаться от использования Bitmap
        byte[] Draw(IMazeView maze, MazeClusters clusters = null);
    }
}
