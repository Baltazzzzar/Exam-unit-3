using System.Text.Json;

namespace TaskFunctions
{
    public class Task2Function
    {
        public List<int> FlattenJaggedArray(JsonElement jaggedArray)
        {
            List<int> flattenedArray = new List<int>();
            if (jaggedArray.ValueKind == JsonValueKind.Array)
            {
                foreach (var item in jaggedArray.EnumerateArray())
                {
                    List<int> sublist = FlattenJaggedArray(item);
                    foreach (int number in sublist)
                    {
                        flattenedArray.Add(number);
                    }
                }
            }
            else if (jaggedArray.ValueKind == JsonValueKind.Number)
            {
                int number = int.Parse(jaggedArray.ToString());
                flattenedArray.Add(number);
            }
            return flattenedArray;
        }
    }
}