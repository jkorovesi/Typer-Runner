using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour {

    public List<Word> words;

    public WordSpawner wordSpawner;
    public WordTimer wordTimer;

    private bool hasActiveWord;
    private Word activeWord;


    private void Start()
    {

    }

    // Adds a random word to the game from the WordGenerator into the list Words.
    public void AddWord()
    {
        Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord());
        Debug.Log(word.word);

        words.Add(word);
    }


    // Checks if you have an active word. 
    // Then checks if the next letter in the activeWord is the letter you type,
    // and if it is it will remove the letter and advance to the next.
    // Else, if no active word, checks the first letter you type for a word that starts with that letter then sets it.
    // Finally if you complete the activeWord it will set activeWord to false and remove that word from the list.
    public void TypeLetter (char letter)
    {
        
        if (hasActiveWord)
        {

            if (activeWord.GetNextLetter() == letter)
            {
                activeWord.TypeLetter();
            }
        } else
        {
            foreach(Word word in words)
            {
                if (word.GetNextLetter() == letter)
                {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    break;
                }
            }
        }

        if(hasActiveWord && activeWord.WordTyped())
        {
            wordTimer.updateDelay();
            hasActiveWord = false;
            words.Remove(activeWord);
        }
    }
}
