using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollower : MonoBehaviour
{
    private Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        GameObject hero = GameManager.GetInstance().hero;
        if(hero)
        {
            transform.position = hero.transform.position + offset;
        }
    }
}
