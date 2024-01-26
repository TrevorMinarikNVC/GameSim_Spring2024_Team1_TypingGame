/*
 * ORIGINAL AUTHOR: Trevor Minarik 
 * TUTORIAL FOLLOWED: Basic Typing Game with Unity [01] https://www.youtube.com/watch?v=j98a_X9G1fM
 * EDITED BY: Makayla Esparza
 * 
 * DESCRIPTION:
 *   Handles getting which keys are being pressed and erasing letters that the user has already typed
 * 
 * DEPENDS ON:
 *   WordBank.cs
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typer3 : MonoBehaviour
{

    public AudioSource noise;



    [Tooltip("List of words to be typed by the player")]
    public WordBank2 wordBank2 = null;
    [Tooltip("Shows the remaining letters in the word that the player is typing")]
    public Text wordOutput = null;

    private string remainingWord = string.Empty;    // Holds the remaining letters of 'currentWord' that still need to be typed
    private string currentWord = string.Empty;      // Holds the full, unaltered word that needs to by typed

    // Start is called before the first frame update
    private void Start()
    {
        SetCurrentWord();
    }

    private void SetCurrentWord()
    {
        currentWord = wordBank2.GetWord();
        SetRemainingWord(currentWord);
    }

    private void SetRemainingWord(string newString)
    {
        // Updates the remaining word
        remainingWord = newString;
        // Displays the new remaining word to the text box
        wordOutput.text = remainingWord;
    }

    // Update is called once per frame
    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.anyKeyDown)
        {

            noise.Play();

            // Get keys pressed down on current frame as a string
            string keysPressed = Input.inputString;

            // Check for multiple keys being pressed during the frame
            // Only enter the letter if one key is being pressed during the frame
            if (keysPressed.Length == 1)
            {
                EnterLetter(keysPressed);
            }
        }
    }

    private void EnterLetter(string typedLetter)
    {
        // If the correct letter has been typed remove the letter from the remaining word
        if (IsCorrectLetter(typedLetter))
        {
            RemoveLetter();

            // If the whole word has been typed, get another word from the word bank
            if (IsWordComplete())
            {
                SetCurrentWord();
            }
        }
    }

    private bool IsCorrectLetter(string letter)
    {
        // Check to see if the given letter is the same as the first letter in the remaining word
        return (remainingWord.IndexOf(letter) == 0);
    }

    private void RemoveLetter()
    {
        // Remove the first letter in the remaining word
        string newString = remainingWord.Remove(0, 1);
        SetRemainingWord(newString);
    }

    private bool IsWordComplete()
    {
        // Return true if the remaining word is empty
        return (remainingWord.Length == 0);
    }
}
