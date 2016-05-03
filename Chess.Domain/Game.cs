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
            return board.isCheck(forWhite);
        }

        public bool isCheck()
        {
            return isCheck(whitesTurn);
        }

        public bool isCheckmate(bool forWhite)
        {
            if (!isCheck(forWhite))
                return false;

            var figures = board.getFiguresByIsWhite(forWhite);
            foreach (var figure in figures)
            {
                var moves = figure.getAvailableMovements(board);
                foreach (var movePosition in moves)
                {
                    var testBoard = board.Clone();
                    if (!testBoard.moveFigure(testBoard.getFigureByPosition(figure.position), movePosition))
                        continue;
                    if (!testBoard.isCheck(forWhite))
                        return false;
                }
            }

            return true;
        }

        public bool isCheckmate()
        {
            return isCheckmate(whitesTurn);
        }
    }
}
