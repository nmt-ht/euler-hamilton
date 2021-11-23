using Models;
using System;

namespace EulerHamiltonPath.Handlers
{
    public static class GraphBiz
    {
        public static int EulerianCycle(AdjacencyMatrix adjacencyMatrix)
        {
            int[] degrees = CountDegrees(adjacencyMatrix);

            int oddDegreeVertices = 0;
            for (int i = 0; i < degrees.Length; i++)
                if (degrees[i] % 2 != 0)
                    oddDegreeVertices++;

            if (oddDegreeVertices > 2)
                return 0;

            return (oddDegreeVertices == 2) ? 1 : 2;
        }

        public static int HamiltonianCylce(AdjacencyMatrix adjacencyMatrix)
        {
            path = new int[adjacencyMatrix.N];
            for (int i = 0; i < adjacencyMatrix.N; i++)
                path[i] = -1;

            path[0] = 0;

            if (!HamiltonianCylceTraverse(adjacencyMatrix, path, 1))
                return 0;

            printSolution(path, adjacencyMatrix.N);

            return 1;
        }

        #region Support functions
        //DFS Traverse
        private static void Traverse(int u, bool[] visited, AdjacencyMatrix adjacencyMatrix)
        {
            visited[u] = true;

            for (int v = 0; v < adjacencyMatrix.N; v++)
            {
                if (adjacencyMatrix.Array[u, v] == 1)
                {
                    if (!visited[v])
                        Traverse(v, visited, adjacencyMatrix);
                }
            }
        }

        public static bool IsConnectedGraph(AdjacencyMatrix adjacencyMatrix)
        {
            bool[] visited = new bool[adjacencyMatrix.N];
            for (int u = 0; u < adjacencyMatrix.N; u++)
            {
                for (int i = 0; i < adjacencyMatrix.N; i++)
                    visited[i] = false;

                Traverse(u, visited, adjacencyMatrix);

                for (int i = 0; i < adjacencyMatrix.N; i++)
                {
                    if (!visited[i])
                        return false;
                }
            }
            return true;
        }

        private static int[] CountDegrees(AdjacencyMatrix adjacencyMatrix)
        {
            int[] degrees = new int[adjacencyMatrix.N];
            for (int i = 0; i < adjacencyMatrix.N; i++)
            {
                int count = 0;
                for (int j = 0; j < adjacencyMatrix.N; j++)
                {
                    if (adjacencyMatrix.Array[i, j] != 0)
                    {
                        count += adjacencyMatrix.Array[i, j];
                        if (i == j) // xet truong hop canh khuyen
                        {
                            count += adjacencyMatrix.Array[i, i];
                        }
                    }
                }

                degrees[i] = count;
            }
            return degrees;
        }

        public static bool IsUndirectedGraph(AdjacencyMatrix adjacencyMatrix)
        {
            var isSymmetric = true;

            for (int i = 0; i < adjacencyMatrix.N; i++)
            {
                for (int j = 0; j < adjacencyMatrix.N; j++)
                {
                    if (adjacencyMatrix.Array[i, j] != adjacencyMatrix.Array[j, i])
                        return false;
                }
            }

            return isSymmetric;
        }
        #endregion

        static int[] path;

        static bool isSafe(int v, AdjacencyMatrix graph, int[] path, int pos)
        {
            if (graph.Array[path[pos - 1], v] == 0)
                return false;

            for (int i = 0; i < pos; i++)
                if (path[i] == v)
                    return false;

            return true;
        }

        static bool HamiltonianCylceTraverse(AdjacencyMatrix adjacencyMatrix, int[] path, int pos)
        {
            if (pos == adjacencyMatrix.N)
            {
                if (adjacencyMatrix.Array[path[pos - 1], path[0]] == 1)
                    return true;

                return false;
            }

            for (int v = 1; v < adjacencyMatrix.N; v++)
            {
                if (isSafe(v, adjacencyMatrix, path, pos))
                {
                    path[pos] = v;

                    if (HamiltonianCylceTraverse(adjacencyMatrix, path, pos + 1) == true)
                        return true;

                    path[pos] = -1;
                }
            }

            return false;
        }

        private static void printSolution(int[] path, int v)
        {
            Console.WriteLine("Solution Exists: Following" +
                            " is one Hamiltonian Cycle");
            for (int i = 0; i < v; i++)
                Console.Write(" " + path[i] + " ");

            Console.WriteLine(" " + path[0] + " ");
        }
    }
}
