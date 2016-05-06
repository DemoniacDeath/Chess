using System.Collections.Generic;

namespace Chess.Domain.Figures
{
    public class Bishop : Figure
    {
        public Bishop(bool isWhite) : base(isWhite)
        {
            type = FigureType.Bishop;
        }

        public override Figure Clone()
        {
            var newFigure = new Bishop(isWhite);
            newFigure.position = new Position(position);
            return newFigure;
        }

        public override IList<Position> getAttackZone(IBoardSquares board)
        {
            var attackZone = new List<Position>();

            for (int x = position.x + 1, y = position.y + 1; x < 8 && y < 8; x++, y++)
            {
                var currentPosition = new Position(x, y);
                attackZone.Add(currentPosition);
                if (!board.isSquareEmpty(currentPosition))
                    break;
            }
            for (int x = (int)position.x + 1, y = position.y - 1; x < 8 && y >= 0; x++, y--)
            {
                var currentPosition = new Position(x, y);
                attackZone.Add(currentPosition);
                if (!board.isSquareEmpty(currentPosition))
                    break;
            }
            for (int x = position.x - 1, y = position.y - 1; x >= 0 && y >= 0; x--, y--)
            {
                var currentPosition = new Position(x, y);
                attackZone.Add(currentPosition);
                if (!board.isSquareEmpty(currentPosition))
                    break;
            }
            for (int x = position.x - 1, y = position.y + 1; x >= 0 && y < 8; x--, y++)
            {
                var currentPosition = new Position(x, y);
                attackZone.Add(currentPosition);
                if (!board.isSquareEmpty(currentPosition))
                    break;
            }


            return attackZone;
        }
    }
}
