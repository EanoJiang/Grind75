using System.Collections;

public class Solution
{
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        List<int[]> result = new List<int[]>();
        foreach (int[] current in intervals)
        {
            //无交集
            if(newInterval == null || newInterval[0] > current[1])
            {
                result.Add(current);
            }
            else if (newInterval[1] < current[0])
            {
                result.Add(newInterval);
                newInterval = null;
                result.Add(current);
            }
            //有交集
            else
            {
                //上述情况都不满足，那就需要合并
                newInterval[0] = Math.Min(newInterval[0], current[0]);
                newInterval[1] = Math.Max(newInterval[1], current[1]);
            }
        }
        //手动添加
        if(newInterval != null)
        {
            result.Add(newInterval);
        }
        return result.ToArray();
    }
}