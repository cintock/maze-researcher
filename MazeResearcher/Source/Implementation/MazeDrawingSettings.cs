using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Maze.Implementation
{
    public class MazeDrawingSettings
    {
        public Int32 CellWidth { get; set; }
        public Int32 CellHeight { get; set; }
        public Color SideColor { get; set; }
        public Color BackgroundColor { get; set; }
        public Color BorderColor { get; set; }
    }
}
