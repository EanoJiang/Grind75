using System.Data;

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

// public class Solution {
//     public bool IsAnagram(string s, string t)
//     {
//         if (s.Length != t.Length) return false;

//         char[] sArr = s.ToCharArray();
//         char[] tArr = t.ToCharArray();

//         Array.Sort(sArr);
//         Array.Sort(tArr);

//         return new string(sArr) == new string(tArr);
//     }
// }