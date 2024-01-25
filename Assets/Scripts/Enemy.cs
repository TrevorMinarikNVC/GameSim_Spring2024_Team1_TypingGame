using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour

{
    public float speed = 3f;
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;
    private Transform target;


    private void Update() // Move towards player
    {
        if (target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
    }

    private void OnCollisionStay2D(Collision2D other) //Attack player
    {
        if(other.gameObject.tag == "Player")
        {
            if (attackSpeed <= canAttack) //Able to attack
            {
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f; //set attack on cooldown 
            }
            else 
            {
                canAttack += Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) //Detect player
    {

        if (other.gameObject.tag == "Player")
        {
            target = other.transform;

        }
    }
    private void OnTriggerExit2D(Collider2D other) //Detect player leaving 
    {
        if (other.gameObject.tag == "Player")
        {
            target = null;
        }
    }
}