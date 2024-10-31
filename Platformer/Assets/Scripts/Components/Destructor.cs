using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// a Destructor causes damage to a Destructible when they touch

public class Destructor : MonoBehaviour
{
    public int damagePoints = 1;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destructible destructible = collision.collider.gameObject.GetComponent<Destructible>();
        if(destructible)
        {
            destructible.TakeDamage(damagePoints);
        }
    }
}
