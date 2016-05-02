namespace Chess.Domain
{
    public class Square
    {
        public IFigure Figure { get; private set; }

        public bool isEmpty;

        public Square()
        {
            isEmpty = true;
        }

        public Square(IFigure figure)
        {
            isEmpty = false;
            Figure = figure;
        }
    }
}