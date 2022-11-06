namespace MinimumHeightTrees;

public class Solution
{
    public IList<int> FindMinHeightTrees(int n, int[][] edges)
    {
        GraphStructure graph = GraphStructure.CreateFrom(n, edges);

        GraphProcessor graphProcessor = new GraphProcessor(graph);

        var roots = graphProcessor.FindRoots();
        return roots;
    }
}