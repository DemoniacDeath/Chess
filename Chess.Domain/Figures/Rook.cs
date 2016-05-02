namespace Chess.Domain.Figures
{
    public class Rook : Figure, IFigure
    {
        public FigureType Type
        { get { return FigureType.Rook; } }

        public Rook(bool isWhite) : base(isWhite) { }
    }
}
