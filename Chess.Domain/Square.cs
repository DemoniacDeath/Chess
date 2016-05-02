namespace Chess.Domain
{
    public class Square
    {
        public IFigure figure { get; private set; }

        public bool isEmpty;

        public Square()
        {
            isEmpty = true;
        }

        public Square(IFigure _figure)
        {
            isEmpty = false;
            figure = _figure;
        }
    }
}