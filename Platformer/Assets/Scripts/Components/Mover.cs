using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float acceleration = 10f;
    public float maxSpeed = 20f;
    public float minSpeed = 0.1f;

    public Animator animator;
    private new Rigidbody2D rigidbody;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        ClampVelocity();

        if (animator)
        {
            animator.SetFloat("speed", Mathf.Abs(GetSpeedX()));
        }
    }


    public void AccelerateInDirection(Vector2 direction)
    {
        Vector3 newVelocity = rigidbody.velocity + direction * acceleration * Time.deltaTime;
        newVelocity.x = Mathf.Clamp(newVelocity.x, -maxSpeed, maxSpeed);
        rigidbody.velocity = newVelocity;
    }


    public float GetSpeedX()
    {
        return rigidbody.velocity.x;
    }


    protected void ClampVelocity()
    {
        Vector3 newVelocity = rigidbody.velocity;
        newVelocity.x = Mathf.Clamp(newVelocity.x, -maxSpeed, maxSpeed);
        rigidbody.velocity = newVelocity;
    }
}
