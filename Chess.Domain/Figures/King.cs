namespace Chess.Domain.Figures
{
    public class King : Figure, IFigure
    {
        public FigureType type
        { get { return FigureType.King; } }

        public King(bool isWhite) : base(isWhite) { }
    }
}
