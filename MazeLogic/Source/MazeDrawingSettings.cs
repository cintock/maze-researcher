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
                    SideColor = 0x000000,
                    BackgroundColor = 0xffffff,
                    BorderColor = 0x000000
                };
                return settings;
            }
        }

        public int CellWidth { get; set; }
        public int CellHeight { get; set; }
        public uint SideColor { get; set; }
        public uint BackgroundColor { get; set; }
        public uint BorderColor { get; set; }
    }
}
