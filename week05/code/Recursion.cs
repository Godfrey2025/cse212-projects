using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base Case
        if (n <= 0)
            return 0;
        // Recursive Case
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
{
    // Base case: permutation is complete
    if (word.Length == size)
    {
        results.Add(word);
        return;
    }

    // Try choosing each letter
    for (int i = 0; i < letters.Length; i++)
    {
        char chosen = letters[i];

        // Remove chosen letter from remaining letters
        string remaining =
            letters[..i] + letters[(i + 1)..];

        // Recurse with updated word
        PermutationsChoose(
            results,
            remaining,
            size,
            word + chosen
        );
    }
}

    // TODO Start Problem 2

    /// <summary>
    /// #############
/// # Problem 3 #
    /// #############
    /// A child is running up a staircase with n steps and can hop either 1 step, 2 steps, or 3 steps at a time.  
    /// Implement a method to count how many possible ways the child can run up the stairs.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
{
    // Initialize dictionary if first call
    if (remember == null)
        remember = new Dictionary<int, decimal>();

    // Check memoized result
    if (remember.ContainsKey(s))
        return remember[s];

    // Base cases
    if (s == 0) return 0;
    if (s == 1) return 1;
    if (s == 2) return 2;
    if (s == 3) return 4;

    // Recursive calculation WITH memoization
    decimal ways =
        CountWaysToClimb(s - 1, remember) +
        CountWaysToClimb(s - 2, remember) +
        CountWaysToClimb(s - 3, remember);

    // Store result
    remember[s] = ways;

    return ways;
}


    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // Find the index of the first wildcard
        int index = pattern.IndexOf('*');
        // Base Case: If there are no wildcards, add the pattern to results
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }
        // Replace the wildcard with '0' and '1' and recurse
        WildcardBinary(pattern[..index] + '0' + pattern[(index + 1)..], results);
        WildcardBinary(pattern[..index] + '1' + pattern[(index + 1)..], results);

        // TODO Start Problem 4
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        if (currPath == null) {
            currPath = new List<ValueTuple<int, int>>();
        }
        
        // currPath.Add((1,2)); // Use this syntax to add to the current path

        // TODO Start Problem 5
        // ADD CODE HERE

        // results.Add(currPath.AsString()); // Use this to add your path to the results array keeping track of complete maze solutions when you find the solution.
    }
}