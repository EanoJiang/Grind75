static int FindNextBigger(int N)
{
    char[] arr = N.ToString().ToCharArray();
    //从后往前找到第一个升序对的第一个数
    int i = arr.Length - 2;
    while (i >= 0 && arr[i] >= arr[i + 1]) i--;
    if (i < 0) return -1;

    int j = arr.Length - 1;
    //从后往前找到第一个比arr[i]大的数
    while (arr[j] <= arr[i]) j--;

    Swap(arr, i, j);
    //找到i，i之后的数就是降序排列的，所以需要反转
    Array.Reverse(arr, i + 1, arr.Length - i - 1);

    int next = int.Parse(new string(arr));
    return next;
}

static void Swap(char[] arr, int i, int j)
{
    char t = arr[i];
    arr[i] = arr[j];
    arr[j] = t;
}