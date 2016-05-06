using System.Collections.Generic;

namespace Chess.Domain.Figures
{
    public class Pawn : Figure
    {
        public Pawn(bool isWhite) : base(isWhite)
        {
            type = FigureType.Pawn;
        }

        public override Figure Clone()
        {
            var newFigure = new Pawn(isWhite);
            newFigure.position = new Position(position);
            return newFigure;
        }

        public override IList<Position> getAttackZone(IBoardSquares board)
        {
            int yOffset = isWhite ? -1 : 1;
            var attackZone = new List<Position>();
            if (position.x > 0)
                attackZone.Add(new Position(position.x - 1, position.y + yOffset));
            if (position.x < 7)
                attackZone.Add(new Position(position.x + 1, position.y + yOffset));

            return attackZone;
        }
    }
}
