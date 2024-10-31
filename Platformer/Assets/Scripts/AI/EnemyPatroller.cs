using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatroller : MonoBehaviour
{
    public Mover controlledMover;

    public float maxDistance = 1;
    public Vector2 direction = new Vector2(-1, 0);

    private Vector3 startPosition;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        controlledMover.AccelerateInDirection(direction);

        float distance = Vector3.Distance(startPosition, transform.position);
        if(distance > maxDistance)
        {
            direction.x = startPosition.x - transform.position.x;
            direction.Normalize();
        }
    }
}
