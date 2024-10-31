using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewOrientation : MonoBehaviour
{
    public Mover mover;
    public SpriteRenderer spriteRenderer;


    // Update is called once per frame
    void Update()
    {
        float speed = mover.GetSpeedX();
        if ( speed < 0 )
        {
            spriteRenderer.flipX = true;
        }
        else if (speed > 0)
        {
            spriteRenderer.flipX = false;
        }
    }


    public bool IsFlipped()
    {
        return spriteRenderer.flipX;
    }
}
