using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public LayerMask collisionMask;

    private bool isGrounded = false;
    private bool isTouchingWall = false;

    public Vector2 collisionNormal { protected set; get; }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        ProcessCollision(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        ProcessCollision(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        isTouchingWall = false;
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }

    public bool IsTouchingWall()
    {
        return isTouchingWall;
    }

    private void ProcessCollision(Collision2D collision)
    {
        if (((1 << collision.collider.gameObject.layer) & collisionMask) != 0)
        {
            foreach(ContactPoint2D contact in collision.contacts)
            {
                if(contact.normal.y > 0f)
                {
                    isGrounded = true;
                }

                if(Mathf.Abs(contact.normal.x) > 0f)
                {
                    // Store collision normal for later. This will help us wall jump.
                    collisionNormal = contact.normal;

                    isTouchingWall = true;
                }
            }
        }
    }
}
