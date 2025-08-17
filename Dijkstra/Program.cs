// The shortest path with Dijkstra's algorithm

using Dijkstra;

// Create nodes without edges
var nodes = new Dictionary<string, Node>
{
    ["A"] = new Node("A"),
    ["B"] = new Node("B"),
    ["C"] = new Node("C"),
    ["D"] = new Node("D"),
    ["E"] = new Node("E"),
    ["F"] = new Node("F"),
};

nodes["A"].AddEdgeToNode(nodes["B"], 2).AddEdgeToNode(nodes["D"], 8);
nodes["B"].AddEdgeToNode(nodes["A"], 1).AddEdgeToNode(nodes["D"], 5).AddEdgeToNode(nodes["E"], 6);
nodes["C"].AddEdgeToNode(nodes["E"], 9).AddEdgeToNode(nodes["F"], 3);
nodes["D"].AddEdgeToNode(nodes["A"], 8).AddEdgeToNode(nodes["B"], 5).AddEdgeToNode(nodes["E"], 3)
    .AddEdgeToNode(nodes["F"], 2);
nodes["E"].AddEdgeToNode(nodes["B"], 6).AddEdgeToNode(nodes["D"], 3).AddEdgeToNode(nodes["F"], 1)
    .AddEdgeToNode(nodes["C"], 9);
nodes["F"].AddEdgeToNode(nodes["C"], 3).AddEdgeToNode(nodes["D"], 2).AddEdgeToNode(nodes["E"], 1);

// Find the shortest path from A to C
var finalNode = nodes["C"];

var distances = nodes.ToDictionary(kvp => kvp.Value, _ => (int?)int.MaxValue);

var parents = new Dictionary<Node, Node>();

var undiscoveredNodes = new HashSet<Node>(nodes.Values);

distances[nodes["A"]] = 0;

while (undiscoveredNodes.Count > 0)
{
    var current = undiscoveredNodes.MinBy(node => distances[node]);
    undiscoveredNodes.Remove(current);

    if (current == finalNode)
    {
        break;
    }

    foreach (var (neighborNode, distance) in current.Edges)
    {
        // distances[current] == How much distance took to get to the current node. It will be setted to 0 for the first node.
        // distance == How much distance took to get to the neighbor node from the current node.
        var totalDistance = distances[current] + distance;

        // Check if the distance to the neighbor node is less than the distance that we already have.
        if (totalDistance < distances[neighborNode])
        {
            // If it is, then we update the distance and set the current node as the parent of the neighbor node.
            distances[neighborNode] = totalDistance;
            parents[neighborNode] = current;
            // After this, we will be learning the total distance took to get to the neighbor node from the current node with shortest path.
            // We also learn the parent of the neighbor node.
        }
    }
}

// After the iteration, we will have the shortest path to the final node in distances[finalNode].

// Traversing the path
var pathNodes = new List<Node>();
var currentNode = finalNode;

// We wish to write the path from the first node to the final node with its names.
// Start from end, and go to the start by using the stack data structure. Last in, first out.
while (currentNode is not null)
{
    // Add to the beginning of the list to reverse the order, apply LIFO.
    pathNodes.Insert(0,currentNode);
    currentNode = parents.TryGetValue(currentNode,out var parentNode) ? parentNode : null;
}

Console.WriteLine(string.Join(" -> ", pathNodes.Select(node => node.Name)));
Console.WriteLine($"Total Distance: {distances[finalNode]}");
Console.ReadLine();