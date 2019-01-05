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
		MemAllocator memAllocator = new MemAllocator();
		
		IMazeDrawer mazeDrawer = new MazeDrawer();

		IMaze maze;		
		MazeSolution solution;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void ClearImageBitmap()
		{
			/*
			if (imageBitmap != null)
			{
				using (Graphics gr = Graphics.FromImage(imageBitmap))
				{
					gr.Clear(Color.Transparent);
					somePicture.Image = imageBitmap;
				}
			}
			*/
			somePicture.Image = null;
		}
		
		void AllocMemButtonClick(object sender, EventArgs e)
		{
			const Int64 MEGABYTE = 1024 * 1024;
			Int64 sizeMBytes;
			if (Int64.TryParse(memorySizeTextbox.Text, out sizeMBytes))
			{
				memAllocator.AllocMem(sizeMBytes * MEGABYTE);
			}
			else
			{
				MessageBox.Show("Некорректное значение");
			}
		}
		
		void ResetMemButtonClick(object sender, EventArgs e)
		{
			memAllocator.ResetMem();
		}
		
		void DrawButtonClick(object sender, EventArgs e)
		{						
			solution = null;
			IMazeGenerator gen = new RandomMazeGenerator();
			maze = gen.Generate(27, 27);
			DrawMaze(maze);
		}
		
		void DrawMaze(IMaze maze, MazeSolution solution = null)
		{
			somePicture.Image = mazeDrawer.Draw(maze, solution);
		}		

		
		void CleanButtonClick(object sender, EventArgs e)
		{
			ClearImageBitmap();
		}
		
		void ButtonCheckMazeClick(object sender, EventArgs e)
		{
			IMazeSolver solver = new MazeSolver();
			solution = solver.Solve(maze);
			DrawMaze(maze, solution);			
		}
		

	}
}
