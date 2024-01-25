using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    public Collider2D hitBox;

    private GameObject attackArea = default;
    [SerializeField] public float attackDamage = 10f;
    private bool attacking = false;
    private float timeToAttack = 0.25f;
    private float timer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        attacking = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) // when mouse left clicked activate 
        {
            Attack();
        }
        if (attacking)
        {
            timer += Time.deltaTime;

            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                hitBox.enabled = false;
            }
        }
    }

    private void Attack()
    {
        animator.SetTrigger("PencilAttack");
        attacking = true;
        hitBox.enabled = true;
    }
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.tag == "Enemy")
    //    {
    //        Enemy enemy = other.gameObject.GetComponent<Enemy>();
    //        enemy.TakeDamage(attackDamage);
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("enemy Attacked");
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(attackDamage);
        }
    }
}

