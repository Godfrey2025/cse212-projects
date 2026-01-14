using System;
using System.Collections.Generic;

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
        // Step 1: Create an array to hold the multiples
        double[] result = new double[length];

        // Step 2: Loop through 'length' times
        for (int i = 0; i < length; i++)
        {
            // Step 3: Calculate the multiple and store it
            result[i] = number * (i + 1);
        }

        // Step 4: Return the completed array of multiples
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    public static void RotateListRight(List<int> data, int amount)

    // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

    {
        // Step 1: Determine where to split the list.
        // Rotating right means the last "amount" values
        // will move to the front of the list.
        int splitIndex = data.Count - amount;

        // Step 2: Get the portion of the list that will move to the front.
        // This takes the last "amount" values from the list.
        List<int> rightPart = data.GetRange(splitIndex, amount);

        // Step 3: Get the remaining portion of the list.
        // This takes the values from the start of the list
        // up to the split index.
        List<int> leftPart = data.GetRange(0, splitIndex);

        // Step 4: Clear the original list so we can rebuild it in rotated order.
        data.Clear();

        // Step 5: Add the right portion first (rotated to the front),
        // followed by the left portion.
        data.AddRange(rightPart);
        data.AddRange(leftPart);
    }
}