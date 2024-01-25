using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthCode : MonoBehaviour
{
    private float enemyHealth = 0f;
    [SerializeField] private float enemyMaxHealth = 100f;


    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = enemyMaxHealth;
    }

    // Update is called once per frame
    public void UpdateEnemyHealth(float mod)
    {
        enemyHealth += mod;
        if (enemyHealth > enemyMaxHealth) //caping at max health
        {
            enemyHealth = enemyMaxHealth;
        }
        else if (enemyHealth <= 0f) //Player dies and needs to respawn
        {
            enemyHealth = 0f;
            Destroy(gameObject);
            Debug.Log("Enemy Dead");
        }
    }
}
