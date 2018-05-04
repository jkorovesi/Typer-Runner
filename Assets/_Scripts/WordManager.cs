using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordManager : MonoBehaviour {

    public List<Word> words;

    public WordSpawner wordSpawner;
    public WordTimer wordTimer;
    public UIManager uiManager;
    public AudioManager audioManager;

    public Text gameOver;
    
    public bool hasActiveWord;
    private Word activeWord;


    private void FixedUpdate()
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
                audioManager.Ping();
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
            uiManager.ScoreUpdate();
            hasActiveWord = false;
            words.Remove(activeWord);
            
        }
    }

    // If the active word was the one that was destroyed at the end
    // it removes the active word from the list and sets it to null
    public void RemoveActiveWord()
    {

        if (!hasActiveWord)
        {
            return;
        }

        if(activeWord.display == null)
        {
            words.Remove(activeWord);
            hasActiveWord = false;
            activeWord = null;
        }
        

    }

    // Ends the game and triggers to destroy all words if the lives reaches 0
    public void EndGame()
    {
        if (uiManager.lives <= 0)
        {
            gameOver.enabled = true;
            DestroyAllWords();
            
            Time.timeScale = 0.0f;
        }
    }

    // Destroys all words to clear the screen on game over
    void DestroyAllWords()
    {
        GameObject[] wordObjs = GameObject.FindGameObjectsWithTag("Word");
        foreach (GameObject wordObj in wordObjs)
            GameObject.Destroy(wordObj);

        Destroy(gameObject);
    }
}
