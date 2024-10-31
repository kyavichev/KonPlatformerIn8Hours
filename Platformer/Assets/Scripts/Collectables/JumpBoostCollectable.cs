using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoostCollectable : Collectable
{
    public float jumpBoostModifier = 1;


    protected override void Collect(Collector collector)
    {
        Jumper jumper = collector.GetComponent<Jumper>();
        if (jumper != null)
        {
            jumper.jumpImpulse += jumpBoostModifier;
        }

        base.Collect(collector);
    }
}
