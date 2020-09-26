using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CohesionSteerBehaviour : SteerBehaviour
{
    // Start is called before the first frame update
    public override Vector3 GetForce(Boid currentBoid, List<Boid> boids)
    {
        Vector3 desiredVelocity = Vector3.zero;
        int neighborsCount = 0;

        foreach (Boid b in boids)
        {
            if (b == this)
                continue;

            Vector3 diff = currentBoid.transform.position - b.transform.position;
            float dist = diff.magnitude;

            if (dist < currentBoid.perceptionRadius)
            {
                desiredVelocity += b.transform.position;
                neighborsCount++;
            }
        }

        if (neighborsCount > 0)
        {
            //desiredVelocity /= neighborsCount;
            //desiredVelocity -= currentBoid.transform.position;
            desiredVelocity = desiredVelocity.normalized * currentBoid.maxSpeed;
            return desiredVelocity * weight;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
