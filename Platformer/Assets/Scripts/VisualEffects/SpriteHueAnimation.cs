using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHueAnimation : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float speed = 1;


    // Update is called once per frame
    void Update()
    {
        float hue = (Time.timeSinceLevelLoad * speed) % 1;
        Color color = Color.HSVToRGB(hue, 1, 1);
        spriteRenderer.color = color;
    }


    public void Begin()
    {
        enabled = true;
    }


    public void End()
    {
        enabled = false;
        spriteRenderer.color = Color.white;
    }
}
