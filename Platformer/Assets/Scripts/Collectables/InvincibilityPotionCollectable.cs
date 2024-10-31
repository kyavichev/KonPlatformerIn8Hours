using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityPotionCollectable : Collectable
{
    public int duration = 3;

    protected override void Collect(Collector collector)
    {
        EffectsController effectsController = collector.GetComponent<EffectsController>();
        if(effectsController)
        {
            InvincibilityEffect effect = new InvincibilityEffect();
            effect.duration = duration;

            effectsController.AddEffect(effect);

            effect.Start();
        }

        base.Collect(collector);
    }
}
