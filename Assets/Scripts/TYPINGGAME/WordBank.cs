/*
 * Original Author: Trevor Minarik 
 * Tutorial Followed: Basic Typing Game with Unity [02] https://www.youtube.com/watch?v=tdXXW0ln_LU
 * Edited by: None
 * 
 * Description:
 *      Manages a list of words to be typed out by the user
 */

using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class WordBank : MonoBehaviour
{
    private List<string> originalWords = new List<string>()
    {
        "Apple",
        "Banana",
        "Cookie"
    };

    private List<string> workingWords = new List<string>();

    private void Awake()
    {
        ReloadWords();
    }

    private void ReloadWords()
    {
        workingWords.AddRange(originalWords);
        Shuffle(workingWords);
        ConvertToLower(workingWords);
    }

    private void Shuffle(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int random = Random.Range(i, list.Count);
            string temporary = list[i];

            list[i] = list[random];
            list[random] = temporary;
        }
    }

    private void ConvertToLower(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i] = list[i].ToLower();
        }
    }

    public string GetWord()
    {
        string newWord = string.Empty;

        // If the list of remaining words is not empty...
        if (workingWords.Count != 0)
        {
            // Take the first word out the list and save it to 'newWord'
            newWord = workingWords.First();
            workingWords.Remove(newWord);
        }
        // If the list of remaining words is empty...
        else
        {
            // Reload the words and call this function again to get a new word
            ReloadWords();
            newWord = GetWord();
        }

        return newWord;
    }
}
