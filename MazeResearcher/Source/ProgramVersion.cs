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
	/// Description of ProgramVersion.
	/// </summary>
	public sealed class ProgramVersion
	{
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
			String version = "undefined";
			using (Stream versionInfo =
				Assembly.GetExecutingAssembly().GetManifestResourceStream("Maze.versioninfo.txt"))
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
