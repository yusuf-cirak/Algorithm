namespace Graph;

public static class DepthFirstTraversal
{
    private static readonly Dictionary<char, List<char>> Graph = new()
    {
        ['a'] = ['b', 'c'],
        ['b'] = ['d'],
        ['c'] = ['e'],
        ['d'] = ['f'],
        ['e'] = [],
        ['f'] = []
    };


    public static void PrintRecursivelyByStack(char sourceNode)
    {
        Console.WriteLine(sourceNode);

        foreach (var neighbor in Graph[sourceNode])
        {
            PrintRecursivelyByStack(neighbor);
        }
    }

    public static void PrintIterativelyByStack(char rootNode)
    {
        var stack = new Stack<char>();
        stack.Push(rootNode);

        while (stack.Count > 0)
        {
            var node = stack.Pop();
            Console.WriteLine(node);

            foreach (var neighbor in Graph[node])
            {
                stack.Push(neighbor);
            }
        }
    }

// Checks if there is a path from 'source' to 'destination' using recursive DFS.
    public static bool HasPathRecursively(char source, char destination)
    {
        // If the current node is the destination, a path exists.
        if (source == destination)
        {
            return true;
        }
    
        // Recursively check all neighbors of the current node.
        foreach (var neighbor in Graph[source])
        {
            // If any neighbor leads to the destination, return true.
            if (HasPathRecursively(neighbor, destination))
            {
                return true;
            }
        }
    
        // If none of the paths lead to the destination, return false.
        return false;
    }

// Checks if there is a path from 'source' to 'destination' using iterative DFS (with a stack).
    public static bool HasPathIteratively(char source, char destination)
    {
        // DFS uses a stack to keep track of nodes to visit.
        var stack = new Stack<char>();

        // Start from the source node.
        stack.Push(source);
    
        // Continue until there are no more nodes to process.
        while (stack.Count > 0)
        {
            // Get the next node from the stack.
            var node = stack.Pop();

            // If this node is the destination, a path exists.
            if (node == destination)
            {
                return true;
            }
        
            // Add all neighbors of the current node to the stack.
            foreach (var c in Graph[node])
            {
                stack.Push(c);
            }
        }

        // If the stack is empty and destination wasn't found, return false.
        return false;
    }
}