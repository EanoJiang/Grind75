using System;

class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

class Program
{
    static ListNode SwapPairs(ListNode head)
    {
        if (head == null || head.next == null) return head;
        
        ListNode newHead = head.next;
        ListNode prev = null;//第一对节点的第一个节点的前驱
        ListNode first = head;

        while (first != null && first.next != null)
        {
            ListNode second = first.next;
            ListNode third = second.next;
            // 交换
            second.next = first; // 第二个节点指向第一个节点
            first.next = third;  // 第一个节点指向下一对的第一个节点
            // 如果当前的节点不是第一对节点的第一个节点
            if (prev != null)
            {
                prev.next = second;
            }
            
            prev = first;
            first = third;
        }
        return newHead;
    }

    static void Main(string[] args)
    {
        // 读入链表
        string line = Console.ReadLine();
        string[] arr = line.Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries);
        ListNode head = null, tail = null;
        foreach (string s in arr)
        {
            if (s == "-1") break;
            ListNode node = new ListNode(int.Parse(s));
            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.next = node;
                tail = node;
            }
        }

        // 交换
        head = SwapPairs(head);

        // 输出
        while (head != null)
        {
            Console.Write(head.val);
            if (head.next != null) Console.Write(" ");
            head = head.next;
        }
        Console.WriteLine();
    }
}