/*
 * Деревья просто занимают ячейку.
 */

namespace Task04
{
    using System;

    class Tree : IGameObject//todo pn ты выделил базовый класс для бонусов и для монстров, а для препятствий?
    {
        public string Output { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
