namespace MinimumHeightTrees
{
    public class GraphStructure
    {
        private GraphStructure()
        {
        }

        public static GraphStructure CreateFrom(int nodes, int[][] edges)
        {
            GraphStructure graph = new GraphStructure()
                { NodesNumber = nodes, AdjacencyList = BuildAdjacencyList(edges) };
            return graph;
        }

        private static Dictionary<int, HashSet<int>> BuildAdjacencyList(int[][] edges)
        {
            Dictionary<int, HashSet<int>> result = new Dictionary<int, HashSet<int>>();
            foreach (int[] edge in edges)
            {
                AddEdge(result, edge);
            }

            return result;
        }

        private static void AddEdge(Dictionary<int, HashSet<int>> adjacencyList, int[] edge)
        {
            foreach (int i in edge)
            {
                if (!adjacencyList.ContainsKey(edge[i]))
                {
                    adjacencyList.Add(edge[i], new HashSet<int>());
                }
            }
            adjacencyList[edge[0]].Add(edge[1]);
            adjacencyList[edge[1]].Add(edge[0]);
        }

        private int NodesNumber { get; init; }
        public Dictionary<int, HashSet<int>> AdjacencyList { get; init; }
    };
}
