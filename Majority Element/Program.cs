// //1.
// public class Solution {
//     public int MajorityElement(int[] nums) {
//         Dictionary<int,int> frequencyMap = new Dictionary<int, int>();
//         int maxFrequency = 0;
//         int result = nums[0];
//         foreach(int num in nums){
//             if(frequencyMap.ContainsKey(num)) frequencyMap[num]++;
//             else frequencyMap[num] =1;
//             if(maxFrequency < frequencyMap[num]){
//                 maxFrequency = frequencyMap[num];
//                 result = num;
//             }
//         }
//         if(maxFrequency > nums.Length/2)return result;
//         return -1;
//     }
// }


// //2.
// public class Solution {
//     public int MajorityElement(int[] nums) {
//         Array.Sort(nums);
//         return nums[nums.Length / 2];
//     }
// }

// //3.
// public class Solution {
//     public int MajorityElement(int[] nums) {
//         int count = 0;
//         int candidate = 0;
//         foreach(int num in nums){
//             if(count == 0)candidate = num;
//             count += (num == candidate)? 1 : -1;
//         }
//         return candidate;
//     }
// }