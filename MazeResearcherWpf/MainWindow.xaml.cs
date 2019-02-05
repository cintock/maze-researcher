using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Maze.Logic;

namespace MazeResearcherWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IMazeView maze;
        private Bitmap mazeBitmap;

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
                MazeDrawersFactory.Instance.Create(MazeDrawersEnum.StandardMazeDrawer);

            MazeDrawingSettings drawingSettings = MazeDrawingSettings.BlackWhile;
            drawingSettings.BackgroundColor = System.Drawing.Color.LightBlue;

            drawer.SetDrawingSettings(drawingSettings);

            mazeBitmap = drawer.Draw(maze);

            BitmapSource source = (new BitmapImageConverter(mazeBitmap)).Image();

            mazeImage.Source = source;
        }
    }
}
