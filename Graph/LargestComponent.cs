using System.Net.Http.Headers;

namespace Graph;

public static class LargestComponent
{
    private static readonly Dictionary<int, List<int>> Graph = new()
    {
        { 0, [8, 1, 5] },
        { 1, [0] },
        { 5, [0, 8] },
        { 8, [0, 5] },
        { 2, [3, 4] },
        { 3, [2, 4] },
        { 4, [3, 2] },
    };


    #region Depth First Search
    public static int GetLargestComponentDFSRecursively()
    {
        var counts = new Dictionary<int, int>();

        var visited = new HashSet<int>();
        foreach (var node in Graph)
        {
            var size = GetLargestComponentDFSRecursively(node.Key, visited);
            if (size == 0)
            {
                continue;
            }
            
            counts[node.Key] = size;
        }
        
        return counts.Values.Max();
    }

    private static int GetLargestComponentDFSRecursively(int source, HashSet<int> visited)
    {
        if (visited.Contains(source))
        {
            return 0;
        }

        visited.Add(source);

        var size = 1;
        foreach (var neighbor in Graph[source])
        {
            size += GetLargestComponentDFSRecursively(neighbor, visited);
        }

        return size;
    }


    public static int GetLargestComponentDFSIteratively()
    {
        var counts = new Dictionary<int, int>();
        
        var visited = new HashSet<int>();


        foreach (var node in Graph)
        {
            var stack = new Stack<int>();
            stack.Push(node.Key);
            
            var size = 0;

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                if (visited.Contains(current))
                {
                    continue;
                }
                visited.Add(current);
                size++;

                foreach (var neighbor in Graph[current])
                {
                    stack.Push(neighbor);
                }
            }

            if (size == 0)
            {
                continue;
            }
            
            counts[node.Key] = size;
        }
        
        return counts.Values.Max();
    }
    
    #endregion

    #region Breadth First Search

    public static int GetLargestComponentBFSIteravitely()
    {
        var counts = new Dictionary<int, int>();
        var visited = new HashSet<int>();

        foreach (var node in Graph)
        {
            var queue = new Queue<int>();
            queue.Enqueue(node.Key);

            var size = 0;
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (visited.Contains(current))
                {
                    continue;
                }
                
                visited.Add(current);

                size++;
                foreach (var neighbor in Graph[current])
                {
                    queue.Enqueue(neighbor);
                }
            }

            if (size == 0)
            {
                continue;
            }
            
            counts[node.Key] = size;
        }
        
        return counts.Values.Max();
    }

    #endregion
}