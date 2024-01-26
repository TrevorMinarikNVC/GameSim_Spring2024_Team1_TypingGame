using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public AudioSource JuiceSlurp;
    public float health = 0f;
    [SerializeField] public float maxHealth = 100f;

private void Start() //Game starts with max Health
{
    health = maxHealth;
}
 public void UpdateHealth(float mod) // Updates health by adding or subtracting
    {
        health += mod;

        if (health > maxHealth) //caping at max health
        {
            JuiceSlurp.Play();
            health = maxHealth;
        }
        else if (health <= 0f) //Player dies and needs to respawn
        {
            health = 0f;
            Destroy(gameObject);
            Debug.Log("Player Respawn");  
            
        }
    }
}
