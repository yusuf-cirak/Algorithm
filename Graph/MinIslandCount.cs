namespace Graph;

public static class MinIslandCount
{
    // W: Water
    // L: Land
    // the goal is to find the number of islands (connected components of 'L's)
    private static readonly char[,] Grid =
    {
        { 'W', 'L', 'W', 'W', 'W' },
        { 'W', 'L', 'W', 'W', 'W' },
        { 'W', 'W', 'W', 'L', 'W' },
        { 'W', 'W', 'L', 'L', 'W' },
        { 'L', 'W', 'W', 'L', 'L' },
        { 'L', 'L', 'W', 'W', 'W' },
    };

    public static int GetMinIslandCount()
    {
        var visited = new HashSet<string>();
        
        var rowLength = Grid.GetLength(0);
        var colLength = Grid.GetLength(1);
        var minIslandLength = int.MaxValue;

        for (int i = 0; i < rowLength; i++)
        {
            for (int j = 0; j < colLength; j++)
            {
                var length = ExploreIslandCount(i, j, visited);

                if (length > 0 && length < minIslandLength) // only consider non-zero lengths
                {
                    minIslandLength = length;
                }
            }
        }

        return minIslandLength;
    }

    public static int ExploreIslandCount(int row, int col, HashSet<string> visited)
    {
        var rowLength = Grid.GetLength(0);
        var colLength = Grid.GetLength(1);
        
        // check boundaries before accessing items
        var rowInBounds = row >= 0 && row < rowLength;
        var colInBounds = col >= 0 && col < colLength;
        if (!rowInBounds || !colInBounds)
        {
            return 0;
        }
        
        var item = Grid[row, col];
        
        if (item == 'W')
        {
            // its water, not land
            return 0;
        }
        
        var position = $"{row},{col}";
        if (visited.Contains(position))
        {
            return 0;
        }
        
        visited.Add(position);
        
        var count = 1;
        
        // recursively explore neighbors (up, down, left, right)
        count+=ExploreIslandCount(row - 1, col, visited); // up
        count+=ExploreIslandCount(row + 1, col, visited); // down
        count+=ExploreIslandCount(row, col - 1, visited); // left
        count+=ExploreIslandCount(row, col + 1, visited); // right
        
        return count;
    }
}