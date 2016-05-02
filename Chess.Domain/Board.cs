namespace Chess.Domain
{
    public class Board
    {
        public Square[,] Squares { get; private set; }

        public Board()
        {
            Squares = new Square[8, 8];
            for (int i = 0; i < Squares.GetLength(0); i++)
            {
                for (int j = 0; j < Squares.GetLength(1); j++)
                {
                    Squares[i, j] = new Square();
                }
            }
        }
    }
}