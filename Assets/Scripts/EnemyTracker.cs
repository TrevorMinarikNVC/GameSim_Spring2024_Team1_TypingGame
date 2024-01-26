/*
 * ORIGINAL AUTHOR: Trevor Minarik
 * EDITED BY: None
 * 
 * DESCRIPTION:
 *   Loads a new scene
 *   
 * DEPENDS ON:
 *   LevelChanger
 */
 
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{
    [Tooltip("Represents the number of enemies in the level. When this value reaches 0, the next scene will be loaded.")]
    public int enemyCount;
    [Tooltip("Object for transitioning levels")]
    public GoToLevel levelChanger;

    public void decreaseCount()
    {
        enemyCount--;
    }

    void Update()
    {
        if (enemyCount == 0 && levelChanger != null)
        {
            levelChanger.GetComponent<GoToLevel>().loadTheNextLevel();
        }
    }
}
