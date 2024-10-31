using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardCheater : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            GameObject hero = GameManager.GetInstance().hero;
            Destructible destructible = hero.GetComponent<Destructible>();
            destructible.TakeDamage(1);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            GameObject hero = GameManager.GetInstance().hero;
            ProjectileAttacker attacker = hero.GetComponent<ProjectileAttacker>();
            attacker.GiveAmmo(10, ProjectileAttacker.AttackType.Fire);
        }
    }
}
