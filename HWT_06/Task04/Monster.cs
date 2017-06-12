/*
 * Монстры могут двигаться и атаковать.
 */

namespace Task04
{
    abstract class Monster : IGameObject, IMovable
    {
        public abstract string Output { get; set; }
        public abstract int X { get; set; }
        public abstract double Y { get; set; }

        public abstract void Move(int x, int y);
        public abstract void Attack(Player p);
    }
}
