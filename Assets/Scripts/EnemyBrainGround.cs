using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrainGround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        // We can check the tag of the other object
        //  If it is a "Player" we will get its PlayerController component
        //  and call its TakeDamage method (passing 1 damage)

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>()?.TakeDamage(1);
        }
    }
}
