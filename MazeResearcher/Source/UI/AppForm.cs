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
        IMazeDrawer mazeDrawer = new StandardMazeDrawer();

        MazeDrawingSettings mazeDrawingSettings = new MazeDrawingSettings();

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

            mazeDrawingSettings.CellHeight = 15;
            mazeDrawingSettings.CellWidth = 20;
            mazeDrawingSettings.BorderColor = Color.Black;
            mazeDrawingSettings.BackgroundColor = Color.Azure;
            mazeDrawingSettings.SideColor = Color.DarkViolet;
        }

        void OutputVersionInfo()
        {
            versionNumberTextbox.Text = ProgramVersion.Instance.VersionString();
        }

        void ClearImageBitmap()
        {
            mazePicturebox.Image = null;
        }

        void FindClusters()
        {
            IMazeClusterer clusterer = new MazeClustererRecursion();
            clusters = clusterer.Cluster(maze);
            clusterCountTextbox.Text = clusters.Count().ToString();
        }

        void DrawMaze()
        {
            if (maze != null)
            {
                mazeDrawer.SetDrawingSettings(mazeDrawingSettings);
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

        void CreateMazeButtonClick(object sender, EventArgs e)
        {
            MazeGeneratorNamed selectedGenerator = 
                (MazeGeneratorNamed)mazeGenerationAlgoCombobox.SelectedValue;

            if (selectedGenerator != null)
            {
                clusters = null;

                maze = selectedGenerator.Generator.Generate(
                    mazeRowsTrackbar.Value, 
                    mazeColumnsTrackbar.Value);

                clusterCountTextbox.Clear();

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

        private void simpleDrawer_CheckedChanged(object sender, EventArgs e)
        {
            if (simpleDrawer.Checked)
            {
                mazeDrawer = new SimpleMazeDrawer();
            }
            else
            {
                mazeDrawer = new StandardMazeDrawer();
            }
            DrawMaze();
        }
    }
}
