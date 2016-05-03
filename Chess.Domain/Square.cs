namespace Chess.Domain
{
    public class Square
    {
        public Figure figure { get; set; }

        public bool isEmpty;

        public Square()
        {
            isEmpty = true;
        }

        public Square(Figure _figure)
        {
            isEmpty = false;
            figure = _figure;
        }

        public Square Clone()
        {
            var newSquare = new Square();
            newSquare.isEmpty = isEmpty;
            if (!newSquare.isEmpty)
                newSquare.figure = figure.Clone();
            return newSquare;
        }
    }
}