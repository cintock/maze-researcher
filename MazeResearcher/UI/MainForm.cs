/*
 * Author: cintock
 * Date: 05.01.2019
 * Created by SharpDevelop.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Maze.Implementation;

namespace Maze.UI
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		IMazeDrawer mazeDrawer = new MazeDrawer();

		IMazeData maze;		
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			SizeTrackbarChanged(null, null);
			
			DebugConsole.Instance().SetDebugCallback(WriteDebug);
			
			
			generatorCheckbox.DataSource = MazeGeneratorNamedList.Get();
			generatorCheckbox.DisplayMember = "Name";
			
		}
		
		void ClearImageBitmap()
		{
			somePicture.Image = null;
		}
		

		void DrawButtonClick(object sender, EventArgs e)
		{						

			DrawMaze(maze);
		}
		
		void DrawMaze(IMazeData drawingMaze, MazeSolution drawingSolution = null)
		{
			somePicture.Image = mazeDrawer.Draw(drawingMaze, drawingSolution);
		}		

		
		void CleanButtonClick(object sender, EventArgs e)
		{
			ClearImageBitmap();
		}
		
		void ButtonCheckMazeClick(object sender, EventArgs e)
		{
			IMazeSolver solver = new MazeSolver();
			MazeSolution solution = solver.Solve(maze);
			DrawMaze(maze, solution);			
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
	}
}
