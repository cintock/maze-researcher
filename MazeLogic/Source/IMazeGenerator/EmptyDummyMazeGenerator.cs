/*
 * Author: cintock
 * Date: 06.01.2019
 * Created by SharpDevelop.
 */

namespace Maze.Logic
{
    /// <summary>
    /// Класс для создания пустого лабиринта.
    /// Используется пустое представление лабиринта 
    /// (не выделяется память под матрицу лабиринта).
    /// </summary>
    public class EmptyDummyMazeGenerator : IMazeGenerator
    {
        public EmptyDummyMazeGenerator()
        {
        }

        public IMazeView Generate(int row, int col)
        {
            IMazeView maze = new EmptyMazeData(row, col);
            return maze;
        }
    }
}
