namespace Graph;

public static class IslandCount
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

    public static int GetIslandCount()
    {
        var visited = new HashSet<string>();
        
        var rowLength = Grid.GetLength(0);
        var colLength = Grid.GetLength(1);
        var islandCount = 0;

        for (int i = 0; i < rowLength; i++)
        {
            for (int j = 0; j < colLength; j++)
            {
                var hasExplored = ExploreIsland(i, j, visited);

                if (hasExplored)
                {
                    islandCount++;
                }
            }
        }

        return islandCount;
    }

    public static bool ExploreIsland(int row, int col, HashSet<string> visited)
    {
        var rowLength = Grid.GetLength(0);
        var colLength = Grid.GetLength(1);
        
        // check boundaries before accessing items
        var rowInBounds = row >= 0 && row < rowLength;
        var colInBounds = col >= 0 && col < colLength;
        if (!rowInBounds || !colInBounds)
        {
            return false;
        }
        
        var item = Grid[row, col];
        
        if (item == 'W')
        {
            // its water, not land
            return false;
        }
        
        var position = $"{row},{col}";
        if (visited.Contains(position))
        {
            return false;
        }
        
        visited.Add(position);
        
        // recursively explore neighbors (up, down, left, right)
        ExploreIsland(row - 1, col, visited); // up
        ExploreIsland(row + 1, col, visited); // down
        ExploreIsland(row, col - 1, visited); // left
        ExploreIsland(row, col + 1, visited); // right
        
        return true;
    }
}