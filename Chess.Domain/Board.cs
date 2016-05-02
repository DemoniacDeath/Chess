namespace Chess.Domain
{
    public class Board
    {
        public Square[,] squares { get; private set; }

        public Board()
        {
            squares = new Square[8, 8];
            for (int i = 0; i < squares.GetLength(0); i++)
            {
                for (int j = 0; j < squares.GetLength(1); j++)
                {
                    squares[i, j] = new Square();
                }
            }
        }
    }
}