/*
 * Ячейка игрового поля. Имеет координаты и может содержать игровой объект.
 */

namespace Task04
{
    class Tile : ILocatable
    {
        public int X { get; set; }

        public int Y { get; set; }

        public IGameObject GameObject { get; set; }
    }
}
