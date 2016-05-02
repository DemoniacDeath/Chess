using Chess.Domain.Figures;
using System;
using System.Collections;
using System.IO;

namespace Chess.Domain
{
    public class GameSerializer
    {
        public void Serialize(Stream stream, Game game)
        {
            BinaryWriter writer = new BinaryWriter(stream);
            BitArray bitArray = new BitArray(257);
            byte[] bytes = new byte[33];
            int bitIndex = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int squareIndex = i * 8 + j;
                    Square square = game.board.squares[i, j];
                    if (square.isEmpty)
                    {
                        bitIndex += 4;//skip 4 bits, leaving them set as false by default
                    }
                    else
                    {
                        switch(square.figure.type)
                        {
                            case FigureType.Pawn:
                                bitArray[bitIndex++] = false;
                                bitArray[bitIndex++] = false;
                                bitArray[bitIndex++] = true;
                                break;
                            case FigureType.Knight:
                                bitArray[bitIndex++] = false;
                                bitArray[bitIndex++] = true;
                                bitArray[bitIndex++] = false;
                                break;
                            case FigureType.Bishop:
                                bitArray[bitIndex++] = false;
                                bitArray[bitIndex++] = true;
                                bitArray[bitIndex++] = true;
                                break;
                            case FigureType.Rook:
                                bitArray[bitIndex++] = true;
                                bitArray[bitIndex++] = false;
                                bitArray[bitIndex++] = false;
                                break;
                            case FigureType.Queen:
                                bitArray[bitIndex++] = true;
                                bitArray[bitIndex++] = false;
                                bitArray[bitIndex++] = true;
                                break;
                            case FigureType.King:
                                bitArray[bitIndex++] = true;
                                bitArray[bitIndex++] = true;
                                bitArray[bitIndex++] = false;
                                break;
                            default:
                                bitIndex += 3;
                                break;
                        }
                        bitArray[bitIndex++] = square.figure.isWhite;
                    }
                }
            }
            bitArray[bitIndex++] = game.whitesTurn;
            bitArray.CopyTo(bytes, 0);
            stream.Write(bytes, 0, 33);
        }

        public Game Deserialize(Stream stream)
        {
            var game = new Game();

            var bytes = new byte[33];
            stream.Read(bytes, 0, 33);

            var bitArray = new BitArray(bytes);
            for (int squareIndex = 0; squareIndex < 64; squareIndex++)
            {
                byte squareValue = 0x00;
                if (bitArray[squareIndex * 4])
                    squareValue |= 0x08;
                if (bitArray[squareIndex * 4 + 1])
                    squareValue |= 0x04;
                if (bitArray[squareIndex * 4 + 2])
                    squareValue |= 0x02;
                if (bitArray[squareIndex * 4 + 3])
                    squareValue |= 0x01;

                int i = squareIndex / 8;
                int j = squareIndex % 8;

                var isWhite = ((squareValue & 0x01) != 0);
                switch ((squareValue & 0x0e) >> 1)
                {
                    case 0x01:
                        game.board.squares[i, j] = new Square(new Pawn(isWhite));
                        break;
                    case 0x02:
                        game.board.squares[i, j] = new Square(new Knight(isWhite));
                        break;
                    case 0x03:
                        game.board.squares[i, j] = new Square(new Bishop(isWhite));
                        break;
                    case 0x04:
                        game.board.squares[i, j] = new Square(new Rook(isWhite));
                        break;
                    case 0x05:
                        game.board.squares[i, j] = new Square(new Queen(isWhite));
                        break;
                    case 0x06:
                        game.board.squares[i, j] = new Square(new King(isWhite));
                        break;
                }
            }
            game.whitesTurn = bitArray[256];

            return game;
        }
    }
}
