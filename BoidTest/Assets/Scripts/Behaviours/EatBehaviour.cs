using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatBehaviour : SteerBehaviour
{
    public List<GameObject> foodList;
    public override Vector3 GetForce(Boid currentBoid, List<Boid> boids)
    {
        for (int i = 0; i < foodList.Count; i++)
        {
            Vector3 foodPos = foodList[i].transform.position;
            if (Vector3.Distance(currentBoid.transform.position, foodPos) < currentBoid.perceptionRadius)
            {
                Vector3 dirVector = foodPos - currentBoid.transform.position;
                dirVector = dirVector.normalized * currentBoid.maxSpeed;

                return dirVector * weight;
            }
        }
        return Vector3.zero;
    }
}
