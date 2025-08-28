using Graph;

// BreadthFirstTraversal.PrintIterativelyByQueue('a');

// var hasPath = DepthFirstTraversal.HasPathRecursively('e','a');
// Console.WriteLine($"Has path from 'e' to 'a': {hasPath}");
// var connectedComponentsCountDfsRecursively = ConnectedComponentsCount.GetConnectedComponentsCountDFSRecursively();
// var connectedComponentsCountDfsIteratively = ConnectedComponentsCount.GetConnectedComponentsCountDFSIteratively();
// var connectedComponentsCountBfsIteratively = ConnectedComponentsCount.GetConnectedComponentsCountBFSIteratively();
//
// Console.WriteLine("{0,-35} | {1,10}", "Algorithm", "Count");
// Console.WriteLine(new string('-', 50));
// Console.WriteLine("{0,-35} | {1,10}", "DFS Recursively", connectedComponentsCountDfsRecursively);
// Console.WriteLine("{0,-35} | {1,10}", "DFS Iteratively", connectedComponentsCountDfsIteratively);
// Console.WriteLine("{0,-35} | {1,10}", "BFS Iteratively", connectedComponentsCountBfsIteratively);


// var largestComponentSize = LargestComponent.GetLargestComponentDFSRecursively();
// Console.WriteLine($"\nLargest component size: {largestComponentSize}");
//
// var largestComponentSizeIteratively = LargestComponent.GetLargestComponentDFSIteratively();
// Console.WriteLine($"\nLargest component size: {largestComponentSizeIteratively}");
//
// var largestComponentSizeBfsIteratively = LargestComponent.GetLargestComponentBFSIteravitely();
// Console.WriteLine($"\nLargest component size: {largestComponentSizeBfsIteratively}");


// var shortestPathDfsRecursively = ShortestPath.FindShortestPathDFSRecursively('w', 'z');
// Console.WriteLine($"\nShortest path from 'w' to 'z' (DFS Recursively): {shortestPathDfsRecursively}");
var shortestPathDfsIteratively = ShortestPath.FindShortestPathDFSIteratively('w', 'z');
Console.WriteLine($"\nShortest path from 'w' to 'z' (DFS Iteratively): {shortestPathDfsIteratively}");

var shortestPathBfsIteratively = ShortestPath.FindShortestPathBFSIteratively('w', 'z');
Console.WriteLine($"\nShortest path from 'w' to 'z' (BFS Iteratively): {shortestPathBfsIteratively}");