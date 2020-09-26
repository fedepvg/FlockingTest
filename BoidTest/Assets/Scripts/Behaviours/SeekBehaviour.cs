using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekBehaviour : SteerBehaviour
{
    public List<GameObject> waypoints;
    public float minDistance;

    public override Vector3 GetForce(Boid currentBoid, List<Boid> boids)
    {
        if (!currentBoid.currentWaypoint)
            currentBoid.currentWaypoint = waypoints[0];
        for(int i = 0; i < waypoints.Count;i++)
        {
            if (waypoints[i] == currentBoid.currentWaypoint)
            {
                if(Vector3.Distance(waypoints[i].transform.position, currentBoid.transform.position) < minDistance)
                {
                    if (i == waypoints.Count - 1)
                        currentBoid.currentWaypoint = waypoints[0];
                    else
                        currentBoid.currentWaypoint = waypoints[i + 1];
                }
                Vector3 dirVector = currentBoid.currentWaypoint.transform.position - currentBoid.transform.position;
                dirVector = dirVector.normalized * currentBoid.maxSpeed;

                return dirVector * weight;
            }
        }
        return Vector3.zero;
    }
}
