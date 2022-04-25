namespace DSAlgorithms.Programs.LinkedList
{
    /**
 * https://leetcode.com/problems/add-two-numbers/
 */

    public class Node
    {
        public int val;
        public Node next;
        public Node(int val = 0, Node next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Node<T>
    {
        public T val;
        public Node<T> next;

        public Node()
        {

        }
        public Node(T val , Node<T> next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
