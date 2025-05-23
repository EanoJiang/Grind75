// public class Solution
// {
//     public bool IsPalindrome(string s)
//     {
//         if (s.Length < 2 || s == null) return true;
//         s = s.ToLower();
//         int left = 0, right = s.Length - 1;
//         while (left < right)
//         {
//             if (!char.IsLetterOrDigit(s[left]))
//             {
//                 left++;
//                 continue;
//             }
//             if (!char.IsLetterOrDigit(s[right]))
//             {
//                 right--;
//                 continue;
//             }
//             if (s[left] != s[right]) return false;
//             left++;
//             right--;
//         }
//         return true;
//     }
// }

// public class Solution
// {
//     public bool IsPalindrome(string s)
//     {
//         if (s.Length < 2 || s == null) return true;
//         s = s.ToLower();
//         int left = 0, right = s.Length - 1;
//         while (left < right)
//         {
//             if (!isAlgo(s[left]))
//             {
//                 left++;
//                 continue;
//             }
//             if (!isAlgo(s[right]))
//             {
//                 right--;
//                 continue;
//             }
//             if (s[left] != s[right]) return false;
//             left++;
//             right--;
//         }
//         return true;
//     }
//     public bool isAlgo(char c)
//     {
//         return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9');
//     }
// }

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