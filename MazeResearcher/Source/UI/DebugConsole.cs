/*
 * Author: cintock
 * Date: 08.01.2019
 * Created by SharpDevelop.
 */
using log4net;

namespace Maze.UI
{
    /// <summary>
    /// Синглтон для выполнения отладочного логирования 
    /// в текстовое поле
    /// </summary>
    public class DebugConsole
    {
        private DebugConsole()
        {
        }

        private static readonly ILog log = LogManager.GetLogger("LOGGER");

        public static ILog Instance
        {
            get { return log; }
        }
    }
}
