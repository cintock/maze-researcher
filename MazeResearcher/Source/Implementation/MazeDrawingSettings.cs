using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Maze.Implementation
{
    public class MazeDrawingSettings
    {
        public int CellWidth { get; set; }
        public int CellHeight { get; set; }
        public Color SideColor { get; set; }
        public Color BackgroundColor { get; set; }
        public Color BorderColor { get; set; }
    }
}
