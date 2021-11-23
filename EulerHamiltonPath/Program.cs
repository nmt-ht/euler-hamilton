using EulerHamiltonPath.Handlers;
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

            if(!(GraphBiz.IsUndirectedGraph(matrix) && GraphBiz.IsConnectedGraph(matrix)))
            {
                Console.WriteLine("Khong phai do thi vo huong lien thong. Dung.");
                return;
            }

            var eulerRes = GraphBiz.EulerianCycle(matrix);
            if (eulerRes == 0)
                Console.WriteLine("Do thi khong Euler.");
            else if (eulerRes == 1)
                Console.WriteLine("Do thi nua Euler.");
            else
                Console.WriteLine("Do thi Euler.");

            var hamiltonRes = GraphBiz.HamiltonianCylce(matrix);
            if (hamiltonRes == 0)
                Console.WriteLine("Do thi khong Hamilton.");
            else Console.WriteLine("Do thi Hamilton.");
        }
    }
}
