using System.Collections.Generic;

namespace Chess.Domain
{
    abstract public class Figure
    {
        public bool isWhite;
        public Position position;
        public FigureType type;

        public Figure(bool isWhite)
        {
            this.isWhite = isWhite;
        }

        public abstract Figure Clone();

        public abstract IList<Position> getAttackZone(IBoardSquares board);
        public abstract IList<Position> getAvailableMovements(IBoardSquares board);

    }
}