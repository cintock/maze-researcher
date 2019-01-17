/*
 * Author: cintock
 * Date: 06.01.2019
 * Created by SharpDevelop.
 */
using System;
using System.Collections.Generic;
using Maze.Implementation;

namespace Maze.UI
{
    enum MazeGeneratorsEnum
    {
        RandomMazeGenerator,
        EmptyMazeGenerator,
        EmptyDummyMazeGenerator,
        EllerModMazeGenerator
    }

    internal class MazeGeneratorsObjects : 
        ObjectsDescription<MazeGeneratorsEnum, IMazeGenerator>
    {
        static readonly MazeGeneratorsObjects instance = 
            new MazeGeneratorsObjects();

        private MazeGeneratorsObjects()
        {
            RegisterObject(
                MazeGeneratorsEnum.RandomMazeGenerator,
                new RandomMazeGenerator(),
                "Полностью случайный лабиринт");

            RegisterObject(
                MazeGeneratorsEnum.EmptyMazeGenerator,
                new EmptyMazeGenerator(),
                "Пустой лабиринт");

            RegisterObject(
                MazeGeneratorsEnum.EmptyDummyMazeGenerator,
                new EmptyDummyMazeGenerator(),
                "Пустой лабиринт (оптимизированный вариант)");

            RegisterObject(
                MazeGeneratorsEnum.EllerModMazeGenerator,
                new EllerModMazeGenerator(),
                "Вариация алгоритма Эллера");
        }

        public static MazeGeneratorsObjects Instance()
        {
            return instance;
        }


    }
}
