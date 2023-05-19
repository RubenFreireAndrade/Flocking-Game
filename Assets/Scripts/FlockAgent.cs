using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Collider2D))]

public class FlockAgent : MonoBehaviour
{
    FlockManager agentFlock;
    public FlockManager AgentFlock { get { return agentFlock; } }

    Collider2D agentCollider;
    public Collider2D AgentCollider { get { return agentCollider; } }

    // Start is called before the first frame update
    void Start()
    {
        agentCollider = GetComponent<Collider2D>();
    }

    public void Initialize(FlockManager flock)
    {
        agentFlock = flock;
    }

    public Vector2 Move(Vector2 velocity)
    {
        transform.up = velocity;
        return transform.position += (Vector3)velocity * Time.deltaTime;
    }

    public void MoveToPlayer(Vector2 velocity, GameObject playerTarget)
    {
        transform.up = velocity;
        transform.position = Vector2.MoveTowards(transform.position, playerTarget.transform.position, (velocity.x * velocity.y) * Time.deltaTime);
        //playerObj.transform.position += (Vector3)velocity * Time.deltaTime;
    }
}
