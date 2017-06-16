/*
 * Деревья просто занимают ячейку.
 */

namespace Task04
{
    using System;

    class Tree : IGameObject
    {
        public string Output { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
