using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Maze.Implementation;

namespace Maze.UI
{
    public partial class AppForm : Form
    {
        IMazeDrawer mazeDrawer = new MazeDrawer();

        IMazeData maze;

        public AppForm()
        {
            InitializeComponent();

            mazeGenerationAlgoCombobox.DataSource = MazeGeneratorNamedList.Get();
            mazeGenerationAlgoCombobox.DisplayMember = "Name";

            OutputVersionInfo();

            SizeTrackbarChanged(null, null);

            LogCheckboxCheckStateChanged(null, null);
        }

        void OutputVersionInfo()
        {
            // todo:
            // versionTextbox.Text = ProgramVersion.Instance.VersionString();
        }

        void ClearImageBitmap()
        {
            mazePicturebox.Image = null;
        }


        void DrawButtonClick(object sender, EventArgs e)
        {
            // todo:
            // clustersCountTextbox.Clear();
            //if (maze != null)
            //{
            //    DrawMaze(maze);
            //}
            //else
            //{
            //    MessageBox.Show("Невозможно нарисовать. Лабиринт не создан.");
            //}
        }

        void DrawMaze(IMazeData drawingMaze, MazeClusters clusters = null)
        {
            mazePicturebox.Image = mazeDrawer.Draw(drawingMaze, clusters);
        }


        void CleanButtonClick(object sender, EventArgs e)
        {
            // todo:
            //clustersCountTextbox.Clear();
            //debugConsole.Clear();
            //ClearImageBitmap();
        }

        void ClusterButtonClick(object sender, EventArgs e)
        {
            // todo:
            //if (maze != null)
            //{
            //    IMazeClusterer clusterer = new MazeClusterer();
            //    MazeClusters clusters = clusterer.Cluster(maze);
            //    clustersCountTextbox.Text = clusters.Count().ToString();
            //    DrawMaze(maze, clusters);
            //}
            //else
            //{
            //    MessageBox.Show("Лабиринт еще не создан.");
            //}
        }

        void CreateMazeButtonClick(object sender, EventArgs e)
        {
            MazeGeneratorNamed selectedGenerator = (MazeGeneratorNamed)mazeGenerationAlgoCombobox.SelectedValue;

            if (selectedGenerator != null)
            {
                maze = selectedGenerator.Generator.Generate(mazeRowsTrackbar.Value, mazeColumnsTrackbar.Value);
                DrawMaze(maze);
            }
            else
            {
                MessageBox.Show("Не выбран алгоритм генерации лабиринта");
            }
        }

        void SizeTrackbarChanged(object sender, EventArgs e)
        {
            mazeSizeLabel.Text = String.Format("Строк {0}; Столбцов {1}",
                                                mazeRowsTrackbar.Value, mazeColumnsTrackbar.Value);
        }

        void WriteDebug(String mes)
        {
            debugConsole.AppendText(mes);
        }

        void LogCheckboxCheckStateChanged(object sender, EventArgs e)
        {
            if (debugLoggingCheckbox.Checked)
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
