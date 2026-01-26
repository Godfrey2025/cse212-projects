using System;
using System.Collections.Generic;

public class DuplicateCounter
{
    // Count how many duplicates are in a collection of data.
    public static void Run()
    {
        int[] data = {
            50, 9, 24, 100, 7, 75, 93, 24, 17, 16, 97, 6, 18, 81, 48, 37, 49, 33, 60, 3, 99, 32, 88, 29, 65, 20, 35, 33,
            15, 81, 31, 93, 17, 5, 5, 79, 12, 91, 18, 31, 12, 94, 39, 98, 10, 72, 20, 79, 100, 27, 46, 28, 50, 1, 7, 14,
            // ... rest of your numbers
        };

        Console.WriteLine($"Number of items in the collection: {data.Length}");
        Console.WriteLine($"Number of duplicate occurrences: {CountDuplicates(data)}");
        Console.WriteLine($"Number of distinct values with duplicates: {CountDistinctDuplicates(data)}");
    }

    private static int CountDuplicates(int[] data)
    {
        var seen = new HashSet<int>();
        int duplicateCount = 0;

        foreach (int value in data)
        {
            if (!seen.Add(value))
            {
                duplicateCount++;
            }
        }

        return duplicateCount;
    }

    private static int CountDistinctDuplicates(int[] data)
    {
        var counts = new Dictionary<int, int>();
        foreach (int value in data)
        {
            if (!counts.ContainsKey(value))
                counts[value] = 0;
            counts[value]++;
        }

        int distinctDuplicates = 0;
        foreach (var kvp in counts)
        {
            if (kvp.Value > 1)
                distinctDuplicates++;
        }

        return distinctDuplicates;
    }
}
