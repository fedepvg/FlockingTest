using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignmentSteerBehaviour : SteerBehaviour
{
    public override Vector3 GetForce(Boid currentBoid, List<Boid> boids)
    {
        Vector3 desired_velocity = Vector3.zero;
        int neighbors_count = 0;

        foreach (Boid b in boids)
        {
            if (b == this)
                continue;

            Vector3 diff = currentBoid.transform.position - b.transform.position;
            float dist = diff.magnitude;

            if (dist < currentBoid.perceptionRadius)
            {
                desired_velocity += b.velocity;
                neighbors_count++;
            }
        }

        if (neighbors_count > 0)
        {
            desired_velocity /= neighbors_count;
            desired_velocity = desired_velocity.normalized * currentBoid.maxSpeed;
            return desired_velocity * weight;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
