namespace Chess.Domain.Figures
{
    public class Knight : Figure, IFigure
    {
        public FigureType Type
        { get { return FigureType.Knight; } }

        public Knight(bool isWhite) : base(isWhite) { }
    }
}
