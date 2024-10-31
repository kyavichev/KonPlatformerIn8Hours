using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityEffect : Effect
{
    public override void Start()
    {
        base.Start();

        GameObject hero = GameManager.GetInstance().hero;
        if(hero)
        {
            Destructible destructible = hero.GetComponent<Destructible>();
            destructible.isInvincible = true;

            SpriteHueAnimation spriteHueAnimation = hero.GetComponentInChildren<SpriteHueAnimation>();
            spriteHueAnimation.Begin();
        }
    }


    protected override void End()
    {
        base.End();

        GameObject hero = GameManager.GetInstance().hero;
        if (hero)
        {
            Destructible destructible = hero.GetComponent<Destructible>();
            destructible.isInvincible = false;

            SpriteHueAnimation spriteHueAnimation = hero.GetComponentInChildren<SpriteHueAnimation>();
            spriteHueAnimation.End();
        }
    }
}
