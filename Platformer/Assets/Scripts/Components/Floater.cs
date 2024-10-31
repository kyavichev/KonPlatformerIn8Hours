using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public float speed = 1;
    public float range = 1;

    private float startPosY;
    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        startPosY = transform.position.y;
        timer = 2.0f * Mathf.PI * Random.value;
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        float sinY = Mathf.Sin(timer * speed) * range;
        Vector3 position = transform.position;
        position.y = startPosY + sinY;
        transform.position = position;
    }
}
