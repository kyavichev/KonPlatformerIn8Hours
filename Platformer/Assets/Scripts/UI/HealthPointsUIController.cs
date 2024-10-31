using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPointsUIController : MonoBehaviour
{
    public GameObject[] fullHeartImages;

    private int lastUsedHealthPoints = 0;


    // Update is called once per frame
    void Update()
    {
        int healthPoints = 0;

        GameObject hero = GameManager.GetInstance().hero;
        if (hero)
        {
            Destructible destructible = hero.GetComponent<Destructible>();
            healthPoints = destructible.GetCurrentHealthPoints();
        }

        if (healthPoints != lastUsedHealthPoints)
        {
            ShowHearts(healthPoints);

            lastUsedHealthPoints = healthPoints;
        }
    }


    private void ShowHearts(int healthPoints)
    {
        // Uncomment the following line for debugging, it will print how many hearts need to be visible
        //Debug.Log("healthPoints: " + healthPoints);

        int heartCount = fullHeartImages.Length;
        // for (initializer; condition; iterator)
        // {
        //      code block 
        // }
        // 'i' is a part of the loop setup, and it should contain a new value in each iteration
        for (int i = heartCount - 1; i >= 0; i--) // i-- is the same as i = i - 1
        {
            GameObject fullHeart = fullHeartImages[i];
            if((i + 1) > healthPoints)
            {
                fullHeart.SetActive(false);
            }
            else
            {
                fullHeart.SetActive(true);
            }
        }
    }
}
