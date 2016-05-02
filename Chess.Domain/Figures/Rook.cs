namespace Chess.Domain.Figures
{
    public class Rook : Figure, IFigure
    {
        public FigureType type
        { get { return FigureType.Rook; } }

        public Rook(bool isWhite) : base(isWhite) { }
    }
}
