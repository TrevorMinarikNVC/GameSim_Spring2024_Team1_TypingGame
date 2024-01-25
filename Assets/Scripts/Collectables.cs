using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CollectObj;
    public float health = 100f;
    public Transform transform;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health<=0)
        {
            public void Die()
            {
                Destroy(gameObject); //destroys game obj
                DropCollectable(); //Drops collectable
            }

            void DropCollectable()
            {
                Vector3 position = transform.position; //position of enemy
                GameObject Collectable = Instantiate(CollectObj, position, Quaternion.identity); //colllectable drop
                
            }

        }
    }
}
