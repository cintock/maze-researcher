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
        IMazeDrawer mazeDrawer = MazeDrawersObjects.Instance().GetObject(
            MazeDrawersEnum.StandardMazeDrawer);

        MazeDrawingSettings mazeDrawingSettings = new MazeDrawingSettings();

        List<String> debugLog = new List<String>();

        IMazeData maze;

        MazeClusters clusters;

        public AppForm()
        {
            InitializeComponent();

            mazeGenerationAlgoCombobox.DataSource = 
                MazeGeneratorsObjects.Instance().GetNamedObjectsList();

            mazeGenerationAlgoCombobox.DisplayMember = "Name";

            OutputVersionInfo();

            SizeTrackbarChanged(null, null);

            LogCheckboxCheckStateChanged(null, null);

            mazeDrawingSettings.CellHeight = 10;
            mazeDrawingSettings.CellWidth = 10;
            mazeDrawingSettings.BorderColor = Color.Black;
            mazeDrawingSettings.BackgroundColor = Color.Azure;
            mazeDrawingSettings.SideColor = Color.DarkViolet;

            // todo: отобразить связанность областей вынести в меню вид
            // todo: отладочное логирование убрать в настройки
            // todo: простое рисование убрать совсем, потому что уже есть выбор алгоритма в настройках

            // todo: сделать IMazeDrawer, который рисует лабиринт с ячейками-стенами (стена
            // и коридор имеют одинаковый размер)
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

        private Bitmap RenderMaze()
        {
            Bitmap mazeImage = null;
            if (maze != null)
            {
                mazeDrawer.SetDrawingSettings(mazeDrawingSettings);
                if (showMazeClustersCheckbox.Checked)
                {
                    if (clusters == null)
                    {
                        FindClusters();
                    }
                    mazeImage = mazeDrawer.Draw(maze, clusters);
                }
                else
                {
                    mazeImage = mazeDrawer.Draw(maze, null);
                }
            }
            return mazeImage;
        }

        void DrawMaze()
        {
            mazePicturebox.Image = RenderMaze();
        }

        void CreateMazeButtonClick(object sender, EventArgs e)
        {
            NamedObject<IMazeGenerator> selectedGeneratorNamed = 
                (NamedObject<IMazeGenerator>)mazeGenerationAlgoCombobox.SelectedValue;

            IMazeGenerator selectedGenerator = selectedGeneratorNamed.ObjectValue;

            if (selectedGenerator != null)
            {
                clusters = null;

                maze = selectedGenerator.Generate(
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
                mazeDrawer = MazeDrawersObjects.Instance().GetObject(
                    MazeDrawersEnum.SimpleMazeDrawer);
            }
            else
            {
                mazeDrawer = MazeDrawersObjects.Instance().GetObject(
                    MazeDrawersEnum.StandardMazeDrawer);
            }
            DrawMaze();
        }

        private void ExitApplication(Object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StartConfigurationForm(Object sender, EventArgs e)
        {
            ConfigurationForm form = new ConfigurationForm(mazeDrawer, 
                mazeDrawingSettings);

            form.ShowDialog(this);
            if (form.DialogResult == DialogResult.OK)
            {
                mazeDrawer = form.Drawer;

                DrawMaze();
            }
        }

        private void SaveMazeImage(Object sender, EventArgs e)
        {
            if (maze != null)
            {
                SaveFileDialog dialog = new SaveFileDialog
                {
                    Filter = "Рисунок PNG (*.png)|*.png|Все файлы (*.*)|*.*"
                };
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    Bitmap maze = RenderMaze();
                    maze.Save(dialog.FileName);
                }
            }
            else
            {
                MessageBox.Show(this, "Лабиринт не создан");
            }
        }

        private void AboutDialog(Object sender, EventArgs e)
        {
            AboutDialog about = new AboutDialog();
            about.ShowDialog(this);
        }
    }
}
