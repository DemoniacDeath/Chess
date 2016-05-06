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
        public virtual IList<Position> getAvailableMovements(IBoardSquares board)
        {
            var attackMoves = getAttackZone(board);
            var invalidMoves = new List<Position>();
            foreach (var attackMove in attackMoves)
            {
                //same side figure is under attack - no move
                if (board.isSquareOccupied(attackMove, isWhite))
                {
                    invalidMoves.Add(attackMove);
                }
            }

            foreach (var invalidMove in invalidMoves)
                attackMoves.Remove(invalidMove);

            return attackMoves;
        }

    }
}