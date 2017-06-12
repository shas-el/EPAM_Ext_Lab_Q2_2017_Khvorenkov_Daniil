/*
 * Поле с размерами и списком объектов для отображения.
 */

namespace Task04
{
    using System.Collections.Generic;

    class Field
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public List<IGameObject> Objects { get; set; }
    }
}
