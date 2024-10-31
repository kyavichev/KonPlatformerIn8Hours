using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetectorDebug : MonoBehaviour
{
    public GroundDetector groundDetector;

    public SpriteRenderer ground;
    public SpriteRenderer wall;

    public LineRenderer lineRenderer;


    // Update is called once per frame
    void Update()
    {
        if(groundDetector.IsGrounded())
        {
            ground.color = Color.green;
        }
        else
        {
            ground.color = Color.red;
        }

        if(groundDetector.IsTouchingWall())
        {
            wall.color = Color.green;
        }
        else
        {
            wall.color = Color.red;
        }

        lineRenderer.SetPosition(1, (Vector3)groundDetector.collisionNormal);
    }
}
