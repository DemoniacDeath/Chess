using System.Collections.Generic;

namespace Chess.Domain.Figures
{
    public class Knight : Figure
    {
        public Knight(bool isWhite) : base(isWhite)
        {
            type = FigureType.Knight;
        }

        public override Figure Clone()
        {
            var newFigure = new Knight(isWhite);
            newFigure.position = new Position(position);
            return newFigure;
        }

        public override IList<Position> getAttackZone(IBoardSquares board)
        {
            var attackZone = new List<Position>();
            if (position.x > 0 && position.y > 1)
                attackZone.Add(new Position(position.x - 1, position.y - 2));
            if (position.x > 1 && position.y > 0)
                attackZone.Add(new Position(position.x - 2, position.y - 1));
            if (position.x > 1 && position.y < 7)
                attackZone.Add(new Position(position.x - 2, position.y + 1));
            if (position.x > 0 && position.y < 6)
                attackZone.Add(new Position(position.x - 1, position.y + 2));
            if (position.x < 7 && position.y < 6)
                attackZone.Add(new Position(position.x + 1, position.y + 2));
            if (position.x < 6 && position.y < 7)
                attackZone.Add(new Position(position.x + 2, position.y + 1));
            if (position.x < 6 && position.y > 0)
                attackZone.Add(new Position(position.x + 2, position.y - 1));
            if (position.x < 7 && position.y > 1)
                attackZone.Add(new Position(position.x + 1, position.y - 2));

            return attackZone;
        }
    }
}
