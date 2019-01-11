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

        List<String> debugLog = new List<string>();

        IMazeData maze;

        MazeClusters clusters;

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

        void FindClusters()
        {
            IMazeClusterer clusterer = new MazeClustererRecursion();
            clusters = clusterer.Cluster(maze);
        }

        void DrawMaze()
        {
            if (maze != null)
            {
                if (showMazeClustersCheckbox.Checked)
                {
                    if (clusters == null)
                    {
                        FindClusters();
                    }
                    mazePicturebox.Image = mazeDrawer.Draw(maze, clusters);
                }
                else
                {
                    mazePicturebox.Image = mazeDrawer.Draw(maze, null);
                }                
            }
            else
            {
                mazePicturebox.Image = null;
            }            
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
            //    IMazeClusterer clusterer = new MazeClustererRecursion();
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
                clusters = null;

                maze = selectedGenerator.Generator.Generate(
                    mazeRowsTrackbar.Value, 
                    mazeColumnsTrackbar.Value);

                DrawMaze();
            }
            else
            {
                MessageBox.Show("Не выбран алгоритм генерации лабиринта");
            }

            OutputDebugMessages();
        }

        void OutputDebugMessages()
        {
            if (debugLog.Count > 0)
            {
                debugConsole.Text = String.Join(Environment.NewLine, debugLog);
                debugLog.Clear();
            }
        }

        void SizeTrackbarChanged(object sender, EventArgs e)
        {
            mazeSizeLabel.Text = String.Format("Строк {0}; Столбцов {1}",
                                                mazeRowsTrackbar.Value, mazeColumnsTrackbar.Value);
        }

        void WriteDebug(String mes)
        {
            debugLog.Add(mes);
        }

        void LogCheckboxCheckStateChanged(object sender, EventArgs e)
        {
            Boolean enabledDebugConsole = debugLoggingCheckbox.Checked;

            debugConsole.Visible = enabledDebugConsole;
            mazeViewSplitContainer.Panel2Collapsed = !enabledDebugConsole;

            DebugConsole.Instance().SetDebugCallback(enabledDebugConsole ? 
                (DebugMessageCallbackDelegate)WriteDebug : null);
        }

        void ShowMazeClustersCheckboxChanged(object sender, EventArgs e)
        {
            DrawMaze();
        }
    }
}
