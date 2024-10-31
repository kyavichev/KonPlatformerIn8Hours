using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsController : MonoBehaviour
{
    public List<Effect> effects = new List<Effect>();


    // Update is called once per frame
    void Update()
    {
        for (int i = effects.Count - 1; i >= 0; i--)
        {
            Effect effect = effects[i];
            effect.Tick(Time.deltaTime);

            if (effect.IsActive == false)
            {
                effects.RemoveAt(i);
            }
        }
    }


    public void AddEffect(Effect effect)
    {
        effects.Add(effect);
    }
}
