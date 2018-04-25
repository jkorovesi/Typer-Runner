using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour {

    public Text text;
    public float fallSpeed = 1f;


    public void SetWord (string word)
    {
        text.text = word;
    }

    // Remove the letter as typed and set active word color to red
    public void RemoveLetter()
    {
        text.text = text.text.Remove(0, 1);
        text.color = Color.red;
    }

    // Destroy completed word
    public void RemoveWord()
    {
        Destroy(gameObject);

    }

    // Scroll the words from right to left
    private void Update()
    {
        transform.Translate(-fallSpeed * Time.deltaTime, 0f, 0f);
    }
}
