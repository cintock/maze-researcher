/*
 * Author: cintock
 * Date: 06.01.2019
 * Created by SharpDevelop.
 */

namespace Maze.Implementation
{
    /// <summary>
    /// Класс для хранения пустого лабиринта.
    /// Содержит только размеры лабиринта.
    /// Внутренней матрицы значений ячеек нет.
    /// </summary>
    public class EmptyMazeData : BaseMazeData
    {
        public EmptyMazeData(int row, int col) :
            base(row, col)
        {
        }

        public override MazeSide GetCell(int row, int col)
        {
            MazeSide cell = MazeSide.None;
            cell = AddExternalBorders(row, col, cell);
            return cell;
        }
    }
}
