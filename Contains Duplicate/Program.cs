// public class Solution {
//     public bool ContainsDuplicate(int[] nums)
//     {
//         //map的组成<num值,count>
//         Dictionary<int, int> map = new Dictionary<int, int>();
//         foreach (int num in nums)
//         {
//             if (map.ContainsKey(num)) map[num]++;
//             else map[num] = 1;//这里直接用索引器赋值就相当于把没见过的key加进去了
//         }
//         foreach (int num in nums)
//         {
//             if (map[num] >= 2) return true;
//         }
//         return false;
//     }
// }

// public class Solution
// {
//     public bool ContainsDuplicate(int[] nums)
//     {
//         HashSet<int> seen = new HashSet<int>();
//         foreach (int num in nums)
//         {
//             if (seen.Contains(num)) return true;
//             seen.Add(num);//要把没见过的加进去
//         }
//         return false;
//     }
// }


// public class Solution {
//     public bool ContainsDuplicate(int[] nums) {
//         if (nums == null || nums.Length == 0) return false;
//         return nums.Length != nums.Distinct().Count();
//     }
// }

public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        //map：<num值,索引>
        Dictionary<int, int> map = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (map.ContainsKey(nums[i]) &&
            i - map[nums[i]] <= k)
            {
                return true;
            }
            map[nums[i]] = i;  //没见过的值 把对应的索引加进来
        }
        return false;
    }
}