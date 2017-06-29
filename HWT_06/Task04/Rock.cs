/*
 * Камни просто занимают ячейку
 */

namespace Task04
{
    class Rock : Obstacle
    {
        public override string Output { get; set; }

        public override int X { get; set; }

        public override int Y { get; set; }
    }
}
