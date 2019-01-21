/*
 * Author: cintock
 * Date: 06.01.2019
 * Created by SharpDevelop.
 */

namespace Maze.Implementation
{
    /// <summary>
    /// Класс для создания пустого лабиринта.
    /// Выделяется память как для лабиринта, содержащего значения.
    /// </summary>
    public class EmptyMazeGenerator : IMazeGenerator
	{
		public EmptyMazeGenerator()
		{
		}
		
		public IMazeView Generate(int row, int col)
		{
			IMazeView maze = new MazeData(row, col);
			return maze;
		}
	}
}
