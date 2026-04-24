class Recursion
{
   public int CountOccurrences(int[] array, int value, int index = 0)
    {
        if (index >= array.Length) return 0;
        int current;
        if (array[index] == value)
        {
            current = 1;
        }
        else
        {
            current = 0;
        }
        return current + CountOccurrences(array, value, index + 1);
    }
}