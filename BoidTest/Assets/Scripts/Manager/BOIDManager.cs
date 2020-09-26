using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOIDManager : MonoBehaviourSingleton<BOIDManager>
{
    public GameObject boidPrefab;
    public float spawnTime;
    public float spawnTimer;
    public int maxBoids;
    public BoxCollider spawnArea;
    public GameObject boidsParent;
    public List<GameObject> steerBehaviours;
    public List<Boid> boids;
    public List<GameObject> threats;
    public List<GameObject> food;
    public GameObject threatParent;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer < 0f && boids.Count < maxBoids)
        {
            Vector3 spawnPos;
            Bounds areaBounds = spawnArea.bounds;
            spawnPos.x = Random.Range(areaBounds.min.x * 0.8f, areaBounds.max.x * 0.8f);
            spawnPos.y = Random.Range(areaBounds.min.y * 0.8f, areaBounds.max.y * 0.8f);
            spawnPos.z = Random.Range(areaBounds.min.z * 0.8f, areaBounds.max.z * 0.8f);
            GameObject boid = Instantiate(boidPrefab, spawnPos, Quaternion.identity);
            boid.GetComponent<Boid>().steerBehaviours = steerBehaviours;
            boid.transform.SetParent(boidsParent.transform);
            boids.Add(boid.GetComponent<Boid>());
            spawnTimer = spawnTime;
        }
    }
}
