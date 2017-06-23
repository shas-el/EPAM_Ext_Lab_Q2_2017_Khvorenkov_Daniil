/*
 * Абстрактный бонус. Может сообщить о своем типе.
 */

namespace Task04
{
    public abstract class Bonus : IGameObject
    {
        public enum BonusType { }
        public abstract string Output { get; set; }
        public abstract int X { get; set; }
        public abstract int Y { get; set; }
        public abstract BonusType PowerUp { get; set; }
    }
}
