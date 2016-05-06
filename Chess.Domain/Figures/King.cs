using System.Collections.Generic;

namespace Chess.Domain.Figures
{
    public class King : Figure
    {
        public King(bool isWhite) : base(isWhite)
        {
            type = FigureType.King;
        }

        public override Figure Clone()
        {
            var newFigure = new King(isWhite);
            newFigure.position = new Position(position);
            return newFigure;
        }

        public override IList<Position> getAttackZone(IBoardSquares board)
        {
            var attackZone = new List<Position>();
            if (position.x > 0)
            {
                attackZone.Add(new Position(position.x - 1, position.y));
                if (position.y > 0)
                    attackZone.Add(new Position(position.x - 1, position.y - 1));
                if (position.y < 7)
                    attackZone.Add(new Position(position.x - 1, position.y + 1));
            }
            if (position.x < 7)
            {
                attackZone.Add(new Position(position.x + 1, position.y));
                if (position.y > 0)
                    attackZone.Add(new Position(position.x + 1, position.y - 1));
                if (position.y < 7)
                    attackZone.Add(new Position(position.x + 1, position.y + 1));
            }
            if (position.y > 0)
                attackZone.Add(new Position(position.x, position.y - 1));
            if (position.y < 7)
                attackZone.Add(new Position(position.x, position.y + 1));

            return attackZone;
        }
    }
}
