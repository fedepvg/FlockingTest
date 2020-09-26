using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeBehaviour : SteerBehaviour
{
    public List<GameObject> threats;

    public override Vector3 GetForce(Boid currentBoid, List<Boid> boids)
    {
        for (int i = 0; i < threats.Count; i++)
        {
            Vector3 threatPos = threats[i].transform.position;
            if (Vector3.Distance(currentBoid.transform.position, threatPos) < currentBoid.perceptionRadius)
            {
                Vector3 dirVector = currentBoid.transform.position - threatPos;
                dirVector = dirVector.normalized * currentBoid.maxSpeed;

                return dirVector * weight;
            }
        }
        return Vector3.zero;
    }
}
