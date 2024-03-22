using System.Text.Json;

namespace Functions
{
    public class MathFunctions
    {
        public double Square(double numberToSquare)
        {
            return numberToSquare * numberToSquare;
        }
        public double Root(double numberToRoot)
        {
            return Math.Sqrt(numberToRoot);
        }
        public double Cube(double numberToCube)
        {
            return numberToCube * numberToCube * numberToCube;
        }
        public double AreaOfCircle(double radius)
        {
            return Math.PI * radius * radius;
        }
        public double InchToMm(double inch)
        {
            return inch * 25.4;
        }
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

    }
}