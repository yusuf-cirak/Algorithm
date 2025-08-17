namespace Dijkstra;

public sealed class Node
{
    public string Name { get; set; }
    public Dictionary<Node, int> Edges { get; set; } = new();

    public Node(string name)
    {
        Name = name;
    }
    
    public Node(string name, Dictionary<Node,int> edges)
    {
        Name = name;
        Edges = edges;
    }
    
    public Node AddEdgeToNode(Node node, int distance)
    {
        Edges.Add(node, distance);
        return this;
    }

    public override string ToString() => $"Node: {Name}, Edges: {Edges?.Count}";
}