public class Solution {
    public int MaxArea(int[] height)
    {
        int res = 0, left = 0, right = height.Length - 1;
        while (left < right)
        {
            int minHeight = Math.Min(height[left], height[right]);
            int width = right - left;
            res = Math.Max(res, minHeight * width);
            if (height[left] < height[right]) left++;
            else right--;
        }
        return res;
    }
}