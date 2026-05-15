public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // My plan:
        // 1. I need to create an array that will hold 'length' number of items
        // 2. Loop through each position in the array
        // 3. At each position i, the value should be number * (i + 1)
        //    because i starts at 0, so I add 1 to get the first multiple right
        //    e.g. number=7, i=0 → 7*1=7, i=1 → 7*2=14, etc.
        // 4. Return the filled array

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // My plan:
        // "Rotate right by 3" on {1,2,3,4,5,6,7,8,9} gives {7,8,9,1,2,3,4,5,6}
        // So the last 'amount' items jump to the front
        //
        // 1. Find where to split the list
        //    splitIndex = data.Count - amount
        //    e.g. 9 items, amount=3 → splitIndex = 6
        //
        // 2. Grab the two pieces:
        //    tail = items from splitIndex to end  → {7, 8, 9}
        //    head = items from 0 to splitIndex    → {1, 2, 3, 4, 5, 6}
        //
        // 3. Clear the original list, then put tail first, head second
        //    result → {7, 8, 9, 1, 2, 3, 4, 5, 6}

        int splitIndex = data.Count - amount;

        List<int> tail = data.GetRange(splitIndex, amount);
        List<int> head = data.GetRange(0, splitIndex);

        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);
    }
}