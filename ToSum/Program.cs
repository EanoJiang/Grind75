public class Solution
{
    //O(n2)
    public int[] TwoSum(int[] nums, int target)
    {
       for (int i = 0; i < nums.Length; i++)
       {
           for (int j = i + 1; j < nums.Length; j++)
           {
               if (nums[i] + nums[j] == target)
               {
                   return new int[] { i, j };
               }
           }
       }
       return null;
    }

    //O(nlogn)
    public int[] TwoSum(int[] nums, int target)
    {
       //原数组复制一个
       int[] demmy = new int[nums.Length];
       Array.Copy(nums, demmy, nums.Length);
       //对原数组排序
       Array.Sort(nums);
       int n = nums.Length;
       int left = 0;
       int right = n - 1;
       while (nums[left] + nums[right] != target)
       {
           if (nums[left] + nums[right] > target)
           {
               right--;
           }
           else
           {
               left++;
           }
       }
       int[] result = new int[2];
       for (int i = 0; i < nums.Length; i++)
       {
           if (demmy[i] == nums[left])
           {
               result[0] = i;
           }
       }
       for (int i = nums.Length - 1; i >= 0; i--)
       {
           if (demmy[i] == nums[right])
           {
               result[1] = i;
           }
       }
       return result;
    }

    //O(n)
    public int[] TwoSum(int[] nums, int target)
    {
        //构建哈希表<值，索引>
        Dictionary<int, int> map = new Dictionary<int, int>();
        for(int i = 0; i < nums.Length; i++)
        {
            int diff = target - nums[i];
            //查询过往是否在哈希表有这个值
            if (map.ContainsKey(diff))
            {
                return new int[] { map[diff], i };
            }
            //如果过往没有，
            //并且当前的<值，索引>在哈希表中没被添加过，则加到哈希表中，进行下一次查找
            if (!map.ContainsKey(nums[i]))
            {
                map.Add(nums[i], i);
            }

        }
        return null;
    }

}