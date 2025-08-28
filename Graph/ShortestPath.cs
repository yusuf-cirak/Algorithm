namespace Graph;

public static class ShortestPath
{
    private static readonly Dictionary<char, List<char>> Graph = new()
    {
        { 'w', ['x', 'v'] },
        { 'x', ['y'] },
        { 'y', ['z'] },
        { 'v', ['z'] },
    };


    #region Depth First Search

    public static int FindShortestPathDFSRecursively(char source, char destination)
    {
        var visited = new HashSet<char>();
        var distance = 0;
        return FindShortestPathDFSRecursively(source, destination, distance, visited);
    }

    private static int FindShortestPathDFSRecursively(char source, char destination, int distance, HashSet<char> visited)
    {
        if (source == destination)
        {
            return distance;
        }

        visited.Add(source);
        
        var minDistance = int.MaxValue;
        
        foreach (var neighbor in Graph[source])
        {
            if (visited.Contains(neighbor))
            {
                continue;
            }

            var newVisited = new HashSet<char>(visited);
            
            var newDistance = FindShortestPathDFSRecursively(neighbor, destination, distance+1, newVisited);

            if (newDistance < minDistance)
            {
                minDistance = newDistance;
            }
        }

        return minDistance;
    }

    public static int FindShortestPathDFSIteratively(char source, char destination)
    {
        var minDistance = int.MaxValue;
        var stack = new Stack<(char node, int distance, HashSet<char> visited)>();
        stack.Push((source, 0, new HashSet<char> { source }));

        while (stack.Count > 0)
        {
            var (node, distance, visited) = stack.Pop();

            if (node == destination)
            {
                if (distance < minDistance)
                    minDistance = distance;
                continue;
            }

            foreach (var neighbor in Graph[node])
            {
                if (!visited.Contains(neighbor))
                {
                    var newVisited = new HashSet<char>(visited) { neighbor };
                    stack.Push((neighbor, distance + 1, newVisited));
                }
            }
        }

        return minDistance == int.MaxValue ? -1 : minDistance;
    }

    #endregion


    #region Breadth First Search
    
    public static int FindShortestPathBFSIteratively(char source, char destination)
    {
        var visited = new HashSet<char>();
        
        var queue = new Queue<(char node, int distance)>();
        queue.Enqueue((source, 0));
        
        
        var minDistance = int.MaxValue;

        while (queue.Count > 0)
        {
            var (current,distance) = queue.Dequeue();
            
            if (current == destination)
            {
                minDistance = Math.Min(minDistance, distance);
                continue;
            }

            visited.Add(current);

            foreach (var neighbor in Graph[current])
            {
                if (visited.Contains(neighbor))
                {
                    continue;
                }
                
                queue.Enqueue((neighbor, distance + 1));
            }
        }
        
        return minDistance == int.MaxValue ? -1 : minDistance;
    }

    #endregion
}