using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour {

    // Array of words
    private static string[] wordList = {"potato", "mom", "dad", "sister", "brother", "children", "simple", "trying", "fail", "success", "unicorn", "dragon", "elder", "lich",
                                        "skeleton", "sans", "gas", "king", "queen", "master"};



    // Take a random word from the array and set it to randomWord variable, then return it.
    public static string GetRandomWord()
    {

        int randomIndex = Random.Range(0, wordList.Length);
        string randomWord = wordList[randomIndex];

        return randomWord;
    }

}
