using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Threat : MonoBehaviour
{
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        float angle = Random.Range(0, 2 * 3.1416f);
        float speed = Random.Range(10, 20);
        velocity = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), Mathf.Cos(angle)) * speed;
        transform.rotation = Quaternion.LookRotation(Vector3.Normalize(velocity));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Border")
        {
            velocity *= -1;
            transform.rotation = Quaternion.LookRotation(Vector3.Normalize(velocity));
        }
    }
}
