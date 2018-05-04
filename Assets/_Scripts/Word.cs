using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word{

    public string word;

    // How many letters into the word you are
    private int typeIndex;

    public WordDisplay display;


    public Word(string _word, WordDisplay _display)
    {
        word = _word;
        typeIndex = 0;

        display = _display;
        display.SetWord(word);
    }

    // 
    public char GetNextLetter()
    {
        return word[typeIndex];
    }

    // Advance the index each time you type the correct letter
    public void TypeLetter()
    {
        typeIndex++;
        display.RemoveLetter();
    }

    // Check if the word has been typed. If it has, remove the active word.
    public bool WordTyped()
    {
        bool wordTyped = (typeIndex >= word.Length);
        if (wordTyped)
        {
            display.RemoveWord();
        }
        return wordTyped;
    }
	
}
