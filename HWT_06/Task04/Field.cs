/*
 * Поле с размерами и прямоугольным массивом ячеек.
 */

namespace Task04
{
    class Field
    {
        public Field (int width, int height)
        {
            Width = width;
            Height = height;
            Tiles = new Tile[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Tiles[i, j] = new Tile();
                    Tiles[i, j].X = i;
                    Tiles[i, j].Y = j;
                }
            }
        }

        public int Height { get; set; }
        public int Width { get; set; }
        public Tile[,] Tiles { get; set; }
    }
}
