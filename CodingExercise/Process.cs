using System;
using System.IO;
using System.IO.Abstractions;

namespace CodingExercise
{
    public class Process : IProcess
    {
        IProximitySearch _ProximitySearch;
        IFileSystem _IFileSystem;
        public Process(IProximitySearch proximitySearch, IFileSystem fileSystem)
        {
            _ProximitySearch = proximitySearch;
            _IFileSystem = fileSystem;
        }
        public int Start(string[] args)
        {
            if (!ValidateArgs(args))
            {
                throw new ArgumentException("Invalid Arguments");
            }
            return _ProximitySearch.CalculateOccurences(_IFileSystem.File.ReadAllText(args[3]), args[0], args[1], Convert.ToInt32(args[2]));
        }

        private bool ValidateArgs(string[] args)
        {
            if (args.Length != 4)
            {
                Console.Write("Please enter valid arguments of length 4.");
                return false;
            }
            int range;
            bool test = int.TryParse(args[2], out range);
            if (!test)
            {
                Console.Write("Please enter a numeric argument for range");
                return false;
            }
            if (range < 2)
            {
                Console.Write("Keyword Proximity must be greater than or equal to 2");
                return false;
            }
            string input = args[3];
            if (!File.Exists(input))
            {
                Console.Write("File does not exist. please verify the path");
                return false;
            }
            try
            {
                input = _IFileSystem.File.ReadAllText(args[3]);
            }
            catch (Exception)
            {
                throw new Exception("Error Reading from File");
            };
            return true;
        }
    }
}
