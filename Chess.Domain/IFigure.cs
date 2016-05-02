using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Domain
{
    public interface IFigure
    {
        bool isWhite { get; set; }

        FigureType type { get; }
    }
}
