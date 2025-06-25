namespace test1;

//1 2 1
//2 2 1
//1 1 -1
class Program
{
    static void Main(string[] args)
    {
        int[,] matrix = {
            {1 ,2 ,1},
            {2,2,1},
            {1,1,-1}
        };
        var regions = GetRegionPoint(matrix);
        PrintRegionPoints(regions);
        //修改
        matrix[2, 2] = 0;
        var newRegions = GetRegionPoint(matrix);
        Console.WriteLine("******修改*******");
        PrintRegionPoints(newRegions);    
    }

    static List<(int value, List<(int, int)> points)> GetRegionPoint(int[,] matrix)
    {
        List<(int value, List<(int, int)> points)> regions = new List<(int, List<(int, int)>)>();
        int row = matrix.GetLength(0);
        int col = matrix.GetLength(1);
        bool[,] isVisited = new bool[row, col];
        //行移动
        int[] dirR = { -1, 0, 1, 0 };
        //列移动
        int[] dirC = { 0, 1, 0, -1 };

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (isVisited[i, j] || matrix[i, j] == 0 || matrix[i, j] == -1) continue;
                int val = matrix[i, j];
                List<(int row, int col)> points = new List<(int row, int col)>();
                DFS(matrix, isVisited, i, j, val, points, dirR, dirC);

                if (points.Count >= 2)
                {
                    regions.Add((val, points));
                }
            }
        }
        return regions;
    }

    static void DFS(int[,] matrix, bool[,] isVisited,
     int row, int col, int target,
     List<(int row, int col)> points, int[] dirR, int[] dirC)
    {
        isVisited[row, col] = true;
        points.Add((row, col));

        for (int dir = 0; dir < 4; dir++)
        {
            int newRow = row + dirR[dir];
            int newCol = col + dirC[dir];

            if (newRow >= 0 && newRow < matrix.GetLength(0)
            &&newCol >= 0&& newCol < matrix.GetLength(1)
            && !isVisited[newRow, newCol] && matrix[newRow, newCol] == target
            &&  matrix[newRow, newCol] != -1
            )
            {
                DFS(matrix, isVisited, newRow, newCol, target, points, dirR, dirC);
            }

        }
    }

    static void PrintRegionPoints(List<(int value, List<(int, int)> points)> regions)
    {
        int idx = 1;
        foreach (var region in regions)
        {
            Console.WriteLine($"区域{idx}，值={region.value}，点数={region.points.Count}");
            foreach (var point in region.points)
            {
                Console.WriteLine($"{point.Item1},{point.Item2}");
            }
            idx++;
        }
    }
}
