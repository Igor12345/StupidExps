using MinimumHeightTrees;

namespace MinimumHeightTreesTests
{
    public class GraphProcessorTests
    {
        [Fact]
        public void Test1()
        {
            int[][] edges = new[]
            {
                new[] { 1, 0 },
                new[] { 1, 2 },
                new[] { 1, 3 }
            };
            GraphStructure graph = GraphStructure.CreateFrom(4, edges);

            GraphProcessor graphProcessor = new GraphProcessor(graph);

            var roots = graphProcessor.FindRoots();
            

            Assert.Single(roots);
            Assert.Equal(1, roots[0]);
        }
        
        [Fact]
        public void Test2()
        {
            int[][] edges = new[]
            {
                new[] { 3, 0 },
                new[] { 3, 1 },
                new[] { 3, 2 },
                new[] { 3, 4 },
                new[] { 5, 4 }
            };
            GraphStructure graph = GraphStructure.CreateFrom(6, edges);

            GraphProcessor graphProcessor = new GraphProcessor(graph);

            var roots = graphProcessor.FindRoots();

            Assert.Equal(2, roots.Count);
            
            Assert.Contains(3, roots);
            Assert.Contains(4, roots);
        }
        
        [Fact]
        public void Test3()
        {
            int[][] edges = Array.Empty<int[]>();
            GraphStructure graph = GraphStructure.CreateFrom(1, edges);

            GraphProcessor graphProcessor = new GraphProcessor(graph);

            var roots = graphProcessor.FindRoots();

            Assert.Single(roots);
            Assert.Equal(0, roots[0]);
        }
    }
}