namespace Chess.Domain.Figures
{
    public class Knight : Figure, IFigure
    {
        public FigureType type
        { get { return FigureType.Knight; } }

        public Knight(bool isWhite) : base(isWhite) { }
    }
}
