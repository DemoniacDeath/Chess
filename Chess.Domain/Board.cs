using System.Collections.Generic;
using System.Linq;

namespace Chess.Domain
{
    public class Board : IBoardSquares
    {
        public Square[,] squares { get; private set; }

        public List<Figure> figures { get; private set; }

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
            figures = new List<Figure>();
        }

        public Board Clone()
        {
            var newBoard = new Board();
            foreach (var figure in figures)
            {
                newBoard.addFigure(figure.Clone(), figure.position);
            }
            return newBoard;
        }

        public Figure getFigureByPosition(Position position)
        {
            if (!isSquareEmpty(position))
                return getSquareByPosition(position).figure;

            return null;
        }

        public Square getSquareByPosition(Position position)
        {
            return squares[position.y, position.x];
        }

        public bool isSquareEmpty(Position position)
        {
            return getSquareByPosition(position).isEmpty;
        }

        public bool isSquareOccupied(Position position, bool isWhite)
        {
            return !isSquareEmpty(position) && getFigureByPosition(position).isWhite == isWhite;
        }

        public void addFigure(Figure figure, Position position)
        {
            figures.Add(figure);

            figure.position = position;

            getSquareByPosition(position).figure = figure;
            getSquareByPosition(position).isEmpty = false;
        }

        public bool moveFigure(Figure figure, Position position)
        {
            var attackedFigure = getFigureByPosition(position);
            if (attackedFigure != null)
            {
                if (attackedFigure.isWhite == figure.isWhite)
                    return false;
                if (attackedFigure.type == FigureType.King)
                    return false;
                figures.Remove(attackedFigure);
            }
            figure.position = position;
            getSquareByPosition(position).figure = figure;
            getSquareByPosition(position).isEmpty = false;


            return true;
        }

        public IList<Figure> getFiguresByType(FigureType type, bool isWhite)
        {
            var list = from figure in figures
                       where figure.isWhite == isWhite && figure.type == type
                       select figure;
            return list.ToList();
        }

        public IList<Figure> getFiguresByIsWhite(bool isWhite)
        {
            var list = from figure in figures
                       where figure.isWhite == isWhite
                       select figure;
            return list.ToList();
        }

        public bool isCheck(bool forWhite)
        {
            var kingList = getFiguresByType(FigureType.King, forWhite);
            if (kingList.Count() != 1)
                throw new System.Exception("Wrong number of kings on board");

            var king = kingList[0];

            return isSquareUnderAttack(king.position, forWhite);
        }

        public bool isSquareUnderAttack(Position position, bool forWhite)
        {
            var figures = getFiguresByIsWhite(!forWhite);
            {
                foreach (var figure in figures)
                {
                    var attackZone = figure.getAttackZone(this);
                    foreach (var attackedPosition in attackZone)
                    {
                        if (attackedPosition == position)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}