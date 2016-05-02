namespace Chess.Domain.Figures
{
    public class Queen : Figure, IFigure
    {
        public FigureType type
        { get { return FigureType.Queen; } }

        public Queen(bool isWhite) : base(isWhite) { }
    }
}
