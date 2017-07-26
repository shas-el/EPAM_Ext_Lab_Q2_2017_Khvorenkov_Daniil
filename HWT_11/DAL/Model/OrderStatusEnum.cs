using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public enum OrderStatus //todo pn enum выносим в отдельный файл (всегда!) и у него в конце желательно добавлять "Enum", чтобы в solution explorer сразу было понятно, что за файл.
    {
        New,
        Underway,
        Shipped
    }
}
