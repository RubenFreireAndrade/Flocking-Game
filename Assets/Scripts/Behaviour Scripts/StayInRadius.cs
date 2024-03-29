using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/StayInRadius")]
public class StayInRadius : FlockBehaviour
{
    public Vector2 center;
    public float radius = 15f;

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, FlockManager flock)
    {
        // Player is not needed here.
        //player = null;

        Vector2 centerOffset = center - (Vector2)agent.transform.position;
        float t = centerOffset.magnitude / radius;
        if (t < 0.9f)
        {
            return Vector2.zero;
        }

        return centerOffset * t * t;
    }    
}
