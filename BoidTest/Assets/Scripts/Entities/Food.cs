using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float lifespan;
    void Start()
    {
        Destroy(gameObject, lifespan);
    }

    private void OnDestroy()
    {
        BOIDManager.Instance.food.Remove(gameObject);
    }
}
