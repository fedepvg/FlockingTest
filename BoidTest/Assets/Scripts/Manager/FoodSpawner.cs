using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public GameObject foodParent;
    public BoxCollider spawnArea;
    public float spawnCooldown;
    float spawnTimer = 0;

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= spawnCooldown)
        {
            spawnTimer = 0;

            Vector3 spawnPos;
            Bounds areaBounds = spawnArea.bounds;
            spawnPos.x = Random.Range(areaBounds.min.x * 0.8f, areaBounds.max.x * 0.8f);
            spawnPos.y = Random.Range(areaBounds.min.y * 0.8f, areaBounds.max.y * 0.8f);
            spawnPos.z = Random.Range(areaBounds.min.z * 0.8f, areaBounds.max.z * 0.8f);
            GameObject food = Instantiate(foodPrefab, spawnPos, foodPrefab.transform.rotation);
            food.transform.SetParent(foodParent.transform);
            BOIDManager.Instance.food.Add(food);
        }
    }
}
