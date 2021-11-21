using Models;

namespace EulerHamiltonPath.Handlers
{
    public static class GraphBiz
    {
        public static  bool IsEulerPath(AdjacencyMatrix adjacencyMatrix)
        {
            return false;
        }

        public static bool IsHamiltonPath(AdjacencyMatrix adjacencyMatrix)
        {
            return false;
        }

        public static bool IsConnectedGraph(AdjacencyMatrix adjacencyMatrix)
        {
            return true;
        }

        private static void DFS(int v, bool[] visited, AdjacencyMatrix adjacencyMatrix)
        {
            
        }
    }
}
