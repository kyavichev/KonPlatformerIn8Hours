using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EffectDurationBarUIController : MonoBehaviour
{
    public GameObject containerGameObject;
    public Image foregroundBarImage;


    // Update is called once per frame
    void Update()
    {
        bool isVisible = false;

        GameObject hero = GameManager.GetInstance().hero;
        if(hero)
        {
            EffectsController effectsController = hero.GetComponent<EffectsController>();
            if (effectsController.effects.Count > 0)
            {
                Effect effect = effectsController.effects[0];
                float p = effect.timer / effect.duration;

                foregroundBarImage.fillAmount = p;

                isVisible = true;

                //Vector3 barScale = foregroundBarImage.transform.localScale;
                //barScale.x = p;
                //foregroundBarImage.transform.localScale = barScale;
            }
        }

        if (isVisible)
        {
            if (containerGameObject.activeSelf == false)
            {
                containerGameObject.SetActive(true);
            }
        }
        else
        {
            if (containerGameObject.activeSelf == true)
            {
                containerGameObject.SetActive(false);
            }
        }
    }
}
