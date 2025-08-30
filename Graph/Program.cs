using Graph;

Console.WriteLine("=== Breadth First Traversal ===");
// BreadthFirstTraversal.PrintIterativelyByQueue('a');

Console.WriteLine("\n=== Depth First Traversal Path Check ===");
var hasPath = DepthFirstTraversal.HasPathRecursively('e', 'a');
Console.WriteLine($"Has path from 'e' to 'a': {hasPath}");

Console.WriteLine("\n=== Connected Components Count ===");
var connectedComponentsCountDfsRecursively = ConnectedComponentsCount.GetConnectedComponentsCountDFSRecursively();
var connectedComponentsCountDfsIteratively = ConnectedComponentsCount.GetConnectedComponentsCountDFSIteratively();
var connectedComponentsCountBfsIteratively = ConnectedComponentsCount.GetConnectedComponentsCountBFSIteratively();
Console.WriteLine("{0,-35} | {1,10}", "Algorithm", "Count");
Console.WriteLine(new string('-', 50));
Console.WriteLine("{0,-35} | {1,10}", "DFS Recursively", connectedComponentsCountDfsRecursively);
Console.WriteLine("{0,-35} | {1,10}", "DFS Iteratively", connectedComponentsCountDfsIteratively);
Console.WriteLine("{0,-35} | {1,10}", "BFS Iteratively", connectedComponentsCountBfsIteratively);

Console.WriteLine("\n=== Largest Component Size ===");
var largestComponentSize = LargestComponent.GetLargestComponentDFSRecursively();
Console.WriteLine($"Largest component size (DFS Recursively): {largestComponentSize}");
var largestComponentSizeIteratively = LargestComponent.GetLargestComponentDFSIteratively();
Console.WriteLine($"Largest component size (DFS Iteratively): {largestComponentSizeIteratively}");
var largestComponentSizeBfsIteratively = LargestComponent.GetLargestComponentBFSIteravitely();
Console.WriteLine($"Largest component size (BFS Iteratively): {largestComponentSizeBfsIteratively}");

Console.WriteLine("\n=== Shortest Path ===");
var shortestPathDfsRecursively = ShortestPath.FindShortestPathDFSRecursively('w', 'z');
Console.WriteLine($"Shortest path from 'w' to 'z' (DFS Recursively): {shortestPathDfsRecursively}");
var shortestPathDfsIteratively = ShortestPath.FindShortestPathDFSIteratively('w', 'z');
Console.WriteLine($"Shortest path from 'w' to 'z' (DFS Iteratively): {shortestPathDfsIteratively}");
var shortestPathBfsIteratively = ShortestPath.FindShortestPathBFSIteratively('w', 'z');
Console.WriteLine($"Shortest path from 'w' to 'z' (BFS Iteratively): {shortestPathBfsIteratively}");

Console.WriteLine("\n=== Island Count ===");
var islandCount = IslandCount.GetIslandCount();
Console.WriteLine($"Number of islands: {islandCount}");

Console.WriteLine("\n=== Minimum Island Size ===");
var minIslandCount = MinIslandCount.GetMinIslandCount();
Console.WriteLine($"Minimum island size: {minIslandCount}");