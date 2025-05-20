public class Solution
{
    ////O(n2) TLE
    //public int MaxProfit(int[] prices)
    //{
    //    int maxProfit = 0;
    //    for (int i = 0; i < prices.Length; i++)
    //    {
    //        for (int j = i + 1; j < prices.Length; j++)
    //        {
    //            maxProfit = Math.Max(prices[j] - prices[i], maxProfit);
    //        }
    //    }
    //    return maxProfit;
    //}

    ////O(n)
    //public int MaxProfit(int[] prices)
    //{
    //    if (prices == null || prices.Length == 0) return 0;
    //    int min = int.MaxValue, maxProfit = 0;
    //    foreach (int price in prices)
    //    {
    //        min = Math.Min(price, min);
    //        if (price > min)
    //            maxProfit = Math.Max(maxProfit, price - min);
    //    }
    //    return maxProfit;
    //}

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


}

