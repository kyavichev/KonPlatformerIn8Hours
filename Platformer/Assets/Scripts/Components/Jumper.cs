using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public float jumpImpulse = 5;
    public float wallJumpImpulse = 3;
    public float wallJumpMultiplier = 1.3f;

    private new Rigidbody2D rigidbody;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    public void Jump()
    {
        rigidbody.velocity = rigidbody.velocity + new Vector2(0, jumpImpulse);
    }

    public void WallJump(Vector2 direction)
    {
        rigidbody.velocity = (direction * wallJumpImpulse) + new Vector2(0, jumpImpulse * wallJumpMultiplier);
    }
}
