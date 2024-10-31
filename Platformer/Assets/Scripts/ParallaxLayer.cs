using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class ParallaxLayer : MonoBehaviour
{
    // how large the spite is (or tilemap is)
    private float length;

    // starting x position
    private float startPosition;

    public float parallaxCoefficient;

    public GameObject cameraGameObject;



    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position.x;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer)
        {
            length = spriteRenderer.bounds.size.x;
        }

        TilemapRenderer tilemapRenderer = GetComponent<TilemapRenderer>();
        if(tilemapRenderer)
        {
            length = tilemapRenderer.bounds.size.x;
        }
    }


    // Update is called once per frame
    void Update()
    {
        float temp = cameraGameObject.transform.position.x * (1 - parallaxCoefficient); 
        float dist = cameraGameObject.transform.position.x * parallaxCoefficient;

        transform.position = new Vector3(startPosition + dist, transform.position.y, transform.position.z);

        if (temp > startPosition + length)
        {
            startPosition += length;
        }

        if(temp < startPosition - length)
        {
            startPosition -= length;
        }
    }
}
