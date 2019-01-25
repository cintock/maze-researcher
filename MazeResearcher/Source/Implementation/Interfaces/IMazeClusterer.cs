/*
 * Author: cintock
 * Date: 06.01.2019
 * Created by SharpDevelop.
 */

namespace Maze.Implementation
{
    /// <summary>
    /// Интерфейс поиска отдельных, несвязанных частей в лабиринте.
    /// Из одной части лабиринта нельзя попасть в другую часть лабиринта.
    /// </summary>
    public interface IMazeClusterer
    {
        MazeClusters Cluster(IMazeView maze);
    }
}
