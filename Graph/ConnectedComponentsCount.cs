namespace Graph;

public static class ConnectedComponentsCount
{
    public static readonly Dictionary<byte, List<byte>> Graph = new()
    {
        { 3, [] },
        { 4, [6] },
        { 6, [4,5,7,8] },
        { 8, [6] },
        { 7, [6] },
        { 5, [6] },
        { 1, [2] },
        { 2, [1] },
    };


    #region Depth First Search

    // travels through the graph with every element and counts the number of connected components
    public static int GetConnectedComponentsCountDFSRecursively()
    {
        var visited = new HashSet<byte>();
        var count = 0;

        foreach (var node in Graph)
        {
            count+= GetConnectedComponentsCountDFSRecursively(node.Key, visited);
        }
        
        return count;
    }

    // travels through node's neighbors recursively and marks them as visited
    // returns 1 if the node was not visited before, otherwise returns 0
    private static int GetConnectedComponentsCountDFSRecursively(byte node, HashSet<byte> visited)
    {
        if (visited.Contains(node))
        {
            return 0;
        }
        
        visited.Add(node);

        foreach (var neighbor in Graph[node])
        {
            GetConnectedComponentsCountDFSRecursively(neighbor, visited);
        }
        
        return 1;
    }
    
    
    
    
    public static int GetConnectedComponentsCountDFSIteratively()
    {
        var visited = new HashSet<byte>();
        var count = 0;

        foreach (var node in Graph)
        {
            count += GetConnectedComponentsCountDFSIteratively(node.Key, visited);
        }
        
        return count;
    }

    private static int GetConnectedComponentsCountDFSIteratively(byte node, HashSet<byte> visited)
    {
        if (visited.Contains(node))
        {
            return 0;
        }
        
        visited.Add(node);
        
        var stack = new Stack<byte>();
        
        stack.Push(node);

        while (stack.Count > 0)
        {
            var current = stack.Pop();

            foreach (var neighbor in Graph[current])
            {
                GetConnectedComponentsCountDFSIteratively(neighbor, visited);
            }
        }

        return 1;
    }

    #endregion

    #region Breadth First Search

    public static int GetConnectedComponentsCountBFSIteratively()
    {
        var visited = new HashSet<byte>();
        var count = 0;

        foreach (var node in Graph)
        {
            count+= GetConnectedComponentsCountBFSIteratively(node.Key, visited);
        }

        return count;
    }


    private static int GetConnectedComponentsCountBFSIteratively(byte node, HashSet<byte> visited)
    {
        if (visited.Contains(node))
        {
            return 0;
        }

        visited.Add(node);
        
        
        var queue = new Queue<byte>();
        queue.Enqueue(node);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            foreach (var neighbor in Graph[current])
            {
                GetConnectedComponentsCountBFSIteratively(neighbor, visited);
            }
        }
        return 1;
    }

    #endregion
}