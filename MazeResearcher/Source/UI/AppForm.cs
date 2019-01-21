using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

            InitLogger();
        }

        private void InitLogger()
        {
            log4net.Config.XmlConfigurator.Configure();
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
                MazeClusterersEnum.MazeClustererCyclic);
        }

        void ClearImageBitmap()
        {
            mazePicturebox.Image = null;
        }

        void FindClusters()
        {            
            clusters = clusterer.Cluster(maze);
            clusterCountTextbox.Text = clusters.Count().ToString();
        }

        private Bitmap RenderMaze()
        {
            Bitmap mazeImage = null;            
            try
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
                        mazeImage = mazeDrawer.Draw(maze, clusters);
                    }
                    else
                    {
                        mazeImage = mazeDrawer.Draw(maze, null);
                    }
                }
            }
            catch (MazeException ex)
            {
                DebugConsole.Instance.Error(string.Format("Возникло исключение: {0}", ex.ToString()));
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
            Stopwatch methodTime = Stopwatch.StartNew();
            try
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
            }
            catch (MazeException ex)
            {
                DebugConsole.Instance.Error(
                    string.Format("При создании лабиринта произошла ошибка: {0}", 
                    ex.ToString()));
            }
            methodTime.Stop();
            DebugConsole.Instance.Info(
                string.Format("Лабиринт ({0} x {1}) создан и нарисован за {2} мс",
                maze.RowCount, maze.ColCount, methodTime.ElapsedMilliseconds));
        }

        void SizeTrackbarChanged(object sender, EventArgs e)
        {
            mazeSizeLabel.Text = string.Format("Строк {0}; Столбцов {1}",
                                                mazeRowsTrackbar.Value, mazeColumnsTrackbar.Value);
        }

        void DebugState()
        {
            debugConsole.Visible = debugConsoleEnabled;
            mazeViewSplitContainer.Panel2Collapsed = !debugConsoleEnabled;

            LogTextboxAppender.LoggingTextbox = debugConsoleEnabled ? debugConsole : null;
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

        private void AboutDialog(Object sender, EventArgs e)
        {
            AboutDialog about = new AboutDialog();
            about.ShowDialog(this);
        }
    }
}
