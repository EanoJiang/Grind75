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