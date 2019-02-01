using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Maze.Logic
{
    public enum MazeRotateEnum
    {
        Rotate0,
        Rotate90,
        Rotate180,
        Rotate270        
    }

    public class MazeDrawerRotateDecorator : MazeDrawerDecorator
    {
        private readonly MazeRotateEnum rotateMaze;

        public MazeDrawerRotateDecorator(IMazeDrawer drawer, MazeRotateEnum rotate) : 
            base(drawer)
        {
            rotateMaze = rotate;
        }

        public override Bitmap Draw(IMazeView maze, MazeClusters clusters = null)
        {
            Bitmap mazeImage = base.Draw(maze, clusters);
            switch (rotateMaze)
            {
                case MazeRotateEnum.Rotate90:
                    mazeImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;

                case MazeRotateEnum.Rotate180:
                    mazeImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;

                case MazeRotateEnum.Rotate270:
                    mazeImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;

                case MazeRotateEnum.Rotate0:
                    break;

                default:
                    throw new MazeException("Неопределенный уровень поворота");
            }
            
            return mazeImage;
        }
    }
}
