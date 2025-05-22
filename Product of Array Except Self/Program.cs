//O(n2) TLE
// public class Solution {
//     public int[] ProductExceptSelf(int[] nums) {
//         List<int> result = new List<int>();
//         for(int i = 0; i < nums.Length; i++){
//             int temp = 1;
//             for(int j = 0; j < nums.Length; j++){
//                 if(j != i) temp = temp * nums[j] ;
//             }
//             result.Add(temp);
//         }
//         return result.ToArray();
//     }
// }

// //O(n)
// public class Solution {
//     public int[] ProductExceptSelf(int[] nums) {
//         int[] left = new int[nums.Length];
//         int[] right = new int[nums.Length];
//         //init
//         left[0] = 1;
//         right[nums.Length - 1] = 1;
//         //left
//         for(int i = 1; i < nums.Length; i++){
//             left[i] = left[i-1] * nums[i-1];
//         }
//         //right
//         for(int i = nums.Length - 2; i >= 0; i--){
//             right[i] = right[i+1] * nums[i+1];
//         }
//         //left * right
//         for(int i = 0; i < nums.Length; i++){
//             left[i] *= right[i];
//         }
//         return left;
//     }
// }

//sapce：O(1)
public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int[] result = new int[nums.Length];
        for(int i = 0,tmp = 1; i < nums.Length; i++){
            //因为是前缀积，所以先赋值
            result[i] = tmp;
            //下一轮的tmp
            tmp *= nums[i];
        }
        for(int i = nums.Length - 1,tmp = 1; i >= 0; i--){
            result[i] *= tmp;
            tmp *= nums[i];
        }
        return result;
    }
}