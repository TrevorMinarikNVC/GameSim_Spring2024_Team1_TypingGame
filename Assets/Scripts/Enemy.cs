using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour

{
    public AudioSource AttackSfx;
    public AudioSource walkSfx;

    public Animator animator;

    [Header("Movement")]

    public float speed = 3f;
    [Header("Attack")]
    [Header("Health")]
    
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;
    private Transform target;


    private float health;
    [SerializeField] private float maxHealth;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        Debug.Log("Enemy Health: " + health);
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Update() // Move towards player
    {
        if (target != null)
        {
            float step = speed * Time.deltaTime;
            walkSfx.Play();
            animator.SetBool("Walk", true);
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
    }

    private void OnCollisionStay2D(Collision2D other) //Attack player
    {
        animator.SetBool("Walk", false);
        walkSfx.Stop();
        animator.SetTrigger("Attack");
        AttackSfx.Play();
        if (other.gameObject.tag == "Player")
        {
            if (attackSpeed <= canAttack) //Able to attack
            {
                animator.SetTrigger("Attack");
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
            walkSfx.Stop();
            animator.SetBool("Walk", false);
            target = null;
        }
    }
}
