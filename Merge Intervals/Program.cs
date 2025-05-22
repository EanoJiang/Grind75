public class Solution
{
    public int[][] Merge(int[][] intervals)
    {
        List<int[]> result = new List<int[]>();
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        int[] current = intervals[0];
        foreach (int[] next in intervals)
        {
            //大于等于都要合并
            if (current[1] >= next[0])
            {
                current[1] = Math.Max(current[1], next[1]);
            }
            else
            {
                //没有交集就直接添加进result，并将current更新到下一个interval
                result.Add(current);
                current = next;
            }
        }
        //最后一个加进来
        result.Add(current);
        
        return result.ToArray();
    }
}
