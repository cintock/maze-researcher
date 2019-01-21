/*
 * Author: cintock
 * Date: 08.01.2019
 * Created by SharpDevelop.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using log4net;
using log4net.Config;

namespace Maze.UI
{
	/// <summary>
	/// Синглтон для выполнения отладочного логирования
	/// </summary>
	public class DebugConsole
	{
		private DebugConsole()
		{
		}
		
        private static ILog log = LogManager.GetLogger("LOGGER");

        public static ILog Instance
        {
            get { return log; }
        }

    }
}
