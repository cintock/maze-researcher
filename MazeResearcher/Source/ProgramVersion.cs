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
        private readonly String VersionResourceName = "Maze.versioninfo.txt";
        private readonly String UndefinedVersionString = "undefined";

        private static ProgramVersion instance = null;
		
		public static ProgramVersion Instance {
			get {
				if (instance == null)
				{
					instance = new ProgramVersion();
				}
				return instance;
			}
		}
		
		public String VersionString()
		{
			String version = UndefinedVersionString;
			using (Stream versionInfo =
				Assembly.GetExecutingAssembly().GetManifestResourceStream(VersionResourceName))
			{
                if (versionInfo != null)
                {
                    using (StreamReader reader = new StreamReader(versionInfo))
                    {
                        version = reader.ReadToEnd();
                    }
                }
			}
			return version;
		}
		
		private ProgramVersion()
		{
		}
	}
}
