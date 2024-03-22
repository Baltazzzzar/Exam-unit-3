namespace TaskFunctions
{
    public class Task3Functions
    {
        public int CalculateSumOfNodesValue(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return node.value + CalculateSumOfNodesValue(node.right) + CalculateSumOfNodesValue(node.left);
            }
        }
        public int CountNodes(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return 1 + CountNodes(node.right) + CountNodes(node.left);
            }
        }
        public int FindDeepestLevel(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                int leftLevel = FindDeepestLevel(node.left);
                int rightLevel = FindDeepestLevel(node.right);
                if (leftLevel > rightLevel)
                {
                    return leftLevel + 1;
                }
                else
                {
                    return rightLevel + 1;
                }
            }
        }
    }
}