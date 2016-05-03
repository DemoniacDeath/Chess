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

            game.board.addFigure(new King(false), new Position(4, 0));
            game.board.addFigure(new Queen(false), new Position(3, 0));
            game.board.addFigure(new Rook(false), new Position(1, 0));
            game.board.addFigure(new Rook(false), new Position(7, 0));
            game.board.addFigure(new Bishop(false), new Position(5, 0));
            game.board.addFigure(new Knight(false), new Position(6, 0));
            game.board.addFigure(new Knight(false), new Position(3, 1));
            game.board.addFigure(new Pawn(false), new Position(0, 3));
            game.board.addFigure(new Pawn(false), new Position(1, 2));
            game.board.addFigure(new Pawn(false), new Position(2, 3));
            game.board.addFigure(new Pawn(false), new Position(3, 2));
            game.board.addFigure(new Pawn(false), new Position(4, 3));
            game.board.addFigure(new Pawn(false), new Position(5, 2));
            game.board.addFigure(new Pawn(false), new Position(7, 3));

            game.board.addFigure(new King(true), new Position(6, 7));
            game.board.addFigure(new Queen(true), new Position(6, 2));
            game.board.addFigure(new Rook(true), new Position(4, 4));
            game.board.addFigure(new Rook(true), new Position(5, 7));
            game.board.addFigure(new Bishop(true), new Position(2, 2));
            game.board.addFigure(new Bishop(true), new Position(0, 5));
            game.board.addFigure(new Knight(true), new Position(3, 3));
            game.board.addFigure(new Pawn(true), new Position(0, 6));
            game.board.addFigure(new Pawn(true), new Position(1, 5));
            game.board.addFigure(new Pawn(true), new Position(2, 4));
            game.board.addFigure(new Pawn(true), new Position(3, 5));
            game.board.addFigure(new Pawn(true), new Position(5, 3));
            game.board.addFigure(new Pawn(true), new Position(6, 6));
            game.board.addFigure(new Pawn(true), new Position(7, 6));
            return game;
        }

        static Game initializeDefaultGame()
        {
            Game game = new Game();
            game.whitesTurn = true;
            for (int j = 0; j < 8; j++)
            {
                game.board.addFigure(new Pawn(false), new Position(j, 1));
                game.board.addFigure(new Pawn(true), new Position(j, 6));
            }

            foreach (int i in new int[] { 7, 0 })
            {
                foreach (int j in new int[] { 0, 7 })
                {
                    game.board.addFigure(new Rook(i == 7), new Position(j, i));
                }
                foreach (int j in new int[] { 1, 6 })
                {
                    game.board.addFigure(new Knight(i == 7), new Position(j, i));
                }
                foreach (int j in new int[] { 2, 5 })
                {
                    game.board.addFigure(new Bishop(i == 7), new Position(j, i));
                }
                game.board.addFigure(new Queen(i == 7), new Position(3, i));
                game.board.addFigure(new King(i == 7), new Position(4, i));
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
