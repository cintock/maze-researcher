/*
 * Author: cintock
 * Date: 05.01.2019
 * Created by SharpDevelop.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Maze.Implementation;

namespace Maze.UI
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		IMazeDrawer mazeDrawer = new SimpleMazeDrawer();

		IMazeData maze;		
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();

			generatorCheckbox.DataSource = MazeGeneratorNamedList.Get();
			generatorCheckbox.DisplayMember = "Name";
			
			OutputVersionInfo();
			
			SizeTrackbarChanged(null, null);
			
			LogCheckboxCheckStateChanged(null, null);
		}

		void OutputVersionInfo()
		{
			versionTextbox.Text = ProgramVersion.Instance.VersionString();
		}
		
		void ClearImageBitmap()
		{			
			somePicture.Image = null;
		}
		

		void DrawButtonClick(object sender, EventArgs e)
		{						
			clustersCountTextbox.Clear();
			if (maze != null)
			{			
				DrawMaze(maze);
			}
			else
			{
				MessageBox.Show("Невозможно нарисовать. Лабиринт не создан.");
			}
		}
		
		void DrawMaze(IMazeData drawingMaze, MazeClusters clusters = null)
		{			
			somePicture.Image = mazeDrawer.Draw(drawingMaze, clusters);
		}		

		
		void CleanButtonClick(object sender, EventArgs e)
		{
			clustersCountTextbox.Clear();
			debugConsole.Clear();
			ClearImageBitmap();
		}
		
		void ClusterButtonClick(object sender, EventArgs e)
		{
			if (maze != null)
			{
				IMazeClusterer clusterer = new MazeClustererRecursion();
				MazeClusters clusters = clusterer.Cluster(maze);
				clustersCountTextbox.Text = clusters.Count().ToString();
				DrawMaze(maze, clusters);			
			}
			else
			{
				MessageBox.Show("Лабиринт еще не создан.");
			}
		}
		
		void CreateMazeButtonClick(object sender, EventArgs e)
		{
            MazeGeneratorNamed selectedGenerator = (MazeGeneratorNamed)generatorCheckbox.SelectedValue;

            if (selectedGenerator != null)
            {
                maze = selectedGenerator.Generator.Generate(heightTrackbar.Value, widthTrackbar.Value);
                DrawMaze(maze);
            }
            else
            {
                MessageBox.Show("Не выбран алгоритм генерации лабиринта");
            }
        }

        void SizeTrackbarChanged(object sender, EventArgs e)
		{
			labelMazeSize.Text = String.Format("Строк {0}; Столбцов {1}", 
			                                   heightTrackbar.Value, widthTrackbar.Value);
		}
		
		void WriteDebug(String mes)
		{
			debugConsole.AppendText(mes);
		}
		
		void LogCheckboxCheckStateChanged(object sender, EventArgs e)
		{
			if (logCheckbox.Checked)
			{
				DebugConsole.Instance().SetDebugCallback(WriteDebug);
			}
			else
			{
				DebugConsole.Instance().SetDebugCallback(null);
			}
		}
	}
}
