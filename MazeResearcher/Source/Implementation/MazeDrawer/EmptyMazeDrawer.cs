using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Maze.Implementation
{
    public class EmptyMazeDrawer : IMazeDrawer
    {
        public Bitmap Draw(IMazeView maze, MazeClusters clusters = null)
        {
            return new Bitmap(1, 1);
        }

        public void SetDrawingSettings(MazeDrawingSettings settings)
        {
            
        }
    }
}
