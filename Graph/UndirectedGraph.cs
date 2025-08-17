namespace Graph;

public static class UndirectedGraph
{
    private static readonly char[,] Edges = new char[,]
    {
        {'i','j'},
        {'k','i'},
        {'k','j'}, // cycle here
        {'m','k'},
        {'k','l'},
        {'o','n'}
    };
    
    
    
    public static readonly Dictionary<char,List<char>> Graph = BuildGraph();


    /// <summary>
    /// This function creates adjacency list representation of the graph
    /// from the given edges.
    /// Each character represents a node, and the list contains its neighbors.
    /// </summary>
    /// <returns></returns>
    public static Dictionary<char, List<char>> BuildGraph()
    {
        var graph = new Dictionary<char, List<char>>();

        int edgeCount = Edges.GetLength(0);
        for (int i = 0; i < edgeCount; i++)
        {
            char a = Edges[i, 0];
            char b = Edges[i, 1];

            if (!graph.ContainsKey(a))
                graph[a] = new List<char>();
            if (!graph.ContainsKey(b))
                graph[b] = new List<char>();

            graph[a].Add(b);
            graph[b].Add(a); // undirected: add both ways
        }

        return graph;
    }

    public static bool HasPathDepthFirstRecursively(char source, char destination,
        HashSet<char> visitedPath)
    {
        if (source == destination)
        {
            return true;
        }

        if (visitedPath.Contains(source))
        {
            return false;
        }

        visitedPath.Add(source);


        foreach (var node in Graph[source])
        {
            var hasPath = HasPathDepthFirstRecursively(node, destination, visitedPath);
            if (hasPath)
            {
                return true;
            }
        }

        return false;
    }


    public static bool HasPathDepthFirstIteratively(char source, char destination)
    {
        var visited = new HashSet<char>();
        
        var stack = new Stack<char>();
        stack.Push(source);


        while (stack.Count > 0)
        {
            var node = stack.Pop();
            
            if (visited.Contains(node))
            {
                continue;
            }

            if (node == destination)
            {
                return true;
            }
            
            visited.Add(node);
            
            foreach (var neighbor in Graph[node])
            {
                stack.Push(neighbor);
            }
        }
        
        return false;
    }

    public static bool HasPathBreadthFirstIteratively(char source, char destination)
    {
        var visited = new HashSet<char>();
        
        var queue = new Queue<char>();
        queue.Enqueue(source);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            if (visited.Contains(node))
            {
                continue;
            }

            if (node == destination )
            {
                return true;
            }
            
            visited.Add(node);

            foreach (var neighbor in Graph[node])
            {
                queue.Enqueue(neighbor);
            }
        }

        return false;
    }
}