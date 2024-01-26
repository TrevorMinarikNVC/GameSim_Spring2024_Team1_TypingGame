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

    public void loadTheNextLevel()
    {
        int buildNum = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(buildNum);
    }
}
