using EulerHamiltonPath.Helpers;
using System;

namespace EulerHamiltonPath
{
    class Program
    {
        private const string ADJACENCY_MATRIX_INPUT_FILE = @".\Source\input.txt";
        static void Main(string[] args)
        {
            var matrix = Helper.InitAdjacencyMatrix(ADJACENCY_MATRIX_INPUT_FILE);
            Helper.PrintMatrixToScreen(matrix);
            Console.WriteLine();
        }
    }
}
