using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Cohesion")]
public class Cohesion : FilteredFlock
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, FlockManager flock)
    {
        // Player is not needed here.
        //player = null;

        if (context.Count == 0) return Vector2.zero;

        Vector2 cohesionMove = Vector2.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            cohesionMove += (Vector2)item.position;
        }

        cohesionMove /= context.Count;

        cohesionMove -= (Vector2)agent.transform.position;
        return cohesionMove;
    }
}
