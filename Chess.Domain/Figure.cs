namespace Chess.Domain
{
    abstract public class Figure
    {
        public bool isWhite { get; set; }

        public Figure(bool isWhite) { this.isWhite = isWhite; }

    }
}