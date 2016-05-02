namespace Chess.Domain
{
    public class Game
    {
        public bool whitesTurn;

        public Board Board { get; set; }

        public Game()
        {
            Board = new Board();
        }

        public bool isCheck()
        {
            return true;
        }

        public bool isCheckmate()
        {
            if (!isCheck())
                return false;
            return true;
        }
    }
}
