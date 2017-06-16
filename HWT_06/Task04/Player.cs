/*
 * Игрок может двигаться и собирать бонусы.
 */

namespace Task04
{
    using System;

    public class Player : IGameObject, IMovable
    {
        public string Output { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public void Move(int x, int y)
        {
        }

        public void CollectBonus(Bonus b)
        {
        }
    }
}
