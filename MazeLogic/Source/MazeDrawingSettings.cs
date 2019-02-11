using System.Drawing;

namespace Maze.Logic
{
    public class MazeDrawingSettings
    {
        public static MazeDrawingSettings BlackWhile {
            get
            {
                MazeDrawingSettings settings = new MazeDrawingSettings()
                {
                    CellWidth = 10,
                    CellHeight = 10,
                    SideColor = Color.Black,
                    BackgroundColor = Color.White,
                    BorderColor = Color.Black
                };
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
