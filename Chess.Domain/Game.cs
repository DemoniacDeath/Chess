namespace Chess.Domain
{
    public class Game
    {
        public bool whitesTurn;

        public Board board { get; set; }

        public Game()
        {
            board = new Board();
        }

        public bool isCheck(bool forWhite)
        {
            //TODO: move coordinates to figures
            int kingI = 0, kingJ = 0;
            bool noKing = true;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (!board.squares[i, j].isEmpty && board.squares[i, j].figure.type == FigureType.King && board.squares[i, j].figure.isWhite == forWhite)
                    {
                        kingI = i;
                        kingJ = j;
                        noKing = false;
                    }
                }
            }
            if (noKing)
                throw new System.Exception("No king on board");

            return isSquareUnderAttack(kingI, kingJ, forWhite);
        }

        public bool isCheck()
        {
            return isCheck(whitesTurn);
        }

        public bool isCheckmate(bool forWhite)
        {
            if (!isCheck(forWhite))
                return false;
            //TODO: large chunk of work here
            return true;
        }

        public bool isCheckmate()
        {
            return isCheckmate(whitesTurn);
        }

        public bool isSquareUnderAttack(int i, int j, bool forWhite)
        {
            //TODO: main chunk of work here
            return forWhite;
        }
    }
}
