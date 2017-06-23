/*
 * Камни просто занимают ячейку
 */

namespace Task04
{
    class Rock : IGameObject
    {
        public string Output { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
