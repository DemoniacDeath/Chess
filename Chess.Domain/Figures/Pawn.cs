namespace Chess.Domain.Figures
{
    public class Pawn : Figure, IFigure
    {
        public FigureType Type
        { get { return FigureType.Pawn; } }

        public Pawn(bool isWhite) : base(isWhite) { }
    }
}
