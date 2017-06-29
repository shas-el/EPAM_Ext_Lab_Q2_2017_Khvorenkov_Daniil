/*
 * Деревья просто занимают ячейку.
 */

namespace Task04
{
    class Tree : Obstacle
    {
        public override string Output { get; set; }

        public override int X { get; set; }

        public override int Y { get; set; }
    }
}
