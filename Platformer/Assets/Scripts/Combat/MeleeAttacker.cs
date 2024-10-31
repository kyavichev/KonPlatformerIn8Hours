using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttacker : MonoBehaviour
{
    public Animator animator;

    public GameObject attackPoint;

    public float attackRadius = 0.5f;
    public LayerMask enemyMask;

    // Kicks off animation
    public void Attack()
    {
        animator.SetTrigger("MeleeAttack");
    }

    // Deals damage
    public void DoAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRadius, enemyMask);
        if(colliders.Length > 0)
        {
            Debug.Log("We have a hit!");
            foreach(Collider2D collider in colliders)
            {
                Destructible enemyDestructible = collider.gameObject.GetComponent<Destructible>();
                enemyDestructible.TakeDamage(1);
            }
        }
    }
}
