/*
 * -------Movement with Physics (Rigidbody2D) and Keys------
 * ---This script uses physics, the velocity attached to a rigidbody2d, to move the character.
 * ---This script requires that the player have a collider2d (circle, box, polygon) and a rigidbody2D.
 * ---If you are doing a top down, you will need to turn the gravity scale to 0 under the rigidbody2D
 *    panel in the inspector.
 * ---Because the Physics2D engine still takes into account the Z axis, you're going to want to 
 *    Open the Constraints section of the Rigidbody2D panel in the Inspector and click "Freeze Roation"
 *    for the Z axis.
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKeysRigidBody : MonoBehaviour
{
    public Rigidbody2D theRB; //this is your rigidbody. Drag it from your Inspector down to the script area
    public float moveSpeed = 2f; //So you can adjust the speed on the fly
    // Start is called before the first frame update
    Animator animate;

    void Start()
    {
        animate = gameObject.GetComponent<Animator>();
    }

    // Physics calculations are always done in FixedUpdate
    void FixedUpdate()
    {
        //take the input value of the horizontal and vertical controls (keys or joystick) and multiply by the movespeed
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;

        //you could control this with individual keys and use 1 for moving right or up and -1 for moving down or left.
        //after doing your individual settings, you could then set the whole thing. Look at the non physics examples 
        //for some ideas on how to do that.
        animate.SetFloat("moveY", theRB.velocity.y);
        animate.SetFloat("moveX", theRB.velocity.x);
    }
}
