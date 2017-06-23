/*
 * Вишня – вид бонуса.
 */

namespace Task04
{
    using System;

    class Cherry : Bonus
    {
        public override string Output { get; set; }

        public override BonusType PowerUp { get; set; }

        public override int X { get; set; }

        public override int Y { get; set; }
    }
}
