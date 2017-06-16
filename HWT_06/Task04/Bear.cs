/*
 * Медведь – вид монстра.
 */

namespace Task04
{
    using System;

    class Bear : Monster
    {
        public override string Output { get; set; }

        public override int X { get; set; }

        public override int Y { get; set; }

        public override void Attack(Player p)
        {
        }

        public override void Move(int x, int y)
        {
        }
    }
}
