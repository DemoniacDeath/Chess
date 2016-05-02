namespace Chess.Domain.Figures
{
    public class Bishop : Figure, IFigure
    {
        public FigureType Type
        { get { return FigureType.Bishop; } }

        public Bishop(bool isWhite) : base(isWhite) { }
    }
}
