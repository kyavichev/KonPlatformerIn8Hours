using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConditionChecker : MonoBehaviour
{
    public Collectable requiredItem;

    public int requiredCount;

    // Update is called once per frame
    void Update()
    {
        // Check if player 3 coin
        GameObject hero = GameManager.GetInstance().hero;
        if(hero)
        {
            Collector collector = hero.GetComponent<Collector>();
            int currentCount = collector.GetItemCount(requiredItem.collectableName);
            if(currentCount >= requiredCount)
            {
                GameManager.GetInstance().Win();
            }
        }
    }
}
