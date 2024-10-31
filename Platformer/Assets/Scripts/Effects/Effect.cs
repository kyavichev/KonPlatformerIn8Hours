using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect
{
    public float duration = 3;
    public float timer { private set; get; }

    public bool IsActive
    {
        get
        {
            if(timer > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


    public virtual void Start()
    {
        timer = duration;
    }


    protected virtual void End()
    {
    }


    // Update is called once per frame
    public void Tick(float deltaTime)
    {
        if (timer > 0)
        {
            timer -= deltaTime;
            timer = Mathf.Max(timer, 0);

            if(timer == 0)
            {
                End();
            }
        }
    }
}
