using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AmmoUIController : MonoBehaviour
{
    public Text ammoCountText;

    private int lastShownAmmoCount;


    // Update is called once per frame
    void Update()
    {
        int ammoCount = 0;

        GameObject hero = GameManager.GetInstance().hero;
        if (hero)
        {
            ProjectileAttacker attacker = hero.GetComponent<ProjectileAttacker>();
            ammoCount = attacker.specialAmmoCount;

            if(ammoCount != lastShownAmmoCount)
            {
                ammoCountText.text = ammoCount.ToString();
                lastShownAmmoCount = ammoCount;
            }
        }
    }
}
