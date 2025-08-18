using Graph;

// BreadthFirstTraversal.PrintIterativelyByQueue('a');

var hasPath = DepthFirstTraversal.HasPathRecursively('e','a');
Console.WriteLine($"Has path from 'e' to 'a': {hasPath}");
var connectedComponentsCountDfsRecursively = ConnectedComponentsCount.GetConnectedComponentsCountDFSRecursively();
var connectedComponentsCountDfsIteratively = ConnectedComponentsCount.GetConnectedComponentsCountDFSIteratively();
var connectedComponentsCountBfsIteratively = ConnectedComponentsCount.GetConnectedComponentsCountBFSIteratively();

Console.WriteLine("{0,-35} | {1,10}", "Algorithm", "Count");
Console.WriteLine(new string('-', 50));
Console.WriteLine("{0,-35} | {1,10}", "DFS Recursively", connectedComponentsCountDfsRecursively);
Console.WriteLine("{0,-35} | {1,10}", "DFS Iteratively", connectedComponentsCountDfsIteratively);
Console.WriteLine("{0,-35} | {1,10}", "BFS Iteratively", connectedComponentsCountBfsIteratively);