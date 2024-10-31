using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DampenedCameraFollower : MonoBehaviour
{
    public float damping = 0.05f;

    private Vector3 offset;
    private Vector3 velocity;


    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject hero = GameManager.GetInstance().hero;
        if (hero)
        {
            Vector3 targetPosition = hero.transform.position + offset;

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, damping);
        }
    }
}
