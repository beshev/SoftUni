using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Piece> result = new List<Piece>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmdArg = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);
                string pieceName = cmdArg[0];
                string composer = cmdArg[1];
                string key = cmdArg[2];
                Piece currentPiece = new Piece(pieceName, composer, key);
                result.Add(currentPiece);
            }
            string command = Console.ReadLine();
            while (command != "Stop")
            {
                string[] cmdArg = command
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);
                string type = cmdArg[0];
                string piece = cmdArg[1];
                Piece currentPiece = result.FirstOrDefault(x => x.Name == piece);
                if (type == "Add")
                {
                    AddPieceIfExist(result, currentPiece, piece, cmdArg[2], cmdArg[3]);
                }
                else if (type == "Remove")
                {
                    RemovePieceIfExist(result, currentPiece,piece);
                }
                else if (type == "ChangeKey")
                {
                    ChangeKeyOfPieceIfExist(result, currentPiece, cmdArg[2],piece);
                }
                command = Console.ReadLine();
            }
            result.OrderBy(x => x.Name)
                .ThenBy(x => x.Composer)
                .ToList()
                .ForEach(x => Console.WriteLine(x));
        }

        static void AddPieceIfExist(List<Piece> result,Piece currentPiece, string piece , string composer,string key)
        {

            if (result.Contains(currentPiece))
            {
                Console.WriteLine($"{piece} is already in the collection!");
            }
            else
            {
                result.Add(new Piece(piece, composer, key));
                Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
            }
        }

        static void RemovePieceIfExist(List<Piece> result, Piece currentPiece,string piece)
        {
            if (result.Contains(currentPiece))
            {
                result.Remove(currentPiece);
                Console.WriteLine($"Successfully removed {currentPiece.Name}!");
            }
            else
            {
                Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
            }
        }

        static void ChangeKeyOfPieceIfExist(List<Piece> result, Piece currentPiece, string newKey,string piece)
        {
            if (result.Contains(currentPiece))
            {
                currentPiece.Key = newKey;
                Console.WriteLine($"Changed the key of {currentPiece.Name} to {newKey}!");
            }
            else
            {
                Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
            }
        }
    }

    class Piece
    {
        public string Name { get; set; }

        public string Composer { get; set; }

        public string Key { get; set; }

        public Piece(string name, string composer, string key)
        {
            this.Name = name;
            this.Composer = composer;
            this.Key = key;
        }

        public override string ToString()
        {
            return $"{Name} -> Composer: {Composer}, Key: {Key}";
        }
    }
}
