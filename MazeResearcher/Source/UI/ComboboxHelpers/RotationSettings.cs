using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maze.Logic;

namespace Maze.UI
{
    class RotationSettings : ObjectsDescription<MazeRotateEnum, Type>
    {
        static readonly RotationSettings mazeRotationSettingsList =
            new RotationSettings();

        public static RotationSettings Instance()
        {
            return mazeRotationSettingsList;
        }

        private RotationSettings()
        {
            RegisterObject(MazeRotateEnum.Rotate0, null, "Без поворорта");
            RegisterObject(MazeRotateEnum.Rotate90, null, "90 по часовой");
            RegisterObject(MazeRotateEnum.Rotate180, null, "На 180");
            RegisterObject(MazeRotateEnum.Rotate270, null, "90 против часовой");
        }
    }
}
