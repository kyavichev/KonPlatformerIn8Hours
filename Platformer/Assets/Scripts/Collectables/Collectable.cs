using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class Collectable : MonoBehaviour
{
    public enum CollectableType
    {
        Consumable,
        Storable,
    }

    public CollectableType collectableType;
    public string collectableName;


    protected virtual void Collect(Collector collector)
    {
        collector.Collect(this);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collected with " + collision.gameObject.name);

        Collector collector = collision.gameObject.GetComponent<Collector>();
        if(collector)
        {
            Collect(collector);
        }
    }
}
