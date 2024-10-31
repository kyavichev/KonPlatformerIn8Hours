using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityApplier : MonoBehaviour
{
    public float force = 10;
    public Vector2 direction = Vector2.one;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(direction * force);
    }
}
