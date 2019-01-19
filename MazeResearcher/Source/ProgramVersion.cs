/*
 * Author: cintock
 * Date: 10.01.2019
 * Created by SharpDevelop.
 */
using System;
using System.IO;
using System.Reflection;

namespace Maze
{
    /// <summary>
    /// Синглтон для получения версии программы из встраиваемого ресурса
    /// </summary>
    public sealed class ProgramVersion
	{
        private readonly string versionResourceName = "Maze.versioninfo.txt";
        private string versionString = "undefined";
        private bool versionReceived = false;

        private static readonly ProgramVersion instance = new ProgramVersion();
		
		public static ProgramVersion Instance()
        {
			return instance;
		}
		
		public string VersionString()
		{
			if (!versionReceived)
            {
                ReadVersion();
            }
            
			return versionString;
		}
		
        private void ReadVersion()
        {
            Stream versionInfo = null;
            try
            {
                versionInfo =
                    Assembly.GetExecutingAssembly().GetManifestResourceStream(versionResourceName);

                if (versionInfo != null)
                {
                    using (StreamReader reader = new StreamReader(versionInfo))
                    {
                        versionInfo = null;
                        versionString = reader.ReadToEnd();
                    }
                }
            }
            finally
            {
                if (versionInfo != null)
                {
                    versionInfo.Dispose();
                }
            }
            versionReceived = true;
        }

		private ProgramVersion()
		{
		}
	}
}
