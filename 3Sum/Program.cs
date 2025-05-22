public class Solution
{
    //三指针法
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        IList<IList<int>> result = new List<IList<int>>();
        Array.Sort(nums);
        //三个指针：i，left,right
        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1]) continue;
            int left = i + 1, right = nums.Length - 1;
            while (left < right)
            {
                if (nums[i] + nums[left] + nums[right] == 0)
                {
                    IList<int> res = new List<int>() { nums[i], nums[left], nums[right] };
                    result.Add(res);
                    left++;
                    right--;
                    while (left < right && nums[left] == nums[left - 1]) left++;
                    while (left < right && nums[right] == nums[right + 1]) right--;
                }
                else if (left < right && nums[i] + nums[left] + nums[right] > 0) right--;
                else left++;
            }
        }
        return result;
    }
}