namespace Functions
{
    public class SearchFunctions
    {
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