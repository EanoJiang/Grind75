#include <stdio.h>

#define MAXN 10000

int h[MAXN], nextHeight[MAXN], stack[MAXN];

int main() {
    int n, top = -1;
    //输入地块数量
    scanf("%d", &n);
    //输入每个地块的高度
    for(int i = 0; i < n; i++) scanf("%d", &h[i]);

    for(int i = n - 1; i >= 0; i--) {
        // 弹出所有不大于当前地块高度的栈元素，直到找到大于当前地块高度的栈元素
        while(top >= 0 && h[stack[top]] <= h[i]) top--;
        //找不到，就返回-1
        if(top == -1) nextHeight[i] = -1;
        //找到了，就返回该元素
        else nextHeight[i] = h[stack[top]];
        //当前地块的下标入栈
        top++;
        stack[top] = i;
    }
    //输出每个地块的下一个高度
    for(int i = 0; i < n; i++) printf("%d ", nextHeight[i]);
    printf("\n");
    return 0;
}