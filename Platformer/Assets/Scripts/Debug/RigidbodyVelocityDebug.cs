using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyVelocityDebug : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public LineRenderer lineRenderer;


    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(1, (Vector3)rigidbody.velocity);
    }
}
