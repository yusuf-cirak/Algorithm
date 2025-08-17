namespace Graph;

public static class BreadthFirstTraversal
{
    private static readonly Dictionary<char, List<char>> Graph = new()
    {
        ['a'] = ['c', 'b'],
        ['b'] = ['d'],
        ['c'] = ['e'],
        ['d'] = ['f'],
        ['e'] = [],
        ['f'] = []
    };


    public static void PrintIterativelyByQueue(char sourceNode)
    {
        var queue = new Queue<char>();
        queue.Enqueue(sourceNode);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            Console.WriteLine(current);

            foreach (var neighbor in Graph[current])
            {
                queue.Enqueue(neighbor);
            }
        }
    }


// Checks if there is a path from 'source' to 'destination' using BFS (queue).
    public static bool HasPathIteratively(char source, char destination)
    {
        // Create a queue for BFS.
        var queue = new Queue<char>();
    
        // Start from the source node.
        queue.Enqueue(source);

        // Continue until there are no more nodes to process.
        while (queue.Count > 0)
        {
            // Get the next node from the queue.
            var node = queue.Dequeue();
        
            // If this node is the destination, a path exists.
            if (node == destination)
            {
                return true;
            }
            // Add all neighbors of the current node to the queue.
            foreach (var neighbor in Graph[node])
            {
                queue.Enqueue(neighbor);
            }
        }

        // If the queue is empty and destination wasn't found, return false.
        return false;
    }
}