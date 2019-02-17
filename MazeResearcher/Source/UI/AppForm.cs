using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Maze.Logic;

namespace Maze.UI
{
    public partial class AppForm : Form
    {
        private MazeDrawingSettings drawingSettings;

        private ComboboxValues<MazeGeneratorsEnum> generatorsComboboxValues;

        private MazeDrawersEnum drawingAlgo;
        private MazeClusterersEnum clustererAlgo;
        // private MazeRotateEnum mazeRotation;

        private IMazeView maze;
        private MazeClusters clusters;

        private bool debugConsoleEnabled;

        public AppForm()
        {
            InitializeComponent();

            InitGeneratorsCombobox();

            SizeTrackbarChanged(null, null);

            DefaultSettings();

            SetDebugConsoleState(false);

            // todo: отобразить связанность областей вынести в меню вид

            // todo: сделать меню правка - копировать

            // todo: сделать контекстное меню по правой кнопке мыши на области лабиринта ->
            // копировать, сохранить изображение

            InitLogger();
        }

        private void InitGeneratorsCombobox()
        {
            generatorsComboboxValues = new ComboboxValues<MazeGeneratorsEnum>();

            generatorsComboboxValues.AddElement(
                MazeGeneratorsEnum.EllerModMazeGenerator, "Вариация алгоритма Эллера (пустая строка внизу)");

            generatorsComboboxValues.AddElement(
                MazeGeneratorsEnum.RandomMazeGenerator, "Полностью случайный лабиринт");

            generatorsComboboxValues.AddElement(
                MazeGeneratorsEnum.EmptyDummyMazeGenerator, "Пустой");

            mazeGenerationAlgoCombobox.Items.Clear();

            mazeGenerationAlgoCombobox.Items.AddRange(generatorsComboboxValues.Names());

            mazeGenerationAlgoCombobox.SelectedIndex = generatorsComboboxValues.IndexByValue(
                MazeGeneratorsEnum.EllerModMazeGenerator);
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
                BorderColor = 0x000000,
                BackgroundColor = 0xF0FFFF,
                SideColor = 0x006400
            };

            drawingAlgo = MazeDrawersEnum.StandardMazeDrawer;

            clustererAlgo = MazeClusterersEnum.MazeClustererCyclic;

            //mazeRotation = MazeRotateEnum.Rotate0;
        }

        void FindClusters()
        {
            IMazeClusterer clusterer = 
                MazeClusterersFactory.Instance.Create(clustererAlgo);

            clusters = clusterer.Cluster(maze);
            string clustersCountStr = clusters.Count().ToString();
            clusterCountTextbox.Text = clustersCountStr;

            DebugConsole.Instance.Info(
                string.Format("Выполнен поиск областей. Найдено областей: {0}",
                clustersCountStr));
        }

        private Image RenderMaze()
        {
            byte[] mazeBmpImage = null;
            IMazeDrawer drawer = MazeDrawersFactory.Instance.Create(drawingAlgo);
            drawer.SetDrawingSettings(drawingSettings);
            // drawer = new MazeDrawerRotateDecorator(drawer, mazeRotation);

            try
            {
                if (maze != null)
                {
                    if (showMazeClustersCheckbox.Checked)
                    {
                        mazeBmpImage = drawer.Draw(maze, clusters);
                    }
                    else
                    {
                        mazeBmpImage = drawer.Draw(maze);
                    }
                }
            }
            catch (MazeException ex)
            {
                DebugConsole.Instance.Error(
                    string.Format("Возникло исключение: {0}", ex.ToString()));
            }
            Image mazeImage;
            using (MemoryStream ms = new MemoryStream(mazeBmpImage))
            {
                mazeImage = new Bitmap(Image.FromStream(ms));
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
                int generationAlgoComboboxIndex = mazeGenerationAlgoCombobox.SelectedIndex;
                if (generationAlgoComboboxIndex >= 0)
                {
                    IMazeGenerator selectedGenerator = 
                        MazeGeneratorsFactory.Instance.Create(
                            generatorsComboboxValues.ValueByIndex(generationAlgoComboboxIndex));

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
                Drawer = drawingAlgo,
                DrawingSettings = drawingSettings,
                Clusterer = clustererAlgo,
                DebugLogging = IsDebugConsoleEnabled(),
                //Rotation = mazeRotation
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                drawingAlgo = dialog.Drawer;
                clustererAlgo = dialog.Clusterer;
                //mazeRotation = dialog.Rotation;
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
                        Filter = "Рисунок PNG (*.png)|*.png|Рисунок BMP (*.bmp)|*.bmp"
                    };
                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        Image mazeBitmap = RenderMaze();
                        if (mazeBitmap != null)
                        {
                            mazeBitmap.Save(dialog.FileName, ImageFormatByFilename(dialog.FileName));
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
                string mes = string.Format("При сохранении произошла ошибка: {0}", ex);
                DebugConsole.Instance.Error(mes);
                MessageBox.Show(this, "Ошибка при сохранении");
            }
        }

        private ImageFormat ImageFormatByFilename(string fileName)
        {
            ImageFormat format = ImageFormat.Bmp;
            String extension = Path.GetExtension(fileName).ToLower();
            switch (extension)
            {
                case ".png":
                    format = ImageFormat.Png;
                    break;

                case ".bmp":
                    format = ImageFormat.Bmp;
                    break;

                // не содержит расширения
                case "":
                    break;

                default:
                    throw new ArgumentException("Данный формат файла не поддерживается");
            }

            return format;
        }

        private void AboutDialog(object sender, EventArgs e)
        {
            AboutDialog about = new AboutDialog();
            about.ShowDialog(this);
        }
    }
}
