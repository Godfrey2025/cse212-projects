using System;
using System.Collections.Generic;

public class Translator
{
    public static void Run()
    {
        var englishToGerman = new Translator();
        englishToGerman.AddWord("House", "Haus");
        englishToGerman.AddWord("Car", "Auto");
        englishToGerman.AddWord("Plane", "Flugzeug");

        Console.WriteLine(englishToGerman.Translate("Car"));    // Auto
        Console.WriteLine(englishToGerman.Translate("Plane"));  // Flugzeug
        Console.WriteLine(englishToGerman.Translate("Train"));  // ???
    }

    private Dictionary<string, string> _words = new();

    /// <summary>
    /// Add the translation from 'fromWord' to 'toWord'
    /// For example, in an English to German dictionary:
    /// my_translator.AddWord("book","buch")
    /// </summary>
    public void AddWord(string fromWord, string toWord)
    {
        // Store the translation in the dictionary
        _words[fromWord] = toWord;
    }

    /// <summary>
    /// Translates the fromWord into the word that this stores as the translation
    /// </summary>
    public string Translate(string fromWord)
    {
        // Return translation if available, otherwise "???"
        if (_words.ContainsKey(fromWord))
        {
            return _words[fromWord];
        }
        else
        {
            return "???";
        }
    }
}
