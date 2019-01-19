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
        IMazeDrawer mazeDrawer;

        MazeDrawingSettings mazeDrawingSettings;

        List<string> debugLog = new List<string>();

        IMazeClusterer clusterer;

        IMazeView maze;

        MazeClusters clusters;

        bool debugConsoleEnabled;

        public AppForm()
        {
            InitializeComponent();

            mazeGenerationAlgoCombobox.DataSource = 
                MazeGeneratorsObjects.Instance().GetNamedObjectsList();

            mazeGenerationAlgoCombobox.DisplayMember = "Name";
            mazeGenerationAlgoCombobox.ValueMember = "ObjectValue";

            SizeTrackbarChanged(null, null);

            DebugState();

            DefaultSettings();

            // todo: отобразить связанность областей вынести в меню вид
            // todo: простое рисование убрать совсем, потому что уже есть выбор алгоритма в настройках

            // todo: сделать IMazeDrawer, который рисует лабиринт с ячейками-стенами (стена
            // и коридор имеют одинаковый размер)

            // todo: сделать меню правка - копировать

            // todo: сделать контекстное меню по правой кнопке мыши на области лабиринта ->
            // копировать, сохранить изображение
        }

        void DefaultSettings()
        {
            mazeDrawingSettings = new MazeDrawingSettings
            {
                CellHeight = 10,
                CellWidth = 10,
                BorderColor = Color.Black,
                BackgroundColor = Color.Azure,
                SideColor = Color.DarkGreen
            };

            mazeDrawer = MazeDrawersObjects.Instance().GetObject(
                MazeDrawersEnum.StandardMazeDrawer);

            clusterer = MazeClustererObjects.Instance().GetObject(
                MazeClusterersEnum.MazeClusterer);
        }

        void ClearImageBitmap()
        {
            mazePicturebox.Image = null;
        }

        void FindClusters()
        {            
            clusters = clusterer.Cluster(maze);
            clusterCountTextbox.Text = clusters.Count().ToString();
            OutputDebugMessages();
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

        private void ClearClusters()
        {
            clusters = null;
            clusterCountTextbox.Clear();
        }

        void CreateMazeButtonClick(object sender, EventArgs e)
        {
            IMazeGenerator selectedGenerator = 
                (IMazeGenerator)mazeGenerationAlgoCombobox.SelectedValue;

            if (selectedGenerator != null)
            {
                ClearClusters();

                maze = selectedGenerator.Generate(
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

        // todo: это переделать надо
        void OutputDebugMessages()
        {
            if (debugLog.Count > 0)
            {
                debugConsole.Text = string.Join(Environment.NewLine, debugLog);
                debugLog.Clear();
            }
        }

        void SizeTrackbarChanged(object sender, EventArgs e)
        {
            mazeSizeLabel.Text = string.Format("Строк {0}; Столбцов {1}",
                                                mazeRowsTrackbar.Value, mazeColumnsTrackbar.Value);
        }

        void WriteDebug(string mes)
        {
            debugLog.Add(mes);
        }

        void DebugState()
        {
            debugConsole.Visible = debugConsoleEnabled;
            mazeViewSplitContainer.Panel2Collapsed = !debugConsoleEnabled;

            DebugConsole.Instance().SetDebugCallback(debugConsoleEnabled ? 
                (DebugMessageCallbackDelegate)WriteDebug : null);
        }

        void ShowMazeClustersCheckboxChanged(object sender, EventArgs e)
        {
            DrawMaze();
        }

        private void ExitApplication(Object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StartConfigurationForm(Object sender, EventArgs e)
        {
            ConfigurationForm form = new ConfigurationForm(mazeDrawer,
                mazeDrawingSettings)
            {
                DebugLogging = debugConsoleEnabled,
                Clusterer = clusterer
            };

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                mazeDrawer = form.Drawer;

                clusterer = form.Clusterer;

                debugConsoleEnabled = form.DebugLogging;

                DebugState();

                ClearClusters();

                DrawMaze();
            }
        }

        private void SaveMazeImage(Object sender, EventArgs e)
        {
            // todo: добавить обработку исключений
            if (maze != null)
            {
                SaveFileDialog dialog = new SaveFileDialog
                {
                    Filter = "Рисунок PNG (*.png)|*.png"
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
