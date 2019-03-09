using Maze.Logic;
using System.Windows;

namespace MazeResearcherWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IMazeView maze;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateMaze(object sender, RoutedEventArgs e)
        {
            int rowCount = (int)rowSlider.Value;
            int colCount = (int)columnSlider.Value;

            IMazeGenerator mazeGenerator = 
                MazeGeneratorsFactory.Instance.Create(
                    MazeGeneratorsEnum.EllerModMazeGenerator);

            maze = mazeGenerator.Generate(rowCount, colCount);

            IMazeDrawer drawer =
                MazeDrawersFactory.Instance.Create(MazeDrawersEnum.SimpleMazeDrawer);

            MazeDrawingSettings drawingSettings = MazeDrawingSettings.BlackWhile;
            drawingSettings.BackgroundColor = 0xADD8E6u;

            drawer.SetDrawingSettings(drawingSettings);

            byte[] img = drawer.Draw(maze);

            mazeImage.Source = BitmapImageConverter.FromBytes(img);
        }
    }
}
