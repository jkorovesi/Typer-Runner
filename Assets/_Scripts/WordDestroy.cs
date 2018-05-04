using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordDestroy : MonoBehaviour {

    public GameObject wordManagerObj;
    
    private WordManager wordManager;
    private UIManager uiManager;
    private RectTransform rt;

    private void Start()
    {
        wordManagerObj = GameObject.Find("WordManager");
        uiManager = wordManagerObj.GetComponent<UIManager>();
        wordManager = wordManagerObj.GetComponent<WordManager>();
        rt = gameObject.GetComponent<RectTransform>();
    }


    // If the word reaches the end of the screen, lose a life, check if the
    // game is lost, destroy the word, and if it was the active word, remove it.
    void Update () {
		if(rt.localPosition.x <= -445)
        {
            uiManager.LivesUpdate();
            wordManager.EndGame();
            Destroy(gameObject);

            if (wordManager.hasActiveWord)
            {
                wordManager.RemoveActiveWord();
            }
            
        }

        
	}
}
