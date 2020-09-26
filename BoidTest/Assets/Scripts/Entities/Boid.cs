using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public List<GameObject> steerBehaviours;
    public Vector3 velocity;
    public float perceptionRadius;
    public float maxSpeed;
    public GameObject currentWaypoint;
    public GameObject threatPrefab;
    public int foodToConvertInThreat;
    int foodCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        float angle = Random.Range(0, 2 * 3.1416f);
        float speed = Random.Range(20, 30);
        velocity = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), Mathf.Cos(angle)) * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject behaviour in steerBehaviours)
        {
            if(behaviour.GetComponent<EscapeBehaviour>())
                behaviour.GetComponent<EscapeBehaviour>().threats = BOIDManager.Instance.threats;
            else if (behaviour.GetComponent<EatBehaviour>())
                behaviour.GetComponent<EatBehaviour>().foodList = BOIDManager.Instance.food;

            velocity += behaviour.GetComponent<SteerBehaviour>().GetForce(this, BOIDManager.Instance.boids);
        }

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        transform.position += velocity * Time.deltaTime;
        gameObject.transform.rotation = Quaternion.LookRotation(Vector3.Normalize(velocity));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Border")
            velocity *= -1;
        else if (other.tag == "Food")
        {
            foodCount++;
            BOIDManager.Instance.food.Remove(other.gameObject);
            Destroy(other.gameObject);
            if (foodCount >= foodToConvertInThreat)
            {
                GameObject threat = Instantiate(threatPrefab, transform);
                threat.transform.SetParent(BOIDManager.Instance.threatParent.transform);
                BOIDManager.Instance.threats.Add(threat);
                BOIDManager.Instance.boids.Remove(this);
                Destroy(gameObject);
            }
        }
    }
}
