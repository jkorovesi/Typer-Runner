using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput : MonoBehaviour {

    public WordManager wordManager;


	// Update is called once per frame
	void Update () {
		
        // Inputs the letter typed into the wordmanager
        foreach (char letter in Input.inputString)
        {
            wordManager.TypeLetter(letter);
            
        }
	}
}
