using Chess.Domain;
using Chess.Domain.Figures;
using System.IO;
using System.Text;

namespace Chess.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = Encoding.Default;

            var game = initializeTestGame();

            printBoard(game.board);

            if (game.isCheckmate())
                System.Console.WriteLine("Checkmate!");
            else if (game.isCheck())
                System.Console.WriteLine("Check");

            System.Console.ReadKey(true);
        }

        static Game initializeTestGame()
        {
            Game game = new Game();
            game.whitesTurn = false;

            game.board.squares[0, 4] = new Square(new King(false));
            game.board.squares[0, 3] = new Square(new Queen(false));
            game.board.squares[0, 1] = new Square(new Rook(false));
            game.board.squares[0, 7] = new Square(new Rook(false));
            game.board.squares[0, 5] = new Square(new Bishop(false));
            game.board.squares[0, 6] = new Square(new Knight(false));
            game.board.squares[1, 3] = new Square(new Knight(false));
            game.board.squares[3, 0] = new Square(new Pawn(false));
            game.board.squares[2, 1] = new Square(new Pawn(false));
            game.board.squares[3, 2] = new Square(new Pawn(false));
            game.board.squares[2, 3] = new Square(new Pawn(false));
            game.board.squares[3, 4] = new Square(new Pawn(false));
            game.board.squares[2, 5] = new Square(new Pawn(false));
            game.board.squares[3, 7] = new Square(new Pawn(false));

            game.board.squares[7, 6] = new Square(new King(true));
            game.board.squares[2, 6] = new Square(new Queen(true));
            game.board.squares[4, 4] = new Square(new Rook(true));
            game.board.squares[7, 5] = new Square(new Rook(true));
            game.board.squares[2, 2] = new Square(new Bishop(true));
            game.board.squares[5, 0] = new Square(new Bishop(true));
            game.board.squares[3, 3] = new Square(new Knight(true));
            game.board.squares[6, 0] = new Square(new Pawn(true));
            game.board.squares[5, 1] = new Square(new Pawn(true));
            game.board.squares[4, 2] = new Square(new Pawn(true));
            game.board.squares[5, 3] = new Square(new Pawn(true));
            game.board.squares[3, 5] = new Square(new Pawn(true));
            game.board.squares[6, 6] = new Square(new Pawn(true));
            game.board.squares[6, 7] = new Square(new Pawn(true));


            return game;
        }

        static Game initializeDefaultGame()
        {
            Game game = new Game();
            game.whitesTurn = true;
            for (int j = 0; j < 8; j++)
            {
                game.board.squares[1, j] = new Square(new Pawn(false));
                game.board.squares[6, j] = new Square(new Pawn(true));
            }

            foreach (int i in new int[] { 0, 7 })
            {
                foreach (int j in new int[] { 0, 7 })
                {
                    game.board.squares[i, j] = new Square(new Rook(i == 7));
                }
                foreach (int j in new int[] { 1, 6 })
                {
                    game.board.squares[i, j] = new Square(new Knight(i == 7));
                }
                foreach (int j in new int[] { 2, 5 })
                {
                    game.board.squares[i, j] = new Square(new Bishop(i == 7));
                }
                game.board.squares[i, 3] = new Square(new Queen(i == 7));
                game.board.squares[i, 4] = new Square(new King(i == 7));
            }
            return game;
        }

        static void printBoard(Board board)
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
                            printSquare(board.squares[i, j]);
                        }
                    }
                }
                System.Console.WriteLine();
            }
        }

        static void printSquare(Square square)
        {
            if (square.isEmpty)
                System.Console.Write(" ");
            else
            {
                switch(square.figure.type)
                {
                    case FigureType.Pawn:
                        System.Console.Write(square.figure.isWhite ? "P" : "p");
                        break;
                    case FigureType.Knight:
                        System.Console.Write(square.figure.isWhite ? "N" : "n");
                        break;
                    case FigureType.Bishop:
                        System.Console.Write(square.figure.isWhite ? "B" : "b");
                        break;
                    case FigureType.Rook:
                        System.Console.Write(square.figure.isWhite ? "R" : "r");
                        break;
                    case FigureType.Queen:
                        System.Console.Write(square.figure.isWhite ? "Q" : "q");
                        break;
                    case FigureType.King:
                        System.Console.Write(square.figure.isWhite ? "K" : "k");
                        break;
                }
            }
        }
    }
}
