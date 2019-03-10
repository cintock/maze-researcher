using Maze.Logic;
using System.Windows;

namespace MazeResearcherWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IMazeClusterer clusterer;
        private IMazeGenerator mazeGenerator;

        private IMazeView maze;
        private MazeClusters clusters;
        
        private bool showClusters;

        public MainWindow()
        {
            InitializeComponent();

            mazeGenerator =
                MazeGeneratorsFactory.Instance.Create(
                    MazeGeneratorsEnum.EllerModMazeGenerator);

            clusterer =
                MazeClusterersFactory.Instance.Create(MazeClusterersEnum.MazeClustererCyclic);
        }

        private void CreateMaze(object sender, RoutedEventArgs e)
        {
            int rowCount = (int)rowSlider.Value;
            int colCount = (int)columnSlider.Value;

            maze = mazeGenerator.Generate(rowCount, colCount);
            clusters = null;

            DrawMaze();
        }

        private void DrawMaze()
        {
            if (!(maze is null))
            {
                IMazeDrawer drawer =
                    MazeDrawersFactory.Instance.Create(MazeDrawersEnum.StandardMazeDrawer);

                MazeDrawingSettings drawingSettings = MazeDrawingSettings.BlackWhile;
                drawingSettings.BackgroundColor = 0xADD8E6u;

                if (showClusters)
                {
                    if (clusters is null)
                    {
                        clusters = clusterer.Cluster(maze);
                    }
                }

                drawer.SetDrawingSettings(drawingSettings);

                byte[] img;
                if (showClusters)
                {
                    img = drawer.Draw(maze, clusters);
                }
                else
                {
                    img = drawer.Draw(maze);
                }

                mazeImage.Source = BitmapImageConverter.FromBytes(img);
            }
        }

        private void ShowClustersChecked(object sender, RoutedEventArgs e)
        {
            showClusters = true;
            DrawMaze();
        }

        private void ShowClustersUnchecked(object sender, RoutedEventArgs e)
        {
            showClusters = false;
            DrawMaze();
        }

    }
}
