namespace Task04
{
    public abstract class Obstacle : IGameObject
    {
        public abstract string Output { get; set; }
        public abstract int X { get; set; }
        public abstract int Y { get; set; }
    }
}
