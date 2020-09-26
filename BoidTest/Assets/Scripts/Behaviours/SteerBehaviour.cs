using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SteerBehaviour : MonoBehaviour
{
    [UnityEngine.Range(0, 20)]
    public float weight;
    public Slider weightSlider;

    public abstract Vector3 GetForce(Boid currentBoid, List<Boid> boids);

    public void Start()
    {
        weightSlider.value = weight;
    }
    public void Update()
    {
        if(weightSlider.value != weight)
            weight = weightSlider.value;
    }
}
