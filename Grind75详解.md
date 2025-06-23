# Day1

## 001 ToSum

```csharp
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
```

```csharp
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
```

```csharp
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

```

## 002 Best Time to Buy and Sell Stock

```csharp
    //O(n2) TLE
    public int MaxProfit(int[] prices)
    {
       int maxProfit = 0;
       for (int i = 0; i < prices.Length; i++)
       {
           for (int j = i + 1; j < prices.Length; j++)
           {
               maxProfit = Math.Max(prices[j] - prices[i], maxProfit);
           }
       }
       return maxProfit;
    }
```

```csharp
    //O(n)
    public int MaxProfit(int[] prices)
    {
       if (prices == null || prices.Length == 0) return 0;
       int min = int.MaxValue, maxProfit = 0;
       foreach (int price in prices)
       {
           min = Math.Min(price, min);
           if (price > min)
               maxProfit = Math.Max(maxProfit, price - min);
       }
       return maxProfit;
    }
```

通解：状态机

```csharp
    //O(n)这是解决买卖股票问题的通用解法——状态机
    public int MaxProfit(int[] prices)
    {
        int n = prices.Length;
        int[][] dp = new int[n][];
        for(int i = 0; i < n; i++)
        {
            dp[i] = new int[2];
        }

        //初始化
        dp[0][0] = 0;
        dp[0][1] = -prices[0];

        for(int i = 1; i < n; i++)
        {
            //第i天没股票 = max(前一天没股票，前一天有股票+今天卖掉了)
            dp[i][0] = Math.Max(dp[i - 1][0], dp[i - 1][1] + prices[i]);
            //第i天有股票 = max(前一天有股票，前一天没股票-今天买了)
            dp[i][1] = Math.Max(dp[i - 1][1], 0 - prices[i]);
            //因为总的交易次数是1，也就是只能买一次+卖一次，并且必须先买了才能卖，所以前一天没股票就一定是初始状态=0
        }
        return dp[n - 1][0];
    }
```

## 003 Insert Intertval

```csharp
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
```

# Day2

## 004 [3Sum](https://leetcode.com/problems/3sum/)

三指针法

```
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
```

## 005 Product of Array Except Self

前缀和->前缀积、后缀积

思路：左扫一遍右扫一遍

![1747795868728](https://img2023.cnblogs.com/blog/3614909/202505/3614909-20250522132947972-1918328697.png)

```csharp
//O(n)
public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int[] left = new int[nums.Length];
        int[] right = new int[nums.Length];
        //init
        left[0] = 1;
        right[nums.Length - 1] = 1;
        //left
        for(int i = 1; i < nums.Length; i++){
            left[i] = left[i-1] * nums[i-1];
        }
        //right
        for(int i = nums.Length - 2; i >= 0; i--){
            right[i] = right[i+1] * nums[i+1];
        }
        //left * right
        for(int i = 0; i < nums.Length; i++){
            left[i] *= right[i];
        }
        return left;
    }
}
```

```csharp
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
```

# Day3

## 006[ Combination Sum](https://leetcode.com/problems/combination-sum/)

前置知识：DFS

DFS中的回溯模板

![1747880187433](https://img2023.cnblogs.com/blog/3614909/202505/3614909-20250522132948889-2069437404.png)

```csharp
public class Solution {
    int[] candidates;
    int target;
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        this.candidates = candidates;
        this.target = target;
        List<IList<int>> result = new List<IList<int>>();
        DFS(result,new List<int>(),0,0);
        return result;
    }
    public void DFS(List<IList<int>> result,List<int> list,int sum,int start){
        if(sum > target)return;
        if(sum == target){
            result.Add(new List<int>(list));
            return;
        }
        //sum<target
        for(int i = start; i < candidates.Length; i++){
            list.Add(candidates[i]);
            DFS(result,list,sum+candidates[i],i);
            list.RemoveAt(list.Count - 1);
        }
    }
}
```

> 为什么需要 `list.RemoveAt(list.Count - 1);`？

因为递归结束返回的时候这条分支的sum>=target，需要删除最后一个结点，然后尝试下一个分支

候选数组是 `[2, 3, 6, 7]`，目标值是 `7`。

递归过程示意：

```csharp
path = [2]
sum = 2 → 继续递归添加下一个元素

path = [2, 2]
sum = 4 → 继续递归添加下一个元素

path = [2, 2, 2]
sum = 6 → 继续递归添加下一个元素

path = [2, 2, 2, 2]
sum = 8 → 超过 target (7)，返回并执行：
list.RemoveAt(list.Count - 1); // 移除最后一个 2，path 变为 [2, 2, 2]
```

然后继续尝试下一条分支

```csharp
path = [2, 2, 2, 3]
sum = 9 → 超过 target，再次移除最后一个元素……

最终找到一条合法路径：
path = [2, 2, 3], sum = 7 → 加入结果集
```

## 007 [Merge Intervals](https://leetcode.com/problems/merge-intervals/)

```csharp
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

```

## 008 [Majority Element](https://leetcode.com/problems/majority-element/)

多数元素：出现次数超过n/2的元素

三种方法：

1. 摩尔投票
2. 查字典(自己想的)——这其实找的是众数，只是出现次数最多，不是次数 > n/2
3. 排序——多数元素的出现次数 ≥ n/2 + 1，它至少占据数组中 `n/2 + 1` 个位置，那么返回中间位置的元素就行

```csharp
public class Solution {
    public int MajorityElement(int[] nums) {
        int count = 0;
        int candidate = 0;
        foreach(int num in nums){
            if(count == 0)candidate = num;
            count += (num == candidate)? 1 : -1;
        }
        return candidate;
    }
}
```

```csharp
public class Solution {
    public int MajorityElement(int[] nums) {
        Dictionary<int,int> frequencyMap = new Dictionary<int, int>();
        int maxFrequency = 0;
        int result = nums[0];
        foreach(int num in nums){
            if(frequencyMap.ContainsKey(num)) frequencyMap[num]++;
            else frequencyMap[num] =1;
            if(maxFrequency < frequencyMap[num]){
                maxFrequency = frequencyMap[num];
                result = num;
            }
        }
        return result;
    }
}
```

```csharp
public class Solution {
    public int MajorityElement(int[] nums) {
        Array.Sort(nums);
        return nums[nums.Length / 2];
    }
}
```

## 009 [Sort Colors](https://leetcode.com/problems/sort-colors/)

### 1不变0左移2右移:

```csharp
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
```

> 为什么要 `i--` ？

每次交换时的墙处元素需要被再次判断，用来处理：墙元素与要交换的元素相同，如果不i--，就跳过了墙元素，导致墙元素不能被交换到另一边去

**例子：**

假设原始数组为：

```csharp
int[] nums = {2, 0, 1, 0, 1, 2};
```

当 `i` 指向 `nums[i] == 2`，与 `right` 交换后，新的元素来自 `right` 指针所在位置，可能是任意值。如果不 `i--`，就直接进入下一轮循环，该新值没有被重新判断。

### 计数排序

```csharp
//计数排序 
public class Solution {
    public void SortColors(int[] nums) {
        int count0 = 0,count1 = 0, count2 = 0;
        for(int i = 0; i < nums.Length; i++){
            switch(nums[i]){
                case 0:
                    count0++;
                    break;
                case 1:
                    count1++;
                    break;
                case 2:
                    count2++;
                    break;
            }
        }
        for(int i = 0; i < nums.Length; i++){
            if(i<count0) nums[i] = 0;
            else if(i < count0 + count1)nums[i] = 1;
            else nums[i] = 2;
        }
    }
}
```

### 手搓常见的排序(略笨)

```csharp
//冒泡
public class Solution {
    public void SortColors(int[] nums) {
        for(int n = 0; n<nums.Length;n++){
            for(int i = 0;i<nums.Length -1;i++){
                if(nums[i] > nums[i+1]){
                    int tmp = nums[i];
                    nums[i] = nums[i+1];
                    nums[i+1] = tmp;
                }
            }
        }
    }
}

//快排
//简单选择
//希尔
//折半
```

## 010 [Contains Duplicate](https://leetcode.com/problems/contains-duplicate/)

HashMap

```csharp
public class Solution {
    public bool ContainsDuplicate(int[] nums)
    {
        //map的组成<num值,count>
        Dictionary<int, int> map = new Dictionary<int, int>();
        foreach (int num in nums)
        {
            if (map.ContainsKey(num)) map[num]++;
            else map[num] = 1;//这里直接用索引器赋值就相当于把没见过的key加进去了
        }
        foreach (int num in nums)
        {
            if (map[num] >= 2) return true;
        }
        return false;
    }
}
```

HashSet

```csharp
public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {
        HashSet<int> seen = new HashSet<int>();
        foreach (int num in nums)
        {
            if (seen.Contains(num)) return true;
            seen.Add(num);//要把没见过的加进去
        }
        return false;
    }
}
```

Linq.Distinct

如果去重后的数组和原数组长度不一样，就说明有重复元素

```csharp
public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        if (nums == null || nums.Length == 0) return false;
        return nums.Length != nums.Distinct().Count();
    }
}
```

拓展：[219. Contains Duplicate II](https://leetcode.com/problems/contains-duplicate-ii/)

HashMap

```csharp
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
```

拓展：HashMap从值获取键

只查第一个，返回一个值

```csharp
var key = map.FirstOrDefault(x => x.Value == nums[i]).Key;
```

查找所有，返回一个列表

```csharp
var keys = map.Where(x => x.Value == nums[i]).Select(x => x.Key).ToList();
```

# Day4

## 011 [Container With Most Water](https://leetcode.com/problems/container-with-most-water/)

双指针法

```csharp
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
```

## 012 [Valid Palindrome](https://leetcode.com/problems/valid-palindrome/)

```csharp
public class Solution
{
    public bool IsPalindrome(string s)
    {
        s = s.ToLower();
        int left = 0, right = s.Length - 1;
        while (left < right)
        {
            if (!char.IsLetterOrDigit(s[left]))
            {
                left++;
                continue;
            }
            if (!char.IsLetterOrDigit(s[right]))
            {
                right--;
                continue;
            }
            if (!(s[left] == s[right])) return false;
            left++;
            right--;
        }
        return true;
    }
}
```

char.isLetterOrDigit()换成自写函数

```csharp
public class Solution
{
    public bool IsPalindrome(string s)
    {
        s = s.ToLower();
        int left = 0, right = s.Length - 1;
        while (left < right)
        {
            if (!isAlgo(s[left]))
            {
                left++;
                continue;
            }
            if (!isAlgo(s[right]))
            {
                right--;
                continue;
            }
            if (!(s[left] == s[right])) return false;
            left++;
            right--;
        }
        return true;
    }
    public bool isAlgo(char c)
    {
        return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9');
    }
}
```

正则表达式法

Regex.Replace(s,"[^a-zA-Z0-9]", "")

```csharp
//正则表达式
using System.Text.RegularExpressions;
public class Solution
{
    public bool IsPalindrome(string s)
    {
        if (s.Length < 2 || s == null) return true;
        s = Regex.Replace(s,"[^a-zA-Z0-9]", "").ToLower();
        //这里和双指针是一样的
        for (int i = 0; i < s.Length / 2; i++)
        {
            if (s[i] != s[s.Length - 1 - i]) return false;
        }
        return true;
    }
}
```

## 013 [Valid Anagram](https://leetcode.com/problems/valid-anagram/)

计数数组法

遍历2个字符串的每一个字符，与‘a’作差，让每个字符在计数数组里计数，一个加一个减，然后再遍历一遍，如果有非0的就false，全部都是0才true

```csharp
public class Solution {
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) return false;
        int[] map = new int[26];
        for (int i = 0; i < s.Length; i++)
        {
            map[s[i] - 'a']++;
            map[t[i] - 'a']--;
        }
        foreach (int e in map)
        {
            if (e != 0) return false;
        }
        return true;
    }
}
```

排序法(比较慢)

```csharp
public class Solution {
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) return false;

        char[] sArr = s.ToCharArray();
        char[] tArr = t.ToCharArray();

        Array.Sort(sArr);
        Array.Sort(tArr);

        return new string(sArr) == new string(tArr);
    }
}
```

# Day5

滑动窗口
