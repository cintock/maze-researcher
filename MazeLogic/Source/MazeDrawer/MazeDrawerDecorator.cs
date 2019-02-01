using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Logic
{
    public class MazeDrawerDecorator : IMazeDrawer
    {
        public MazeDrawerDecorator(IMazeDrawer drawer)
        {
            mazeDrawer = drawer;
        }

        public virtual Bitmap Draw(IMazeView maze, MazeClusters clusters = null)
        {
            return mazeDrawer.Draw(maze, clusters);
        }

        public virtual void SetDrawingSettings(MazeDrawingSettings settings)
        {
            mazeDrawer.SetDrawingSettings(settings);
        }

        private IMazeDrawer mazeDrawer;
    }
}
