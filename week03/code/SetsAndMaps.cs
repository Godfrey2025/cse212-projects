using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
public static string[] FindPairs(string[] words)
{
    var seen = new HashSet<string>();
    var result = new List<string>();

    foreach (var word in words)
    {
        if (word.Length != 2) 
            continue; // Only handle 2-letter words

        if (word[0] == word[1])
            continue; // Skip same-letter words like "aa"

        string reversed = new string(new char[] { word[1], word[0] });

        // If we've already seen the reversed word, we found a pair
        if (seen.Contains(reversed))
        {
            result.Add($"{word} & {reversed}");
        }
        else
            {
            // Mark this word as seen
            seen.Add(word);
        }
    }

    return result.ToArray();
}

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
{
    var degrees = new Dictionary<string, int>();

    foreach (var line in File.ReadLines(filename).Skip(1)) // skip header
    {
        var fields = line.Split(",");

        if (fields.Length >= 4)
        {
            var degree = fields[3].Trim();

            if (!string.IsNullOrEmpty(degree))
            {
                if (degrees.TryGetValue(degree, out int count))
                {
                    degrees[degree] = count + 1;
                }
                else
                {
                    degrees[degree] = 1;
                }
            }
        }
    }

    return degrees;
}


    /// <summary>
    ////// <summary>
/// Determine if 'word1' and 'word2' are anagrams.
/// An anagram is when the same letters in a word are re-organized into a new word.
/// A dictionary is used to solve the problem.
/// 
/// Examples:
/// IsAnagram("CAT","ACT") would return true
/// IsAnagram("DOG","GOOD") would return false because GOOD has 2 O's
/// 
/// Important Note: When determining if two words are anagrams, you
/// should ignore any spaces. You should also ignore cases. For 
/// example, 'Ab' and 'Ba' should be considered anagrams.
/// </summary>
public static bool IsAnagram(string word1, string word2)
{
    // Normalize input: remove spaces and convert to lowercase
    word1 = word1.Replace(" ", "").ToLower();
    word2 = word2.Replace(" ", "").ToLower();

    // Quick length check
    if (word1.Length != word2.Length)
    {
        return false;
    }

    // Build frequency dictionary for word1
    Dictionary<char, int> freq1 = new Dictionary<char, int>();
    foreach (char c in word1)
    {
        if (freq1.ContainsKey(c))
            freq1[c]++;
        else
            freq1[c] = 1;
    }

    // Build frequency dictionary for word2
    Dictionary<char, int> freq2 = new Dictionary<char, int>();
    foreach (char c in word2)
    {
        if (freq2.ContainsKey(c))
            freq2[c]++;
        else
            freq2[c] = 1;
    }

    // Compare dictionaries
    if (freq1.Count != freq2.Count)
        return false;

    foreach (var kvp in freq1)
    {
        if (!freq2.ContainsKey(kvp.Key) || freq2[kvp.Key] != kvp.Value)
            return false;
    }

    return true;
}
/// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return [];
    }
}