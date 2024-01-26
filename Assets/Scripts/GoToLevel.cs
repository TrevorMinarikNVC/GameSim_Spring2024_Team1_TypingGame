/*
 * ORIGINAL AUTHOR: ???
 * TUTORIAL FOLLOWED: Pat Sipes
 * EDITED BY: Trevor Minarik
 * 
 * DESCRIPTION:
 *   Loads a new scene
 */
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //adds scene control

public class GoToLevel : MonoBehaviour
{
    //method takes build index (integer) and loads that scene
    public void loadTheLevel(int buildNum)
    {
        SceneManager.LoadScene(buildNum);
    }

    // Loads the next level according to the build list
    public void loadTheNextLevel()
    {
        int buildNum = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(buildNum);
    }
}
