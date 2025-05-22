// //冒泡
// public class Solution {
//     public void SortColors(int[] nums) {
//         for(int n = 0; n<nums.Length;n++){
//             for(int i = 0;i<nums.Length -1;i++){
//                 if(nums[i] > nums[i+1]){
//                     int tmp = nums[i];
//                     nums[i] = nums[i+1];
//                     nums[i+1] = tmp;
//                 }
//             }
//         }
//     }
// }

// 快排
// 简单选择
// 希尔
// 折半

// //计数排序 
// public class Solution {
//     public void SortColors(int[] nums) {
//         int count0 = 0,count1 = 0, count2 = 0;
//         for(int i = 0; i < nums.Length; i++){
//             switch(nums[i]){
//                 case 0:
//                     count0++;
//                     break;
//                 case 1:
//                     count1++;
//                     break;
//                 case 2:
//                     count2++;
//                     break;
//             }
//         }
//         for(int i = 0; i < nums.Length; i++){
//             if(i<count0) nums[i] = 0;
//             else if(i < count0 + count1)nums[i] = 1;
//             else nums[i] = 2;
//         }
//     }
// }


//1不变0左移2右移
public class Solution
{
    public void SortColors(int[] nums)
    {
        int left = 0, right = nums.Length - 1;
        for (int i = left; i <= right; i++)
        {
            if (nums[i] == 0 && i > left)
            {
                //每次交换时的墙处元素需要被再次判断
                Swap(nums, i--, left++);    //每次交换后左墙右移一位
            }
            else if (nums[i] == 2 && i < right)
            {
                Swap(nums, i--, right--);   //每次交换后右墙左移一位
            }
        }

    }
    public void Swap(int[] nums, int i, int j)
    {
        nums[i] = nums[i] + nums[j];
        nums[j] = nums[i] - nums[j];
        nums[i] = nums[i] - nums[j];
    }
}