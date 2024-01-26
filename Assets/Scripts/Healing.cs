using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public AudioSource JuiceSlurp;
    private void OnCollisionStay2D(Collision2D other) //Attack player
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(100f);
            Destroy(gameObject);
        }
    }
}
