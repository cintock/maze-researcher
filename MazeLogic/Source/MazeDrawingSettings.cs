using System.Drawing;

namespace Maze.Logic
{
    public class MazeDrawingSettings
    {
        public static MazeDrawingSettings BlackWhile {
            get
            {
                MazeDrawingSettings settings = new MazeDrawingSettings();
                settings.CellWidth = 10;
                settings.CellHeight = 10;
                settings.SideColor = Color.Black;
                settings.BackgroundColor = Color.White;
                settings.BorderColor = Color.Black;
                return settings;
            }
        }

        public int CellWidth { get; set; }
        public int CellHeight { get; set; }
        public Color SideColor { get; set; }
        public Color BackgroundColor { get; set; }
        public Color BorderColor { get; set; }
    }
}
