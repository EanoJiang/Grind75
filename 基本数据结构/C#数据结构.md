# C# 数据结构

## 1. String（字符串）

### 1.1 基本概念

- 字符串是C#中最常用的数据类型之一
- 字符串是不可变的（immutable），每次修改都会创建新的字符串对象
- 字符串是引用类型，但具有值类型的特性

### 1.2 常用操作

#### 1.2.1 字符串创建和连接

```csharp
// 字符串连接
string str1 = "Hello";
string str2 = "World";
string result = str1 + " " + str2;  // 使用 + 运算符
string result2 = string.Concat(str1, " ", str2);  // 使用Concat方法

// 字符串格式化
string formatted = string.Format("姓名：{0}，年龄：{1}", "张三", 25);
string interpolated = $"姓名：{"张三"}，年龄：{25}";  // 字符串插值（C# 6.0+）
```

#### 1.2.2 字符串查找和替换

```csharp
string text = "Hello World";

// 查找
bool contains = text.Contains("World");  // 检查是否包含子串
int index = text.IndexOf("o");  // 查找字符或子串的位置
int lastIndex = text.LastIndexOf("o");  // 从后向前查找

// 替换
string replaced = text.Replace("World", "C#");  // 替换子串
```

#### 1.2.3 字符串分割和合并

```csharp
// 分割
string[] words = "Hello,World,C#".Split(',');  // 按分隔符分割

// 合并
string joined = string.Join("-", words);  // 使用分隔符合并数组
```

#### 1.2.4 字符串修剪和填充

```csharp
string text = "  Hello World  ";

// 修剪
string trimmed = text.Trim();  // 去除首尾空格
string trimmedStart = text.TrimStart();  // 去除开头空格
string trimmedEnd = text.TrimEnd();  // 去除结尾空格

// 填充
string padded = text.PadLeft(20, '*');  // 左侧填充
string paddedRight = text.PadRight(20, '*');  // 右侧填充
```

#### 1.2.5 字符串大小写转换

```csharp
string text = "Hello World";

string upper = text.ToUpper();  // 转换为大写
string lower = text.ToLower();  // 转换为小写
```

#### 1.2.6 字符串比较

```csharp
string str1 = "Hello";
string str2 = "hello";

bool equals = str1.Equals(str2, StringComparison.OrdinalIgnoreCase);  // 忽略大小写比较
int compare = string.Compare(str1, str2, StringComparison.OrdinalIgnoreCase);  // 比较字符串

// Compare方法返回值说明：
// 返回值 < 0：第一个字符串在字典顺序上小于第二个字符串
// 返回值 = 0：两个字符串相等
// 返回值 > 0：第一个字符串在字典顺序上大于第二个字符串

// 具体示例：
int result1 = string.Compare("apple", "banana");  // 返回 -1，因为'a'的ASCII码(97)小于'b'的ASCII码(98)
int result2 = string.Compare("banana", "apple");  // 返回 1，因为'b'的ASCII码(98)大于'a'的ASCII码(97)
int result3 = string.Compare("apple", "apple");   // 返回 0，因为两个字符串完全相同
```

#### 1.2.7 字符串截取

```csharp
string text = "Hello World";

string substring = text.Substring(0, 5);  // 从索引0开始截取5个字符

// 更多示例：
string text2 = "ABCDEFG";
string sub1 = text2.Substring(1, 3);  // 结果: "BCD"  (索引1,2,3)
string sub2 = text2.Substring(2, 2);  // 结果: "CD"   (索引2,3)
string sub3 = text2.Substring(0, 1);  // 结果: "A"    (索引0)
```

#### 1.2.8 字符串格式化

```csharp
// 数字格式化
string number = string.Format("{0:N2}", 1234.5678);  // 输出：1,234.57
string currency = string.Format("{0:C}", 1234.5678);  // 输出：￥1,234.57

// 格式说明符说明：
// {0:N2} - N表示数字格式，2表示保留2位小数，自动添加千位分隔符
// {0:C}  - C表示货币格式，自动添加货币符号，保留2位小数，添加千位分隔符
// {0:D}  - D表示十进制整数格式
// {0:F2} - F表示定点数格式，2表示保留2位小数
// {0:P}  - P表示百分比格式，自动乘以100并添加%符号
// {0:X}  - X表示十六进制格式

// 更多示例：
string num1 = string.Format("{0:N0}", 1234.5678);    // 输出：1,235（无小数）
string num2 = string.Format("{0:F3}", 1234.5678);    // 输出：1234.568（3位小数）
string num3 = string.Format("{0:P}", 0.1234);        // 输出：12.34%
string num4 = string.Format("{0:X}", 255);           // 输出：FF（十六进制）

// 日期格式化
string date = string.Format("{0:yyyy-MM-dd}", DateTime.Now);  // 输出：2024-03-21
```

#### 1.2.9 字符串构建

```csharp
// 使用StringBuilder（适用于频繁修改字符串的场景）
StringBuilder sb = new StringBuilder();
sb.Append("Hello");
sb.Append(" ");
sb.Append("World");
string result = sb.ToString();
```

#### 1.2.10 字符串验证

```csharp
string text = "Hello123";

bool isNullOrEmpty = string.IsNullOrEmpty(text);  // 检查是否为空或null
bool isNullOrWhiteSpace = string.IsNullOrWhiteSpace(text);  // 检查是否为空、null或只包含空白字符
```

### 1.3 性能注意事项

1. 字符串是不可变的，频繁修改会导致性能问题
2. 对于频繁的字符串操作，应使用StringBuilder
3. 字符串比较时要注意使用适当的比较方法
4. 在处理大量字符串操作时，要注意性能影响

### 1.4 最佳实践

1. 使用字符串插值（$"..."）代替string.Format
2. 使用StringBuilder进行大量字符串操作
3. 使用适当的字符串比较方法
4. 注意字符串的不可变性
5. 合理使用字符串池（String Pool）

### 1.5 字符串池（String Pool）详解

字符串池是CLR（Common Language Runtime）中的一个特殊内存区域，用于存储字符串字面量。它的主要目的是优化内存使用。

#### 1.5.1 字符串池的工作原理

```csharp
// 以下代码中，str1和str2实际上指向同一个字符串对象
string str1 = "Hello";
string str2 = "Hello";
bool areSame = ReferenceEquals(str1, str2);  // 返回 true

// 但是通过new创建的字符串不会使用字符串池
string str3 = new string("Hello");
bool areSame2 = ReferenceEquals(str1, str3);  // 返回 false
```

#### 1.5.2 字符串池的优点

1. 节省内存：相同的字符串字面量只存储一次
2. 提高性能：字符串比较可以直接比较引用
3. 减少垃圾回收压力

#### 1.5.3 字符串池的注意事项

1. 只有字符串字面量才会被放入字符串池
2. 运行时创建的字符串（如通过new或字符串操作）不会被放入字符串池
3. 可以使用 `string.Intern()`方法手动将字符串放入字符串池
4. 可以使用 `string.IsInterned()`方法检查字符串是否在字符串池中

```csharp
// 手动将字符串放入字符串池
string str4 = "World";
string str5 = string.Intern("World");
bool areSame3 = ReferenceEquals(str4, str5);  // 返回 true

// 检查字符串是否在字符串池中
string str6 = "Test";
string interned = string.IsInterned(str6);  // 如果在池中，返回池中的引用；否则返回null
```

#### 1.5.4 使用建议

对于频繁使用的字符串字面量，让它们自然进入字符串池

对于动态生成的字符串，如果确定会重复使用，可以考虑使用 `string.Intern()`

不要过度使用 `string.Intern()`，因为字符串池会占用内存直到应用程序结束

在性能关键的场景，可以使用字符串池来优化字符串比较

## 2. 链表（LinkedList）

### 2.1 基本概念

- 链表是一种线性数据结构，由一系列节点组成
- 每个节点包含数据和指向下一个节点的引用
- 链表不需要连续的内存空间
- 适合频繁的插入和删除操作

### 2.2 常见操作

#### 2.2.1 创建链表

```csharp
// 定义链表节点
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val) { this.val = val; }
}

// 创建链表
ListNode head = new ListNode(1);
head.next = new ListNode(2);
head.next.next = new ListNode(3);
```

#### 2.2.2 遍历链表

```csharp
// 方法1：while循环
ListNode current = head;
while (current != null)
{
    Console.WriteLine(current.val);
    current = current.next;
}

// 方法2：for循环
for (ListNode node = head; node != null; node = node.next)
{
    Console.WriteLine(node.val);
}
```

#### 2.2.3 插入节点

```csharp
// 在头部插入
ListNode newHead = new ListNode(0);
newHead.next = head;
head = newHead;

// 在中间插入
ListNode newNode = new ListNode(2);
newNode.next = current.next;
current.next = newNode;

// 在尾部插入
ListNode tail = head;
while (tail.next != null)
{
    tail = tail.next;
}
tail.next = new ListNode(4);
```

#### 2.2.4 删除节点

```csharp
// 删除头节点
head = head.next;

// 删除中间节点：找到delNode的前驱
current.next = current.next.next;

// 删除尾节点：找到尾节点的前驱
ListNode current = head;
while (current.next.next != null)
{
    current = current.next;
}
current.next = null;
```

#### 2.2.5 查找节点

```csharp
// 查找特定值
ListNode FindNode(ListNode head, int target)
{
    ListNode current = head;
    while (current != null)
    {
        if (current.val == target)
            return current;
        current = current.next;
    }
    return null;
}

// 查找中间节点（快慢指针）
ListNode FindMiddle(ListNode head)
{
    ListNode slow = head;
    ListNode fast = head;
    while (fast != null && fast.next != null)
    {
        slow = slow.next;
        fast = fast.next.next;
    }
    return slow;
}
```

#### 2.2.6 反转链表

```csharp
// 迭代方式
ListNode ReverseList(ListNode head)
{
    ListNode prev = null;
    ListNode current = head;
    while (current != null)
    {
        ListNode next = current.next;
        current.next = prev;
        prev = current;
        current = next;
    }
    return prev;
}

// 递归方式
ListNode ReverseListRecursive(ListNode head)
{
    if (head == null || head.next == null)
        return head;
  
    ListNode newHead = ReverseListRecursive(head.next);
    head.next.next = head;
    head.next = null;
    return newHead;
}
```

#### 2.2.7 检测环

```csharp
bool HasCycle(ListNode head)
{
    if (head == null) return false;
  
    ListNode slow = head;
    ListNode fast = head;
  
    while (fast != null && fast.next != null)
    {
        slow = slow.next;
        fast = fast.next.next;
  
        if (slow == fast)
            return true;
    }
    return false;
}
```

### 2.3 常见应用场景

1. 实现LRU缓存
2. 合并有序链表
3. 删除链表中的重复元素
4. 判断链表是否为回文
5. 找到链表的倒数第k个节点
6. 链表排序

### 2.4 性能特点

1. 优点：

   - 动态大小，不需要预先分配空间
   - 插入和删除操作效率高（O(1)）
   - 不需要连续的内存空间
2. 缺点：

   - 随机访问效率低（O(n)）
   - 需要额外的空间存储指针
   - 缓存利用率较低

### 2.5 最佳实践

1. 使用虚拟头节点简化操作
2. 注意处理边界情况（空链表、单节点等）
3. 使用快慢指针解决特定问题
4. 注意内存管理，避免内存泄漏
5. 合理使用递归和迭代方法

## 3. 树（Tree）

### 3.1 基本概念

- 树是一种非线性数据结构，由节点和边组成
- 每个节点可以有多个子节点，但只有一个父节点（根节点除外）
- 常见的树类型：二叉树、二叉搜索树、平衡树、红黑树等

### 3.2 二叉树的基本操作

#### 3.2.1 定义树节点

```csharp
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val) { this.val = val; }
}
```

#### 3.2.2 遍历方式

```csharp
// 前序遍历（根-左-右）
void PreorderTraversal(TreeNode root)
{
    if (root == null) return;
  
    Console.WriteLine(root.val);  // 访问根节点
    PreorderTraversal(root.left); // 遍历左子树
    PreorderTraversal(root.right);// 遍历右子树
}

// 中序遍历（左-根-右）
void InorderTraversal(TreeNode root)
{
    if (root == null) return;
  
    InorderTraversal(root.left);  // 遍历左子树
    Console.WriteLine(root.val);   // 访问根节点
    InorderTraversal(root.right); // 遍历右子树
}

// 后序遍历（左-右-根）
void PostorderTraversal(TreeNode root)
{
    if (root == null) return;
  
    PostorderTraversal(root.left);  // 遍历左子树
    PostorderTraversal(root.right); // 遍历右子树
    Console.WriteLine(root.val);     // 访问根节点
}

// 层序遍历（广度优先）
void LevelOrderTraversal(TreeNode root)
{
    if (root == null) return;
  
    Queue<TreeNode> queue = new Queue<TreeNode>();
    queue.Enqueue(root);
  
    while (queue.Count > 0)
    {
        TreeNode node = queue.Dequeue();
        Console.WriteLine(node.val);
  
        if (node.left != null)
            queue.Enqueue(node.left);
        if (node.right != null)
            queue.Enqueue(node.right);
    }
}
```

#### 3.2.3 常见操作

```csharp
// 计算树的高度
int GetHeight(TreeNode root)
{
    if (root == null) return 0;
    return Math.Max(GetHeight(root.left), GetHeight(root.right)) + 1;
}

// 判断是否为平衡树
bool IsBalanced(TreeNode root)
{
    if (root == null) return true;
  
    int leftHeight = GetHeight(root.left);
    int rightHeight = GetHeight(root.right);
  
    return Math.Abs(leftHeight - rightHeight) <= 1 
           && IsBalanced(root.left) 
           && IsBalanced(root.right);
}

// 判断是否为对称树
bool IsSymmetric(TreeNode root)
{
    if (root == null) return true;
    return IsMirror(root.left, root.right);
}

bool IsMirror(TreeNode left, TreeNode right)
{
    if (left == null && right == null) return true;
    if (left == null || right == null) return false;
  
    return left.val == right.val 
           && IsMirror(left.left, right.right) 
           && IsMirror(left.right, right.left);
}
```

### 3.3 二叉搜索树（BST）操作

```csharp
// 查找节点
TreeNode SearchBST(TreeNode root, int val)
{
    if (root == null || root.val == val) return root;
  
    if (val < root.val)
        return SearchBST(root.left, val);
    else
        return SearchBST(root.right, val);
}

// 插入节点
TreeNode InsertBST(TreeNode root, int val)
{
    if (root == null) return new TreeNode(val);
  
    if (val < root.val)
        root.left = InsertBST(root.left, val);
    else if (val > root.val)
        root.right = InsertBST(root.right, val);
  
    return root;
}

// 删除节点
TreeNode DeleteBST(TreeNode root, int val)
{
    if (root == null) return null;
  
    if (val < root.val)
        root.left = DeleteBST(root.left, val);
    else if (val > root.val)
        root.right = DeleteBST(root.right, val);
    else
    {
        // 情况1：叶子节点
        if (root.left == null && root.right == null)
            return null;
        // 情况2：只有一个子节点
        else if (root.left == null)
            return root.right;
        else if (root.right == null)
            return root.left;
        // 情况3：有两个子节点
        else
        {
            TreeNode minNode = FindMin(root.right);
            root.val = minNode.val;
            root.right = DeleteBST(root.right, minNode.val);
        }
    }
    return root;
}

TreeNode FindMin(TreeNode root)
{
    while (root.left != null)
        root = root.left;
    return root;
}
```

### 3.4 常见应用场景

1. 文件系统的目录结构
2. 数据库索引（B+树）
3. 表达式求值
4. 决策树算法
5. 哈夫曼编码
6. 游戏中的场景树

#### 3.4.1 游戏场景树详解

场景树是游戏引擎中用于组织和管理游戏对象的重要数据结构。它使用树形结构来表示游戏场景中所有对象的层次关系。

```csharp
// 游戏对象基类
public class GameObject
{
    public string name;
    public Transform transform;
    public List<GameObject> children;
    public GameObject parent;

    public GameObject(string name)
    {
        this.name = name;
        this.children = new List<GameObject>();
        this.transform = new Transform();
    }

    // 添加子对象
    public void AddChild(GameObject child)
    {
        child.parent = this;
        children.Add(child);
    }

    // 移除子对象
    public void RemoveChild(GameObject child)
    {
        child.parent = null;
        children.Remove(child);
    }

    // 更新对象（递归更新所有子对象）
    public virtual void Update()
    {
        foreach (var child in children)
        {
            child.Update();
        }
    }
}

// 变换组件
public class Transform
{
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;

    public Transform()
    {
        position = Vector3.zero;
        rotation = Vector3.zero;
        scale = Vector3.one;
    }
}

// 使用示例
class GameScene
{
    public GameObject root;

    public GameScene()
    {
        // 创建场景根节点
        root = new GameObject("Scene");

        // 创建玩家
        GameObject player = new GameObject("Player");
        root.AddChild(player);

        // 创建玩家武器
        GameObject weapon = new GameObject("Weapon");
        player.AddChild(weapon);

        // 创建敌人
        GameObject enemy = new GameObject("Enemy");
        root.AddChild(enemy);
    }

    public void Update()
    {
        // 更新整个场景
        root.Update();
    }
}
```

场景树的主要特点：

1. 层次结构：

   - 每个游戏对象可以有多个子对象
   - 子对象继承父对象的变换（位置、旋转、缩放）
   - 形成清晰的场景层次关系
2. 常见用途：

   - 组织游戏对象
   - 管理对象变换
   - 实现对象继承
   - 优化渲染和物理计算
   - 实现场景序列化
3. 优势：

   - 清晰的层次关系
   - 方便的对象管理
   - 高效的场景遍历
   - 支持对象继承
   - 便于实现场景编辑
4. 实际应用：

   - Unity的GameObject系统
   - Unreal Engine的Actor系统
   - 2D/3D游戏场景管理
   - 游戏对象池
   - 场景加载和卸载

### 3.5 性能特点

1. 优点：

   - 层次结构清晰
   - 查找效率高（平衡树）
   - 支持动态操作
2. 缺点：

   - 可能退化为链表
   - 需要额外的空间存储指针
   - 实现复杂度较高

### 3.6 最佳实践

1. 根据需求选择合适的树类型
2. 注意树的平衡性
3. 合理使用递归和迭代
4. 注意内存管理
5. 考虑使用平衡树（如红黑树、AVL树）提高性能

## 4. 前缀树（Trie/字典树）

### 4.1 基本概念

- 前缀树是一种树形数据结构，用于高效地存储和检索字符串
- 每个节点代表一个字符
- 从根节点到某个节点的路径上的字符连接起来，就是该节点对应的字符串
- 常用于实现字典、自动补全、拼写检查等功能

### 4.2 基本实现

```csharp
public class TrieNode
{
    public Dictionary<char, TrieNode> children;
    public bool isEndOfWord;  // 标记是否是单词的结尾
    public string word;       // 存储完整的单词（可选）

    public TrieNode()
    {
        children = new Dictionary<char, TrieNode>();
        isEndOfWord = false;
        word = null;
    }
}

public class Trie
{
    private TrieNode root;

    public Trie()
    {
        root = new TrieNode();
    }

    // 插入单词
    public void Insert(string word)
    {
        TrieNode current = root;
        foreach (char c in word)
        {
            if (!current.children.ContainsKey(c))
            {
                current.children[c] = new TrieNode();
            }
            current = current.children[c];
        }
        current.isEndOfWord = true;
        current.word = word;
    }

    // 查找单词
    public bool Search(string word)
    {
        TrieNode node = SearchNode(word);
        return node != null && node.isEndOfWord;
    }

    // 查找前缀
    public bool StartsWith(string prefix)
    {
        return SearchNode(prefix) != null;
    }

    // 查找节点
    private TrieNode SearchNode(string word)
    {
        TrieNode current = root;
        foreach (char c in word)
        {
            if (!current.children.ContainsKey(c))
                return null;
            current = current.children[c];
        }
        return current;
    }

    // 获取所有以prefix开头的单词
    public List<string> GetWordsWithPrefix(string prefix)
    {
        List<string> result = new List<string>();
        TrieNode node = SearchNode(prefix);
        if (node != null)
        {
            GetAllWords(node, result);
        }
        return result;
    }

    // 递归获取所有单词
    private void GetAllWords(TrieNode node, List<string> result)
    {
        if (node.isEndOfWord)
        {
            result.Add(node.word);
        }
        foreach (var child in node.children.Values)
        {
            GetAllWords(child, result);
        }
    }
}
```

### 4.3 使用示例

```csharp
// 创建字典树
Trie trie = new Trie();

// 插入单词
trie.Insert("apple");
trie.Insert("app");
trie.Insert("application");
trie.Insert("banana");

// 查找单词
bool hasApple = trie.Search("apple");     // 返回 true
bool hasApp = trie.Search("app");         // 返回 true
bool hasApples = trie.Search("apples");   // 返回 false

// 查找前缀
bool hasAppPrefix = trie.StartsWith("app");    // 返回 true
bool hasBanPrefix = trie.StartsWith("ban");    // 返回 true
bool hasCatPrefix = trie.StartsWith("cat");    // 返回 false

// 获取所有以"app"开头的单词
List<string> words = trie.GetWordsWithPrefix("app");
// 返回: ["app", "apple", "application"]
```

### 4.4 常见应用场景

1. 自动补全

   - 搜索引擎的搜索建议
   - IDE的代码补全
   - 输入法的单词提示
2. 拼写检查

   - 检查单词是否在字典中
   - 提供拼写建议
3. 路由表查找

   - IP路由表
   - 网络包转发
4. 字符串匹配

   - 多模式字符串匹配
   - 敏感词过滤

### 4.5 性能特点

1. 优点：

   - 查找效率高（O(m)，m为单词长度）
   - 空间效率好（共享前缀）
   - 支持前缀匹配
   - 适合字符串相关操作
2. 缺点：

   - 空间复杂度较高
   - 不适合存储大量短字符串
   - 实现相对复杂

### 4.6 最佳实践

1. 根据实际需求选择合适的数据结构
2. 考虑使用压缩前缀树（Radix Tree）优化空间
3. 注意内存管理
4. 合理设计节点结构
5. 考虑使用其他数据结构（如哈希表）作为补充

## 5. 栈（Stack）

### 5.1 基本概念

- 栈是一种后进先出（LIFO）的线性数据结构
- 只允许在一端进行插入和删除操作
- 插入操作称为入栈（Push）
- 删除操作称为出栈（Pop）
- 查看栈顶元素称为Peek

### 5.2 基本操作

```csharp
// 使用C#内置的Stack类
Stack<int> stack = new Stack<int>();

// 入栈
stack.Push(1);
stack.Push(2);
stack.Push(3);

// 出栈
int top = stack.Pop();  // 返回3并移除

// 查看栈顶元素
int peek = stack.Peek();  // 返回2但不移除

// 检查栈是否为空
bool isEmpty = stack.Count == 0;

// 获取栈中元素数量
int count = stack.Count;
```

### 5.3 常见应用场景

#### 5.3.1 括号匹配

```csharp
// 1. 创建栈来存储左括号
Stack<char> stack = new Stack<char>();

// 2. 遍历字符串中的每个字符
foreach (char c in s)
{
    // 3. 如果是左括号，入栈
    if (c == '(' || c == '[' || c == '{')
    {
        stack.Push(c);
    }
    // 4. 如果是右括号
    else
    {
        // 5. 如果栈为空，说明没有匹配的左括号
        if (stack.Count == 0) return false;
  
        // 6. 弹出栈顶的左括号
        char top = stack.Pop();
  
        // 7. 检查是否匹配
        if ((c == ')' && top != '(') ||
            (c == ']' && top != '[') ||
            (c == '}' && top != '{'))
        {
            return false;
        }
    }
}

// 8. 最后检查栈是否为空
return stack.Count == 0;
        {
            if (stack.Count == 0) return false;
  
            char top = stack.Pop();
            if ((c == ')' && top != '(') ||
                (c == ']' && top != '[') ||
                (c == '}' && top != '{'))
            {
                return false;
            }
        }
    }
  
    return stack.Count == 0;
}
```

```
输入: "{[()]}"
步骤:
1. 遇到 '{'，入栈 -> 栈: ['{']
2. 遇到 '['，入栈 -> 栈: ['{', '[']
3. 遇到 '('，入栈 -> 栈: ['{', '[', '(']
4. 遇到 ')'，弹出 '('，匹配 -> 栈: ['{', '[']
5. 遇到 ']'，弹出 '['，匹配 -> 栈: ['{']
6. 遇到 '}'，弹出 '{'，匹配 -> 栈: []
7. 栈为空，返回 true

输入: "{[()]"
步骤:
1. 遇到 '{'，入栈 -> 栈: ['{']
2. 遇到 '['，入栈 -> 栈: ['{', '[']
3. 遇到 '('，入栈 -> 栈: ['{', '[', '(']
4. 遇到 ')'，弹出 '('，匹配 -> 栈: ['{', '[']
5. 遇到 ']'，弹出 '['，匹配 -> 栈: ['{']
6. 栈不为空，返回 false
```

#### 5.3.2 表达式求值

```csharp
// 1. 创建栈来存储数字
Stack<int> stack = new Stack<int>();

// 2. 遍历每个token
foreach (string token in tokens)
{
    // 3. 如果是数字，入栈
    if (int.TryParse(token, out int num))
    {
        stack.Push(num);
    }
    // 4. 如果是运算符
    else
    {
        // 5. 弹出两个操作数（注意顺序：b是后弹出的，a是先弹出的）
        int b = stack.Pop();
        int a = stack.Pop();
  
        // 6. 根据运算符进行计算，结果入栈
        switch (token)
        {
            case "+": stack.Push(a + b); break;
            case "-": stack.Push(a - b); break;
            case "*": stack.Push(a * b); break;
            case "/": stack.Push(a / b); break;
        }
    }
}

// 7. 返回栈顶元素（最终结果）
return stack.Pop();
```

#### 5.3.3 函数调用栈

```csharp
// 递归函数的调用栈
void RecursiveFunction(int n)
{
    if (n <= 0) return;
  
    Console.WriteLine($"进入函数，n = {n}");
    RecursiveFunction(n - 1);
    Console.WriteLine($"离开函数，n = {n}");
}
```

#### 5.3.4 深度优先搜索（DFS）

```csharp
// 1. 空树检查
if (root == null) return;

// 2. 创建栈并压入根节点
Stack<TreeNode> stack = new Stack<TreeNode>();
stack.Push(root);

// 3. 循环处理栈中的节点
while (stack.Count > 0)
{
    // 4. 弹出栈顶节点并访问
    TreeNode node = stack.Pop();
    Console.WriteLine(node.val);
  
    // 5. 先压入右子节点，再压入左子节点
    // 注意：因为栈是后进先出，所以先压右后压左
    if (node.right != null)
        stack.Push(node.right);
    if (node.left != null)
        stack.Push(node.left);
}
```

```
树的结构：
     1
    / \
   2   3
  / \
 4   5

遍历步骤：
1. 初始状态：栈 = [1]
2. 弹出1，访问1，压入3和2：栈 = [3, 2]
3. 弹出2，访问2，压入5和4：栈 = [3, 5, 4]
4. 弹出4，访问4：栈 = [3, 5]
5. 弹出5，访问5：栈 = [3]
6. 弹出3，访问3：栈 = []
7. 栈空，遍历结束

输出顺序：1 -> 2 -> 4 -> 5 -> 3
```

### 5.4 性能特点

1. 优点：

   - 入栈和出栈操作都是O(1)时间复杂度
   - 实现简单
   - 内存使用效率高
2. 缺点：

   - 只能访问栈顶元素
   - 不支持随机访问
   - 空间大小固定（如果使用数组实现）

### 5.5 最佳实践

1. 使用场景选择：

   - 需要后进先出（LIFO）的场景
   - 需要回溯操作的场景
   - 需要保存历史状态的场景
2. 实现建议：

   - 使用C#内置的Stack类
   - 注意栈的容量限制
   - 处理栈空的情况
   - 考虑使用泛型栈增加类型安全性
3. 常见错误：

   - 在空栈上调用Pop或Peek
   - 栈溢出（如果使用固定大小数组）
   - 忘记处理异常情况
4. 优化技巧：

   - 使用数组实现固定大小的栈
   - 使用链表实现动态大小的栈
   - 考虑使用双栈实现队列

## 6. 队列（Queue）

### 6.1 基本概念

- 队列是一种先进先出（FIFO）的线性数据结构
- 只允许在一端进行插入操作（入队），在另一端进行删除操作（出队）
- 插入操作称为入队（Enqueue）
- 删除操作称为出队（Dequeue）
- 查看队首元素称为Peek

### 6.2 基本操作

```csharp
// 使用C#内置的Queue类
Queue<int> queue = new Queue<int>();

// 入队
queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);

// 出队
int front = queue.Dequeue();  // 返回1并移除

// 查看队首元素
int peek = queue.Peek();  // 返回2但不移除

// 检查队列是否为空
bool isEmpty = queue.Count == 0;

// 获取队列中元素数量
int count = queue.Count;
```

### 6.3 常见应用场景

#### 6.3.1 广度优先搜索（BFS）

```csharp
void BFS(TreeNode root)
{
    if (root == null) return;
  
    Queue<TreeNode> queue = new Queue<TreeNode>();
    queue.Enqueue(root);
  
    while (queue.Count > 0)
    {
        TreeNode node = queue.Dequeue();
        Console.WriteLine(node.val);
  
        if (node.left != null)
            queue.Enqueue(node.left);
        if (node.right != null)
            queue.Enqueue(node.right);
    }
}
```

```
树的结构：
     1
    / \
   2   3
  / \
 4   5

遍历步骤：
1. 初始状态：队列 = [1]
2. 取出1，访问1，加入2和3：队列 = [2, 3]
3. 取出2，访问2，加入4和5：队列 = [3, 4, 5]
4. 取出3，访问3：队列 = [4, 5]
5. 取出4，访问4：队列 = [5]
6. 取出5，访问5：队列 = []
7. 队列空，遍历结束

输出顺序：1 -> 2 -> 3 -> 4 -> 5
```

#### 6.3.2 任务调度

```csharp
class Task
{
    public string Name { get; set; }
    public int Priority { get; set; }
}

class TaskScheduler
{
    private Queue<Task> taskQueue = new Queue<Task>();
  
    public void AddTask(Task task)
    {
        taskQueue.Enqueue(task);
    }
  
    public Task GetNextTask()
    {
        return taskQueue.Count > 0 ? taskQueue.Dequeue() : null;
    }
}
```

#### 6.3.3 消息队列

```csharp
class Message
{
    public string Content { get; set; }
    public DateTime Timestamp { get; set; }
}

class MessageQueue
{
    private Queue<Message> messageQueue = new Queue<Message>();
  
    public void SendMessage(Message message)
    {
        messageQueue.Enqueue(message);
    }
  
    public Message ReceiveMessage()
    {
        return messageQueue.Count > 0 ? messageQueue.Dequeue() : null;
    }
}
```

#### 6.3.4 打印队列

```csharp
class PrintJob
{
    public string DocumentName { get; set; }
    public int Pages { get; set; }
}

class Printer
{
    private Queue<PrintJob> printQueue = new Queue<PrintJob>();
  
    public void AddPrintJob(PrintJob job)
    {
        printQueue.Enqueue(job);
    }
  
    public void ProcessPrintJobs()
    {
        while (printQueue.Count > 0)
        {
            PrintJob job = printQueue.Dequeue();
            Console.WriteLine($"打印文档：{job.DocumentName}，页数：{job.Pages}");
        }
    }
}
```

### 6.4 性能特点

1. 优点：

   - 入队和出队操作都是O(1)时间复杂度
   - 实现简单
   - 内存使用效率高
   - 适合处理需要按顺序处理的数据
2. 缺点：

   - 只能访问队首元素
   - 不支持随机访问
   - 空间大小固定（如果使用数组实现）

### 6.5 最佳实践

1. 使用场景选择：

   - 需要先进先出（FIFO）的场景
   - 需要按顺序处理数据的场景
   - 需要缓冲数据的场景
   - 需要实现生产者-消费者模式的场景
2. 实现建议：

   - 使用C#内置的Queue类
   - 注意队列的容量限制
   - 处理队列空的情况
   - 考虑使用泛型队列增加类型安全性
3. 常见错误：

   - 在空队列上调用Dequeue或Peek
   - 队列溢出（如果使用固定大小数组）
   - 忘记处理异常情况
4. 优化技巧：

   - 使用循环数组实现固定大小的队列
   - 使用链表实现动态大小的队列
   - 考虑使用优先级队列处理特殊需求
   - 使用并发队列处理多线程场景

## 7. 双端队列（Deque）

### 7.1 基本概念

- 双端队列是一种可以在两端进行插入和删除操作的线性数据结构
- 支持在队首和队尾进行入队和出队操作
- 可以同时具有栈和队列的特性
- C#中可以使用 `LinkedList<T>` 或自定义实现

### 7.2 基本实现

```csharp
public class Deque<T>
{
    private LinkedList<T> list = new LinkedList<T>();

    // 在队首添加元素
    public void AddFirst(T item)
    {
        list.AddFirst(item);
    }

    // 在队尾添加元素
    public void AddLast(T item)
    {
        list.AddLast(item);
    }

    // 从队首移除元素
    public T RemoveFirst()
    {
        if (list.Count == 0)
            throw new InvalidOperationException("队列为空");
  
        T item = list.First.Value;
        list.RemoveFirst();
        return item;
    }

    // 从队尾移除元素
    public T RemoveLast()
    {
        if (list.Count == 0)
            throw new InvalidOperationException("队列为空");
  
        T item = list.Last.Value;
        list.RemoveLast();
        return item;
    }

    // 查看队首元素
    public T PeekFirst()
    {
        if (list.Count == 0)
            throw new InvalidOperationException("队列为空");
  
        return list.First.Value;
    }

    // 查看队尾元素
    public T PeekLast()
    {
        if (list.Count == 0)
            throw new InvalidOperationException("队列为空");
  
        return list.Last.Value;
    }

    // 获取元素数量
    public int Count => list.Count;

    // 检查是否为空
    public bool IsEmpty => list.Count == 0;
}
```

### 7.3 常见应用场景

#### 7.3.1 滑动窗口

```csharp
public int[] MaxSlidingWindow(int[] nums, int k)
{
    if (nums == null || nums.Length == 0 || k <= 0)
        return new int[0];

    int[] result = new int[nums.Length - k + 1];
    Deque<int> deque = new Deque<int>();

    for (int i = 0; i < nums.Length; i++)
    {
        // 移除超出窗口范围的元素
        while (!deque.IsEmpty && deque.PeekFirst() <= i - k)
            deque.RemoveFirst();

        // 移除小于当前元素的元素
        while (!deque.IsEmpty && nums[deque.PeekLast()] < nums[i])
            deque.RemoveLast();

        // 添加当前元素
        deque.AddLast(i);

        // 记录窗口最大值
        if (i >= k - 1)
            result[i - k + 1] = nums[deque.PeekFirst()];
    }

    return result;
}
```

#### 7.3.2 回文检查

```csharp
public bool IsPalindrome(string s)
{
    Deque<char> deque = new Deque<char>();
  
    // 将字符串转换为小写并移除非字母数字字符
    foreach (char c in s.ToLower())
    {
        if (char.IsLetterOrDigit(c))
            deque.AddLast(c);
    }

    // 从两端比较字符
    while (deque.Count > 1)
    {
        if (deque.RemoveFirst() != deque.RemoveLast())
            return false;
    }

    return true;
}
```

#### 7.3.3 任务调度器

```csharp
class Task
{
    public string Name { get; set; }
    public int Priority { get; set; }
}

class TaskScheduler
{
    private Deque<Task> taskDeque = new Deque<Task>();

    // 添加高优先级任务到队首
    public void AddHighPriorityTask(Task task)
    {
        taskDeque.AddFirst(task);
    }

    // 添加普通任务到队尾
    public void AddNormalTask(Task task)
    {
        taskDeque.AddLast(task);
    }

    // 获取下一个任务
    public Task GetNextTask()
    {
        return taskDeque.Count > 0 ? taskDeque.RemoveFirst() : null;
    }
}
```

### 7.4 性能特点

1. 优点：

   - 两端操作都是O(1)时间复杂度
   - 灵活性高，可以同时作为栈和队列使用
   - 适合需要双向操作的数据结构
2. 缺点：

   - 实现相对复杂
   - 内存使用效率较低（如果使用链表实现）
   - 随机访问效率低

### 7.5 最佳实践

1. 使用场景选择：

   - 需要双向操作的数据结构
   - 滑动窗口问题
   - 回文检查
   - 需要同时具有栈和队列特性的场景
2. 实现建议：

   - 使用 `LinkedList<T>` 实现
   - 考虑使用数组实现固定大小的双端队列
   - 注意边界条件的处理
   - 使用泛型增加类型安全性
3. 常见错误：

   - 在空队列上调用移除操作
   - 忘记处理边界情况
   - 内存泄漏（如果使用链表实现）
4. 优化技巧：

   - 使用循环数组实现固定大小的双端队列
   - 考虑使用并发双端队列处理多线程场景
   - 根据实际需求选择合适的实现方式

## 8. 堆（Heap）

### 8.1 基本概念

- 堆是一种特殊的完全二叉树
- 每个节点的值都大于等于（最大堆）或小于等于（最小堆）其子节点的值
- 常用于实现优先队列
- C#中可以使用 `PriorityQueue<T>` 或自定义实现

### 8.2 基本实现

```csharp
// 使用C#内置的PriorityQueue类
// 创建优先队列，TElement是元素类型，TPriority是优先级类型
PriorityQueue<string, int> priorityQueue = new PriorityQueue<string, int>();

// 添加元素（元素，优先级）
priorityQueue.Enqueue("任务1", 1);  // 低优先级
priorityQueue.Enqueue("任务2", 2);  // 中优先级
priorityQueue.Enqueue("任务3", 3);  // 高优先级

// 获取并移除优先级最高的元素
string highestPriority = priorityQueue.Dequeue();  // 返回"任务3"

// 查看优先级最高的元素但不移除
string peek = priorityQueue.Peek();  // 返回"任务2"

// 检查队列是否为空
bool isEmpty = priorityQueue.Count == 0;

// 获取队列中元素数量
int count = priorityQueue.Count;
```

### 8.3 常见应用场景

#### 8.3.1 优先队列

```csharp
class Task
{
    public string Name { get; set; }
    public int Priority { get; set; }
}

class TaskScheduler
{
    private PriorityQueue<Task, int> taskQueue = new PriorityQueue<Task, int>();

    public void AddTask(Task task)
    {
        // 优先级数字越小，优先级越高
        taskQueue.Enqueue(task, task.Priority);
    }

    public Task GetNextTask()
    {
        return taskQueue.Count > 0 ? taskQueue.Dequeue() : null;
    }
}
```

#### 8.3.2 合并K个有序链表

```csharp
public ListNode MergeKLists(ListNode[] lists)
{
    if (lists == null || lists.Length == 0)
        return null;

    // 创建优先队列，按节点值排序
    var queue = new PriorityQueue<ListNode, int>();

    // 将每个链表的头节点加入队列
    foreach (var list in lists)
    {
        if (list != null)
            queue.Enqueue(list, list.val);
    }

    ListNode dummy = new ListNode(0);
    ListNode current = dummy;

    // 不断从队列中取出最小节点
    while (queue.Count > 0)
    {
        ListNode node = queue.Dequeue();
        current.next = node;
        current = current.next;

        if (node.next != null)
            queue.Enqueue(node.next, node.next.val);
    }

    return dummy.next;
}
```

#### 8.3.3 数据流的中位数

```csharp
class MedianFinder
{
    // 存储较大的一半，最小堆
    private PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
    // 存储较小的一半，最大堆（使用负数实现）
    private PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>();

    public void AddNum(int num)
    {
        // 将新数字加入最大堆
        maxHeap.Enqueue(num, -num);
    
        // 平衡两个堆
        minHeap.Enqueue(maxHeap.Dequeue(), maxHeap.Peek());
    
        // 确保最大堆的大小不小于最小堆
        if (maxHeap.Count < minHeap.Count)
        {
            maxHeap.Enqueue(minHeap.Dequeue(), -minHeap.Peek());
        }
    }

    public double FindMedian()
    {
        if (maxHeap.Count > minHeap.Count)
            return maxHeap.Peek();
        return (maxHeap.Peek() + minHeap.Peek()) / 2.0;
    }
}
```

#### 8.3.4 前K个高频元素

```csharp
public int[] TopKFrequent(int[] nums, int k)
{
    // 统计频率
    Dictionary<int, int> frequency = new Dictionary<int, int>();
    foreach (int num in nums)
    {
        if (!frequency.ContainsKey(num))
            frequency[num] = 0;
        frequency[num]++;
    }

    // 创建优先队列，按频率排序
    var queue = new PriorityQueue<int, int>();

    // 将元素加入队列
    foreach (var pair in frequency)
    {
        queue.Enqueue(pair.Key, -pair.Value);  // 使用负数实现最大堆
        if (queue.Count > k)
            queue.Dequeue();
    }

    // 获取结果
    int[] result = new int[k];
    for (int i = k - 1; i >= 0; i--)
    {
        result[i] = queue.Dequeue();
    }

    return result;
}
```

### 8.4 性能特点

1. 优点：

   - 插入和删除操作都是O(log n)时间复杂度
   - 获取最大/最小值是O(1)时间复杂度
   - 适合需要频繁获取最大/最小值的场景
   - 空间效率高
2. 缺点：

   - 不支持随机访问
   - 不支持快速查找
   - 构建堆需要O(n)时间复杂度

### 8.5 最佳实践

1. 使用场景选择：

   - 需要频繁获取最大/最小值的场景
   - 需要按优先级处理数据的场景
   - 需要合并有序数据的场景
   - 需要维护数据流中位数的场景
2. 实现建议：

   - 使用数组实现完全二叉树
   - 注意堆的平衡性
   - 合理选择最大堆或最小堆
   - 考虑使用泛型增加类型安全性
3. 常见错误：

   - 忘记维护堆的性质
   - 数组索引越界
   - 比较函数实现错误
   - 内存管理不当
4. 优化技巧：

   - 使用数组实现固定大小的堆
   - 考虑使用并发堆处理多线程场景
   - 根据实际需求选择合适的堆类型
   - 优化比较函数的性能

## 9. 哈希表（Dictionary）

### 9.1 基本概念

- 哈希表是一种键值对（Key-Value）数据结构
- 通过哈希函数将键映射到存储位置
- 支持快速的查找、插入和删除操作
- C#中提供了多种哈希表实现：

1. `Dictionary<TKey, TValue>`：

   - 最常用的哈希表实现
   - 线程不安全
   - 支持泛型

   ```csharp
   Dictionary<string, int> dict = new Dictionary<string, int>();
   ```
2. `Hashtable`：

   - 非泛型版本
   - 线程安全
   - 键和值都是 `object` 类型

   ```csharp
   Hashtable hashtable = new Hashtable();
   hashtable["key"] = "value";
   ```
3. `ConcurrentDictionary<TKey, TValue>`：

   - 线程安全的泛型哈希表
   - 适合多线程环境

   ```csharp
   ConcurrentDictionary<string, int> concurrentDict = new ConcurrentDictionary<string, int>();
   ```
4. `SortedDictionary<TKey, TValue>`：

   - 按键排序的哈希表
   - 内部使用红黑树实现

   ```csharp
   SortedDictionary<string, int> sortedDict = new SortedDictionary<string, int>();
   ```
5. `HashSet<T>`：

   - 只存储键的哈希表
   - 用于去重

   ```csharp
   HashSet<int> set = new HashSet<int>();
   ```

### 9.2 基本操作

```csharp
// 创建字典
Dictionary<string, int> dict = new Dictionary<string, int>();

// 添加键值对
dict.Add("apple", 1);
dict["banana"] = 2;  // 使用索引器添加

// 查找值
int value = dict["apple"];  // 使用索引器查找
bool exists = dict.TryGetValue("apple", out int value);  // 安全查找

// 检查键是否存在
bool hasKey = dict.ContainsKey("apple");

// 删除键值对
dict.Remove("apple");

// 获取键值对数量
int count = dict.Count;

// 遍历字典
foreach (var pair in dict)
{
    Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
}

// 只遍历键
foreach (var key in dict.Keys)
{
    Console.WriteLine($"Key: {key}");
}

// 只遍历值
foreach (var value in dict.Values)
{
    Console.WriteLine($"Value: {value}");
}
```

### 9.3 常见应用场景

#### 9.3.1 计数统计

```csharp
// 统计字符串中每个字符出现的次数
string str = "hello world";
Dictionary<char, int> charCount = new Dictionary<char, int>();

foreach (char c in str)
{
    if (charCount.ContainsKey(c))
        charCount[c]++;
    else
        charCount[c] = 1;
}

// 使用更简洁的写法
foreach (char c in str)
{
    charCount[c] = charCount.GetValueOrDefault(c, 0) + 1;
}
```

#### 9.3.2 缓存实现

```csharp
class Cache<TKey, TValue>
{
    private Dictionary<TKey, TValue> cache = new Dictionary<TKey, TValue>();
    private int capacity;

    public Cache(int capacity)
    {
        this.capacity = capacity;
    }

    public TValue Get(TKey key)
    {
        if (cache.TryGetValue(key, out TValue value))
            return value;
        return default;
    }

    public void Put(TKey key, TValue value)
    {
        if (cache.Count >= capacity)
        {
            // 移除最早添加的项
            var firstKey = cache.Keys.First();
            cache.Remove(firstKey);
        }
        cache[key] = value;
    }
}
```

#### 9.3.3 两数之和

```csharp
public int[] TwoSum(int[] nums, int target)
{
    Dictionary<int, int> dict = new Dictionary<int, int>();
  
    for (int i = 0; i < nums.Length; i++)
    {
        int complement = target - nums[i];
        if (dict.ContainsKey(complement))
        {
            return new int[] { dict[complement], i };
        }
        dict[nums[i]] = i;
    }
  
    return new int[0];
}
```

#### 9.3.4 字符串分组

```csharp
// 将具有相同字符的字符串分组
public IList<IList<string>> GroupAnagrams(string[] strs)
{
    Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();
  
    foreach (string str in strs)
    {
        // 将字符串排序作为键
        char[] chars = str.ToCharArray();
        Array.Sort(chars);
        string key = new string(chars);
    
        if (!groups.ContainsKey(key))
        {
            groups[key] = new List<string>();
        }
        groups[key].Add(str);
    }
  
    return groups.Values.ToList<IList<string>>();
}
```

#### 9.3.5 最近最少使用（LRU）缓存

```csharp
class LRUCache
{
    private Dictionary<int, LinkedListNode<(int key, int value)>> cache;
    private LinkedList<(int key, int value)> list;
    private int capacity;

    public LRUCache(int capacity)
    {
        this.capacity = capacity;
        cache = new Dictionary<int, LinkedListNode<(int key, int value)>>();
        list = new LinkedList<(int key, int value)>();
    }

    public int Get(int key)
    {
        if (!cache.ContainsKey(key))
            return -1;

        var node = cache[key];
        list.Remove(node);
        list.AddLast(node);
        return node.Value.value;
    }

    public void Put(int key, int value)
    {
        if (cache.ContainsKey(key))
        {
            var node = cache[key];
            list.Remove(node);
            node.Value = (key, value);
            list.AddLast(node);
        }
        else
        {
            if (cache.Count >= capacity)
            {
                var first = list.First;
                cache.Remove(first.Value.key);
                list.RemoveFirst();
            }
            var newNode = list.AddLast((key, value));
            cache[key] = newNode;
        }
    }
}
```

### 9.4 性能特点

1. 优点：

   - 查找、插入、删除操作的平均时间复杂度为O(1)
   - 支持任意类型的键和值
   - 内存使用效率高
   - 适合需要快速查找的场景
2. 缺点：

   - 不保证元素的顺序
   - 哈希冲突可能影响性能
   - 需要额外的内存空间
   - 键必须是唯一的

### 9.5 最佳实践

1. 使用场景选择：

   - 需要快速查找的场景
   - 需要计数统计的场景
   - 需要缓存数据的场景
   - 需要去重的场景
2. 实现建议：

   - 使用 `TryGetValue` 代替 `ContainsKey` 和索引器
   - 合理设置初始容量避免频繁扩容
   - 注意键的唯一性
   - 考虑使用 `ConcurrentDictionary` 处理并发场景
3. 常见错误：

   - 使用不存在的键访问值
   - 忘记处理哈希冲突
   - 使用可变对象作为键
   - 并发访问时未使用线程安全的集合
4. 优化技巧：

   - 预分配容量减少扩容
   - 使用合适的哈希函数
   - 考虑使用 `HashSet<T>` 处理只需要键的场景
   - 使用 `ConcurrentDictionary` 处理多线程场景

## 10. 集合（HashSet）

### 10.1 基本概念

- HashSet是一种不包含重复元素的集合
- 基于哈希表实现，提供O(1)的查找性能
- 不保证元素的顺序
- 适合需要快速查找和去重的场景

### 10.2 基本操作

```csharp
// 创建HashSet
HashSet<int> set = new HashSet<int>();

// 添加元素
set.Add(1);
set.Add(2);
set.Add(3);

// 检查元素是否存在
bool contains = set.Contains(1);  // 返回 true

// 删除元素
set.Remove(1);

// 获取元素数量
int count = set.Count;

// 遍历集合
foreach (int item in set)
{
    Console.WriteLine(item);
}

// 清空集合
set.Clear();
```

### 10.3 常见应用场景

#### 10.3.1 数组去重

```csharp
int[] numbers = { 1, 2, 2, 3, 3, 4, 5, 5 };
HashSet<int> uniqueNumbers = new HashSet<int>(numbers);
// uniqueNumbers 包含 { 1, 2, 3, 4, 5 }
```

#### 10.3.2 查找重复元素

```csharp
public int[] FindDuplicates(int[] nums)
{
    HashSet<int> seen = new HashSet<int>();
    HashSet<int> duplicates = new HashSet<int>();
  
    foreach (int num in nums)
    {
        if (!seen.Add(num))  // Add方法在元素已存在时返回false
        {
            duplicates.Add(num);
        }
    }
  
    return duplicates.ToArray();
}
```

#### 10.3.3 集合运算

```csharp
HashSet<int> set1 = new HashSet<int> { 1, 2, 3, 4, 5 };
HashSet<int> set2 = new HashSet<int> { 4, 5, 6, 7, 8 };

// 并集
HashSet<int> union = new HashSet<int>(set1);
union.UnionWith(set2);  // 结果: { 1, 2, 3, 4, 5, 6, 7, 8 }

// 交集
HashSet<int> intersection = new HashSet<int>(set1);
intersection.IntersectWith(set2);  // 结果: { 4, 5 }

// 差集
HashSet<int> difference = new HashSet<int>(set1);
difference.ExceptWith(set2);  // 结果: { 1, 2, 3 }

// 对称差集（只在一个集合中出现的元素）
HashSet<int> symmetricDifference = new HashSet<int>(set1);
symmetricDifference.SymmetricExceptWith(set2);  // 结果: { 1, 2, 3, 6, 7, 8 }
```

#### 10.3.4 判断集合关系

```csharp
HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
HashSet<int> set2 = new HashSet<int> { 1, 2, 3, 4, 5 };

// 判断是否为子集
bool isSubset = set1.IsSubsetOf(set2);  // 返回 true

// 判断是否为超集
bool isSuperset = set2.IsSupersetOf(set1);  // 返回 true

// 判断是否重叠
bool overlaps = set1.Overlaps(set2);  // 返回 true

// 判断是否相等
bool equals = set1.SetEquals(set2);  // 返回 false
```

### 10.4 性能特点

1. 优点：

   - 查找、插入、删除操作的平均时间复杂度为O(1)
   - 自动去重
   - 内存使用效率高
   - 支持集合运算
2. 缺点：

   - 不保证元素的顺序
   - 哈希冲突可能影响性能
   - 需要额外的内存空间

### 10.5 最佳实践

1. 使用场景选择：

   - 需要快速查找元素
   - 需要去重
   - 需要集合运算
   - 不需要保持元素顺序
2. 实现建议：

   - 合理设置初始容量避免频繁扩容
   - 使用 `TryGetValue` 代替 `Contains`
   - 考虑使用 `ConcurrentHashSet` 处理并发场景
3. 常见错误：

   - 期望保持元素顺序
   - 忘记处理哈希冲突
   - 使用可变对象作为元素
   - 并发访问时未使用线程安全的集合
4. 优化技巧：

   - 预分配容量减少扩容
   - 使用合适的哈希函数
   - 考虑使用 `SortedSet<T>` 需要排序时
   - 使用 `ConcurrentHashSet` 处理多线程场景

## 11. 并查集（Disjoint Set）

### 11.1 基本概念

- 并查集是一种树形数据结构，用于处理不相交集合的合并及查询问题
- 支持两种操作：
  - Find：查找元素所属的集合
  - Union：合并两个集合
- 常用于解决连通性问题

### 11.2 基本实现

```csharp
public class DisjointSet
{
    private int[] parent;  // 存储每个节点的父节点
    private int[] rank;    // 存储每个节点的秩（树的高度）

    public DisjointSet(int size)
    {
        parent = new int[size];
        rank = new int[size];
    
        // 初始化，每个节点的父节点是自己
        for (int i = 0; i < size; i++)
        {
            parent[i] = i;
            rank[i] = 0;
        }
    }

    // 查找元素所属的集合（路径压缩）
    public int Find(int x)
    {
        if (parent[x] != x)
        {
            parent[x] = Find(parent[x]);  // 路径压缩
        }
        return parent[x];
    }

    // 合并两个集合（按秩合并）
    public void Union(int x, int y)
    {
        int rootX = Find(x);
        int rootY = Find(y);

        if (rootX == rootY) return;

        // 按秩合并
        if (rank[rootX] < rank[rootY])
        {
            parent[rootX] = rootY;
        }
        else if (rank[rootX] > rank[rootY])
        {
            parent[rootY] = rootX;
        }
        else
        {
            parent[rootY] = rootX;
            rank[rootX]++;
        }
    }

    // 检查两个元素是否属于同一集合
    public bool IsConnected(int x, int y)
    {
        return Find(x) == Find(y);
    }
}
```

### 11.3 常见应用场景

#### 11.3.1 岛屿数量

```csharp
public int NumIslands(char[][] grid)
{
    if (grid == null || grid.Length == 0) return 0;

    int rows = grid.Length;
    int cols = grid[0].Length;
    DisjointSet ds = new DisjointSet(rows * cols);
    int count = 0;

    // 遍历网格
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            if (grid[i][j] == '1')
            {
                count++;
                // 检查上下左右
                if (i > 0 && grid[i-1][j] == '1')
                {
                    ds.Union(i * cols + j, (i-1) * cols + j);
                    count--;
                }
                if (j > 0 && grid[i][j-1] == '1')
                {
                    ds.Union(i * cols + j, i * cols + (j-1));
                    count--;
                }
            }
        }
    }
    return count;
}
```

#### 11.3.2 朋友圈

```csharp
public int FindCircleNum(int[][] M)
{
    int n = M.Length;
    DisjointSet ds = new DisjointSet(n);
  
    // 遍历矩阵
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (M[i][j] == 1)
            {
                ds.Union(i, j);
            }
        }
    }
  
    // 统计不同的根节点数量
    HashSet<int> roots = new HashSet<int>();
    for (int i = 0; i < n; i++)
    {
        roots.Add(ds.Find(i));
    }
  
    return roots.Count;
}
```

#### 11.3.3 冗余连接

```csharp
public int[] FindRedundantConnection(int[][] edges)
{
    int n = edges.Length;
    DisjointSet ds = new DisjointSet(n + 1);
  
    foreach (int[] edge in edges)
    {
        int x = edge[0];
        int y = edge[1];
    
        if (ds.IsConnected(x, y))
        {
            return edge;
        }
    
        ds.Union(x, y);
    }
  
    return new int[0];
}
```

#### 11.3.4 最小生成树（Kruskal算法）

```csharp
public int MinimumCost(int n, int[][] connections)
{
    // 按权重排序
    Array.Sort(connections, (a, b) => a[2].CompareTo(b[2]));
  
    DisjointSet ds = new DisjointSet(n + 1);
    int cost = 0;
    int count = 0;
  
    foreach (int[] connection in connections)
    {
        int x = connection[0];
        int y = connection[1];
        int weight = connection[2];
    
        if (!ds.IsConnected(x, y))
        {
            ds.Union(x, y);
            cost += weight;
            count++;
        }
    
        if (count == n - 1)
        {
            return cost;
        }
    }
  
    return -1;
}
```

### 11.4 性能特点

1. 优点：

   - 查找和合并操作的平均时间复杂度接近O(1)
   - 空间复杂度为O(n)
   - 适合处理大规模数据
   - 实现简单，易于理解
2. 缺点：

   - 不支持集合的分离操作
   - 不支持动态添加元素
   - 需要预先知道元素数量

### 11.5 最佳实践

1. 使用场景选择：

   - 需要处理连通性问题
   - 需要合并集合
   - 需要判断元素是否属于同一集合
   - 图论中的最小生成树问题
2. 实现建议：

   - 使用路径压缩优化查找操作
   - 使用按秩合并优化合并操作
   - 合理初始化数组大小
   - 注意处理边界情况
3. 常见错误：

   - 忘记初始化父节点数组
   - 没有使用路径压缩
   - 没有使用按秩合并
   - 数组越界
4. 优化技巧：

   - 使用路径压缩
   - 使用按秩合并
   - 使用哈希表存储父节点（当元素不是连续整数时）
   - 考虑使用并发并查集处理多线程场景

## 12. 图（Graph）

### 12.1 基本概念

- 图是由顶点（Vertex）和边（Edge）组成的非线性数据结构
- 图可以分为有向图和无向图
- 边可以有权重（加权图）或无权重（无权图）
- 常见的表示方法：邻接矩阵和邻接表

### 12.2 基本实现

数组实现

#### 12.2.1 邻接矩阵表示

```csharp
bool[,] graph = new bool[4, 4];
graph[0, 1] = graph[1, 0] = true;
graph[0, 3] = graph[3, 0] = true;
graph[1, 2] = graph[2, 1] = true;
graph[2, 3] = graph[3, 2] = true;
```

#### 12.2.2 邻接表表示

```csharp
// 推荐写法
List<List<int>> graph = new List<List<int>>();
for (int i = 0; i < 4; i++)
    graph.Add(new List<int>());

graph[0].Add(1); graph[0].Add(3);
graph[1].Add(0); graph[1].Add(2);
graph[2].Add(1); graph[2].Add(3);
graph[3].Add(0); graph[3].Add(2);
```

### 12.3 常见应用场景

#### 12.3.1 深度优先搜索（DFS）

// 邻接表实现

```csharp
void DFS_List(List<List<int>> graph, int v, bool[] visited)
{
    visited[v] = true;
    Console.WriteLine($"访问顶点: {v}");
    foreach (int neighbor in graph[v])
    {
        if (!visited[neighbor])
            DFS_List(graph, neighbor, visited);
    }
}
```

// 邻接矩阵实现

```csharp
void DFS_Matrix(bool[,] graph, int v, bool[] visited)
{
    visited[v] = true;
    Console.WriteLine($"访问顶点: {v}");
    int n = graph.GetLength(0);
    for (int u = 0; u < n; u++)
    {
        if (graph[v, u] && !visited[u])
            DFS_Matrix(graph, u, visited);
    }
}
```

#### 12.3.2 广度优先搜索（BFS）

// 邻接表实现

```csharp
void BFS_List(List<List<int>> graph, int start)
{
    int n = graph.Count;
    bool[] visited = new bool[n];
    Queue<int> queue = new Queue<int>();
    visited[start] = true;
    queue.Enqueue(start);
    while (queue.Count > 0)
    {
        int v = queue.Dequeue();
        Console.WriteLine($"访问顶点: {v}");
        foreach (int neighbor in graph[v])
        {
            if (!visited[neighbor])
            {
                visited[neighbor] = true;
                queue.Enqueue(neighbor);
            }
        }
    }
}
```

// 邻接矩阵实现

```csharp
void BFS_Matrix(bool[,] graph, int start)
{
    int n = graph.GetLength(0);
    bool[] visited = new bool[n];
    Queue<int> queue = new Queue<int>();
    visited[start] = true;
    queue.Enqueue(start);
    while (queue.Count > 0)
    {
        int v = queue.Dequeue();
        Console.WriteLine($"访问顶点: {v}");
        for (int u = 0; u < n; u++)
        {
            if (graph[v, u] && !visited[u])
            {
                visited[u] = true;
                queue.Enqueue(u);
            }
        }
    }
}
```

#### 12.3.3 Dijkstra最短路径算法（加权无向图）

// 邻接表实现（需要权重信息，示例为int权重）

```csharp
int[] Dijkstra_List(List<List<(int to, int weight)>> graph, int start)
{
    int n = graph.Count;
    int[] dist = new int[n];
    bool[] visited = new bool[n];
    for (int i = 0; i < n; i++) dist[i] = int.MaxValue;
    dist[start] = 0;
    var pq = new PriorityQueue<int, int>();
    pq.Enqueue(start, 0);
    while (pq.Count > 0)
    {
        int u = pq.Dequeue();
        if (visited[u]) continue;
        visited[u] = true;
        foreach (var (v, w) in graph[u])
        {
            if (!visited[v] && dist[u] + w < dist[v])
            {
                dist[v] = dist[u] + w;
                pq.Enqueue(v, dist[v]);
            }
        }
    }
    return dist;
}
```

// 邻接矩阵实现（int权重，0表示无边）

```csharp
int[] Dijkstra_Matrix(int[,] graph, int start)
{
    int n = graph.GetLength(0);
    int[] dist = new int[n];
    bool[] visited = new bool[n];
    for (int i = 0; i < n; i++) dist[i] = int.MaxValue;
    dist[start] = 0;
    for (int i = 0; i < n; i++)
    {
        int u = -1, min = int.MaxValue;
        for (int j = 0; j < n; j++)
        {
            if (!visited[j] && dist[j] < min)
            {
                min = dist[j];
                u = j;
            }
        }
        if (u == -1) break;
        visited[u] = true;
        for (int v = 0; v < n; v++)
        {
            if (graph[u, v] > 0 && dist[u] + graph[u, v] < dist[v])
            {
                dist[v] = dist[u] + graph[u, v];
            }
        }
    }
    return dist;
}
```

#### 12.3.4 拓扑排序（有向无环图）

// 邻接表实现

```csharp
List<int> TopoSort_List(List<List<int>> graph)
{
    int n = graph.Count;
    int[] indegree = new int[n];
    foreach (var edges in graph)
        foreach (var v in edges)
            indegree[v]++;
    Queue<int> queue = new Queue<int>();
    for (int i = 0; i < n; i++)
        if (indegree[i] == 0) queue.Enqueue(i);
    List<int> result = new List<int>();
    while (queue.Count > 0)
    {
        int u = queue.Dequeue();
        result.Add(u);
        foreach (int v in graph[u])
        {
            if (--indegree[v] == 0)
                queue.Enqueue(v);
        }
    }
    return result;
}
```

// 邻接矩阵实现

```csharp
List<int> TopoSort_Matrix(bool[,] graph)
{
    int n = graph.GetLength(0);
    int[] indegree = new int[n];
    for (int u = 0; u < n; u++)
        for (int v = 0; v < n; v++)
            if (graph[u, v]) indegree[v]++;
    Queue<int> queue = new Queue<int>();
    for (int i = 0; i < n; i++)
        if (indegree[i] == 0) queue.Enqueue(i);
    List<int> result = new List<int>();
    while (queue.Count > 0)
    {
        int u = queue.Dequeue();
        result.Add(u);
        for (int v = 0; v < n; v++)
        {
            if (graph[u, v] && --indegree[v] == 0)
                queue.Enqueue(v);
        }
    }
    return result;
}
```

### 12.4 性能特点

1. 优点：

   - 邻接矩阵：
     - 查找边的时间复杂度为O(1)
     - 适合稠密图
   - 邻接表：
     - 空间效率高
     - 适合稀疏图
     - 遍历邻接点效率高
2. 缺点：

   - 邻接矩阵：
     - 空间复杂度为O(V²)
     - 不适合稀疏图
   - 邻接表：
     - 查找边的时间复杂度为O(E)
     - 删除边操作较慢

### 12.5 最佳实践

1. 使用场景选择：

   - 邻接矩阵：
     - 图较稠密
     - 需要频繁查找边
     - 顶点数量较少
   - 邻接表：
     - 图较稀疏
     - 需要频繁遍历邻接点
     - 顶点数量较多
2. 实现建议：

   - 根据实际需求选择合适的表示方法
   - 考虑使用优先队列优化Dijkstra算法
   - 注意处理有向图和无向图的区别
   - 合理处理权重和距离的计算
3. 常见错误：

   - 忘记处理自环
   - 混淆有向图和无向图
   - 权重计算错误
   - 访问已访问的顶点
4. 优化技巧：

   - 使用优先队列优化最短路径算法
   - 使用并查集优化最小生成树算法
   - 使用动态规划优化某些路径问题
   - 考虑使用并行算法处理大规模图
