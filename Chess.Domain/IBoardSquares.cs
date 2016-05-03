namespace Chess.Domain
{
    public interface IBoardSquares
    {
        bool isSquareEmpty(Position position);

        bool isSquareOccupied(Position position, bool isWhite);
    }
}
