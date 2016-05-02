using Chess.Domain;
using Chess.Domain.Figures;
using System.Text;

namespace Chess.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = Encoding.Default;
            Game Game = new Game();
            Game.whitesTurn = true;

            initializeDefaultBoard(Game.Board);

            printBoard(Game.Board);
            if (Game.isCheckmate())
                System.Console.WriteLine("Checkmate!");
            else if (Game.isCheck())
                System.Console.WriteLine("Check");
            System.Console.ReadKey(true);
        }

        static void initializeDefaultBoard(Board Board)
        {
            for (int j = 0; j < 8; j++)
            {
                Board.Squares[1, j] = new Square(new Pawn(false));
                Board.Squares[6, j] = new Square(new Pawn(true));
            }

            foreach (int i in new int[] { 0, 7 })
            {
                foreach (int j in new int[] { 0, 7 })
                {
                    Board.Squares[i, j] = new Square(new Rook(i == 7));
                }
                foreach (int j in new int[] { 1, 6 })
                {
                    Board.Squares[i, j] = new Square(new Knight(i == 7));
                }
                foreach (int j in new int[] { 2, 5 })
                {
                    Board.Squares[i, j] = new Square(new Bishop(i == 7));
                }
                Board.Squares[i, 3] = new Square(new Queen(i == 7));
                Board.Squares[i, 4] = new Square(new King(i == 7));
            }

        }

        static void printBoard(Board Board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (i == 0)
                    {
                        if (j == 0) System.Console.Write((char)218);
                        else if (j < 8) System.Console.Write((char)194);
                        else if (j == 8) System.Console.Write((char)191);
                    }
                    else if (i < 8)
                    {
                        if (j == 0) System.Console.Write((char)195);
                        else if (j < 8) System.Console.Write((char)197);
                        else if (j == 8) System.Console.Write((char)180);
                    }
                    else if (i == 8)
                    {
                        if (j == 0) System.Console.Write((char)192);
                        else if (j < 8) System.Console.Write((char)193);
                        else if (j == 8) System.Console.Write((char)217);
                    }
                    if (j < 8)
                        System.Console.Write((char)196);
                }
                System.Console.WriteLine();
                if (i < 8)
                {

                    for (int j = 0; j < 9; j++)
                    {
                        System.Console.Write((char)179);
                        if (j < 8)
                        {
                            printSquare(Board.Squares[i, j]);
                        }
                    }
                }
                System.Console.WriteLine();
            }
        }

        static void printSquare(Square Square)
        {
            if (Square.isEmpty)
                System.Console.Write(" ");
            else
            {
                switch(Square.Figure.Type)
                {
                    case FigureType.Pawn:
                        System.Console.Write(Square.Figure.isWhite ? "P" : "p");
                        break;
                    case FigureType.Knight:
                        System.Console.Write(Square.Figure.isWhite ? "N" : "n");
                        break;
                    case FigureType.Bishop:
                        System.Console.Write(Square.Figure.isWhite ? "B" : "b");
                        break;
                    case FigureType.Rook:
                        System.Console.Write(Square.Figure.isWhite ? "R" : "r");
                        break;
                    case FigureType.Queen:
                        System.Console.Write(Square.Figure.isWhite ? "Q" : "q");
                        break;
                    case FigureType.King:
                        System.Console.Write(Square.Figure.isWhite ? "K" : "k");
                        break;
                }
            }
        }
    }
}
