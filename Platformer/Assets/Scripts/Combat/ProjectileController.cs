using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public int damage = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Do damage
        Destructible destructible = collision.gameObject.GetComponent<Destructible>();
        if(destructible)
        {
            destructible.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
