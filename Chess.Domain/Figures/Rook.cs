using System.Collections.Generic;

namespace Chess.Domain.Figures
{
    public class Rook : Figure
    {
        public Rook(bool isWhite) : base(isWhite)
        {
            type = FigureType.Rook;
        }

        public override Figure Clone()
        {
            var newFigure = new Rook(isWhite);
            newFigure.position = new Position(position);
            return newFigure;
        }

        public override IList<Position> getAttackZone(IBoardSquares board)
        {
            var attackZone = new List<Position>();

            for (int x = (int)position.x + 1; x < 8; x++)
            {
                var currentPosition = new Position(x, position.y);
                attackZone.Add(currentPosition);
                if (!board.isSquareEmpty(currentPosition))
                    break;
            }
            for (int x = (int)position.x - 1; x >= 0; x--)
            {
                var currentPosition = new Position(x, position.y);
                attackZone.Add(currentPosition);
                if (!board.isSquareEmpty(currentPosition))
                    break;
            }
            for (int y = (int)position.y + 1; y < 8; y++)
            {
                var currentPosition = new Position(position.x, y);
                attackZone.Add(currentPosition);
                if (!board.isSquareEmpty(currentPosition))
                    break;
            }
            for (int y = (int)position.y - 1; y >= 0; y--)
            {
                var currentPosition = new Position(position.x, y);
                attackZone.Add(currentPosition);
                if (!board.isSquareEmpty(currentPosition))
                    break;
            }

            return attackZone;
        }
    }
}
