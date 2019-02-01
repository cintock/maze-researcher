using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Maze.Logic
{
    public class MazeDrawerRotateDecorator : MazeDrawerDecorator
    {
        public MazeDrawerRotateDecorator(IMazeDrawer drawer) : base(drawer)
        {

        }

        public override Bitmap Draw(IMazeView maze, MazeClusters clusters = null)
        {
            Bitmap mazeImage = base.Draw(maze, clusters);
            mazeImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            return mazeImage;
        }
    }
}
