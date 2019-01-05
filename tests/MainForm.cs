/*
 * Author: cintock
 * Date: 05.01.2019
 * Created by SharpDevelop.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace tests
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		IMazeDrawer mazeDrawer = new MazeDrawer();

		IMaze maze;		
		
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
			
			List<MazeGeneratorNamed> mazeGeneratorList = new List<MazeGeneratorNamed>()
			{
				new MazeGeneratorNamed(new RandomMazeGenerator(), "Полностью случайный лабиринт")
			};
			
			mazeCreationAlgoCheckbox.DataSource = mazeGeneratorList;
			mazeCreationAlgoCheckbox.DisplayMember = "Name";
			
		}
		
		void ClearImageBitmap()
		{
			somePicture.Image = null;
		}
		

		void DrawButtonClick(object sender, EventArgs e)
		{						

			DrawMaze(maze);
		}
		
		void DrawMaze(IMaze drawingMaze, MazeSolution drawingSolution = null)
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
			MazeGeneratorNamed selectedGenerator = (MazeGeneratorNamed)mazeCreationAlgoCheckbox.SelectedValue;
			
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
	}
}
