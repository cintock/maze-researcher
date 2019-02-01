using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Maze.Logic;

namespace Maze.UI
{
    public partial class AppForm : Form
    {
        private IMazeDrawer drawer;
        private MazeDrawingSettings drawingSettings;
        private IMazeClusterer clusterer;
        private IMazeView maze;
        private MazeClusters clusters;
        private bool debugConsoleEnabled;

        public AppForm()
        {
            InitializeComponent();

            mazeGenerationAlgoCombobox.DataSource =
                MazeGeneratorsObjects.Instance().GetNamedObjectsList();

            mazeGenerationAlgoCombobox.DisplayMember = "Name";
            mazeGenerationAlgoCombobox.ValueMember = "ObjectValue";

            SizeTrackbarChanged(null, null);

            DefaultSettings();

            SetDebugConsoleState(false);

            // todo: отобразить связанность областей вынести в меню вид

            // todo: сделать меню правка - копировать

            // todo: сделать контекстное меню по правой кнопке мыши на области лабиринта ->
            // копировать, сохранить изображение

            InitLogger();
        }

        private void InitLogger()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        void DefaultSettings()
        {
            drawingSettings = new MazeDrawingSettings()
            {
                CellHeight = 10,
                CellWidth = 10,
                BorderColor = Color.Black,
                BackgroundColor = Color.Azure,
                SideColor = Color.DarkGreen
            };

            drawer = MazeDrawersObjects.Instance().GetObject(
                MazeDrawersEnum.StandardMazeDrawer);

            drawer.SetDrawingSettings(drawingSettings);

            clusterer = MazeClustererObjects.Instance().GetObject(
                MazeClusterersEnum.MazeClustererCyclic);
        }

        void FindClusters()
        {
            clusters = clusterer.Cluster(maze);
            string clustersCountStr = clusters.Count().ToString();
            clusterCountTextbox.Text = clustersCountStr;

            DebugConsole.Instance.Info(
                string.Format("Выполнен поиск областей. Найдено областей: {0}",
                clustersCountStr));
        }

        private Bitmap RenderMaze()
        {
            Bitmap mazeImage = null;
            try
            {
                if (maze != null)
                {
                    if (showMazeClustersCheckbox.Checked)
                    {
                        mazeImage = drawer.Draw(maze, clusters);
                    }
                    else
                    {
                        mazeImage = drawer.Draw(maze);
                    }
                }
            }
            catch (MazeException ex)
            {
                DebugConsole.Instance.Error(
                    string.Format("Возникло исключение: {0}", ex.ToString()));
            }
            return mazeImage;
        }

        private void ShowMaze()
        {
            if (maze != null)
            {
                if (showMazeClustersCheckbox.Checked && clusters == null)
                {
                    FindClusters();
                }

                mazePicturebox.Image = RenderMaze();
            }
        }

        private void ClearClusters()
        {
            clusters = null;
            clusterCountTextbox.Clear();
        }

        void CreateMazeButtonClick(object sender, EventArgs e)
        {
            try
            {
                IMazeGenerator selectedGenerator =
                    (IMazeGenerator)mazeGenerationAlgoCombobox.SelectedValue;

                if (selectedGenerator != null)
                {
                    ClearClusters();

                    Stopwatch methodTime = Stopwatch.StartNew();

                    maze = selectedGenerator.Generate(
                        mazeRowsTrackbar.Value,
                        mazeColumnsTrackbar.Value);

                    ShowMaze();

                    methodTime.Stop();
                    DebugConsole.Instance.Info(
                        string.Format("Лабиринт ({0} x {1}) создан и нарисован за {2} мс",
                        maze.RowCount, maze.ColCount, methodTime.ElapsedMilliseconds));
                }
                else
                {
                    MessageBox.Show("Не выбран алгоритм генерации лабиринта");
                }
            }
            catch (MazeException ex)
            {
                DebugConsole.Instance.Error(
                    string.Format("При создании лабиринта произошла ошибка: {0}",
                    ex.ToString()));
            }
        }

        void SizeTrackbarChanged(object sender, EventArgs e)
        {
            mazeSizeLabel.Text = string.Format("Строк {0}; Столбцов {1}",
                                                mazeRowsTrackbar.Value, mazeColumnsTrackbar.Value);
        }

        void SetDebugConsoleState(bool show)
        {
            debugConsoleEnabled = show;
            debugConsole.Visible = debugConsoleEnabled;
            mazeViewSplitContainer.Panel2Collapsed = !debugConsoleEnabled;

            LogTextboxAppender.LoggingTextbox = debugConsoleEnabled ? debugConsole : null;
        }

        bool IsDebugConsoleEnabled()
        {
            return debugConsoleEnabled;
        }

        void ShowMazeClustersCheckboxChanged(object sender, EventArgs e)
        {
            ShowMaze();
        }

        private void AppFormClosing(object sender, FormClosingEventArgs e)
        {
            SetDebugConsoleState(false);
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StartConfigurationForm(object sender, EventArgs e)
        {
            ConfigurationForm dialog = new ConfigurationForm()
            {
                Drawer = drawer,
                DrawingSettings = drawingSettings,
                Clusterer = clusterer,
                DebugLogging = IsDebugConsoleEnabled(),
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                drawer = dialog.Drawer;
                clusterer = dialog.Clusterer;
                SetDebugConsoleState(dialog.DebugLogging);

                ClearClusters();
                ShowMaze();
            }
        }

        private void SaveMazeImage(object sender, EventArgs e)
        {
            try
            {
                if (maze != null)
                {
                    SaveFileDialog dialog = new SaveFileDialog
                    {
                        Filter = "Рисунок PNG (*.png)|*.png"
                    };
                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        Bitmap mazeBitmap = RenderMaze();
                        if (mazeBitmap != null)
                        {
                            mazeBitmap.Save(dialog.FileName);
                        }
                        else
                        {
                            MessageBox.Show(this,
                                "Не удалось получить изображение лабиринта");
                        }
                    }
                }
                else
                {
                    MessageBox.Show(this, "Изображение не сохранено");
                }
            }
            catch (System.Runtime.InteropServices.ExternalException ex)
            {
                string mes = String.Format("При сохранении произошла ошибка: {0}", ex);
                DebugConsole.Instance.Error(mes);
                MessageBox.Show(this, "Ошибка при сохранении");
            }
        }

        private void AboutDialog(object sender, EventArgs e)
        {
            AboutDialog about = new AboutDialog();
            about.ShowDialog(this);
        }
    }
}
