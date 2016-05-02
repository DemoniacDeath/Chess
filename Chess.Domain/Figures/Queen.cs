namespace Chess.Domain.Figures
{
    public class Queen : Figure, IFigure
    {
        public FigureType Type
        { get { return FigureType.Queen; } }

        public Queen(bool isWhite) : base(isWhite) { }
    }
}
