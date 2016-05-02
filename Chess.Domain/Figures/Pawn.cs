namespace Chess.Domain.Figures
{
    public class Pawn : Figure, IFigure
    {
        public FigureType type
        { get { return FigureType.Pawn; } }

        public Pawn(bool isWhite) : base(isWhite) { }
    }
}
