using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeparationSteerBehaviour : SteerBehaviour
{
    public float separationPerceptionMultiplier;

    public override Vector3 GetForce(Boid currentBoid, List<Boid> boids) 
    {
        Vector3 desiredVelocity = Vector3.zero;
        int countNeighbors = 0;

        foreach (Boid b in boids)
        {
            if (b == currentBoid)
                continue;

            Vector3 diff = currentBoid.transform.position - b.transform.position;
            float dist = Vector3.Distance(currentBoid.transform.position, b.transform.position);

            if (dist < currentBoid.perceptionRadius * separationPerceptionMultiplier)
            {
                countNeighbors++;
                desiredVelocity = desiredVelocity + Vector3.Normalize(diff) / Mathf.Pow(dist, 2);
            }
        }

        if (countNeighbors > 0)
        {
            return desiredVelocity.normalized * currentBoid.maxSpeed * weight;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
