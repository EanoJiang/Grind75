namespace 链表;

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val)
    {
        this.val = val;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ListNode head = new ListNode(0);
        head.next = new ListNode(1);
        head.next.next = new ListNode(2);
        while(head != null){
            Console.WriteLine(head.val);
            head = head.next;
        }
    }
}
