using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Mover controlledMover;
    public Jumper controlledJumper;
    public GroundDetector groundDetector;
    public ProjectileAttacker controlledAttacker;
    public MeleeAttacker meleeAttacker;

    public float cooldown = 0.5f;
    private float timer = 0;


    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            timer = Mathf.Max(timer, 0);
            return;
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            controlledMover.AccelerateInDirection(new Vector2(-1, 0));
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            controlledMover.AccelerateInDirection(new Vector2(1, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (groundDetector.IsGrounded())
            {
                controlledJumper.Jump();
            }
            else if (groundDetector.IsTouchingWall())
            {
                // Get collision normal that was saved during collision enter event
                Vector2 collisionNormal = groundDetector.collisionNormal;
                Vector2 direction = collisionNormal.normalized;
                // Jump in the direction of the normal (and up)
                controlledJumper.WallJump(direction);
                timer = cooldown;
            }
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            controlledAttacker.Fire();
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            meleeAttacker.Attack();
        }
    }
}
