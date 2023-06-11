using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public FlockAgent agentPrefab;
    public FlockBehaviour behaviour;
    public ShowProximity showProximity;
    public GameObject playerObj;

    List<FlockAgent> agents = new List<FlockAgent>();

    const float AgentDensity = 0.08f;

    [Range(10, 250)] public int startingAgentCount = 10;
    [Range(1f, 100f)] public float driveFactor = 10f;
    [Range(1f, 100f)] public float maxSpeed = 5f;
    [Range(1f, 10f)] public float neighbourRadius = 1.5f;
    [Range(0f, 1f)] public float avoidanceRadiusMultiplier = 0.5f;

    public float newSpeed = 5f;
    public float timeStart;
    public float timeTillSpawn;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

    private float squareMaxSpeed;
    private float squareNeighbourRadius;
    private float squareAvoidanceRadius;
    private string currentFlockState;
    private Color originFlockColor;

    // Start is called before the first frame update
    void Start()
    {
        timeStart = 0f;
        timeTillSpawn = 2.0f;

        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighbourRadius = neighbourRadius * neighbourRadius;
        squareAvoidanceRadius = squareNeighbourRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        for (int i = 0; i < startingAgentCount; i++)
        {
            FlockAgent newAgent = Instantiate(agentPrefab, Random.insideUnitCircle * startingAgentCount * AgentDensity, Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)), transform);
            newAgent.name = "Agent: " + i;
            newAgent.Initialize(this);
            agents.Add(newAgent);
            originFlockColor = newAgent.GetComponentInChildren<SpriteRenderer>().color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObj.gameObject.activeInHierarchy == false)
        {
            currentFlockState = "Roaming";

            foreach (FlockAgent agent in agents)
            {
                //Debug.Log(originFlockColor);
                List<Transform> context = GetNearbyObjects(agent);

                // FOR DEMO.
                if (!showProximity.GetIsShowProximityPressed())
                {
                    agent.GetComponentInChildren<SpriteRenderer>().color = originFlockColor;
                }
                else
                {
                    agent.GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(Color.white, Color.red, context.Count / 6f);
                }

                Vector2 move = behaviour.CalculateMove(agent, context, this);
                move *= driveFactor;

                if (move.sqrMagnitude > squareMaxSpeed) move = move.normalized * newSpeed;
                
                agent.Move(move);
            }

        }
        else
        {
            currentFlockState = "Chasing Player";

            foreach (FlockAgent agent in agents)
            {
                List<Transform> context = GetNearbyObjects(agent);

                // FOR DEMO.
                if (!showProximity.GetIsShowProximityPressed())
                {
                    agent.GetComponentInChildren<SpriteRenderer>().color = originFlockColor;
                }
                else
                {
                    agent.GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(Color.white, Color.red, context.Count / 6f);
                }

                Vector2 move = behaviour.CalculateMove(agent, context, this);

                move *= driveFactor;

                if (move.sqrMagnitude > squareMaxSpeed) move = move.normalized * newSpeed;
                
                //agent.MoveToPlayer(move, playerObj);
                agent.Move(move);
            }
        }

        timeStart += Time.deltaTime;
        
        if (timeStart >= timeTillSpawn)
        {
            SpawnAgent();
            timeStart = 0;
        }
    }

    private List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighbourRadius);
        foreach (Collider2D collider in contextColliders)
        {
            if (collider != agent.AgentCollider) context.Add(collider.transform);
        }
        return context;
    }

    private void SpawnAgent()
    {
        FlockAgent newAgent = Instantiate(agentPrefab, Random.insideUnitCircle, Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)), transform);
        newAgent.Initialize(this);
        agents.Add(newAgent);
    }

    private void OnGUI()
    {
        GUILayout.Label($"<color='white'><size=40>{currentFlockState}</size></color>");
    }

    public void ShowProximity()
    {
        // FOR DEMO.
        //agent.GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(Color.white, Color.red, context.Count / 6f);
    }

    public void SetFlockSpeed(float speed)
    {
        newSpeed = speed;
    }
}
