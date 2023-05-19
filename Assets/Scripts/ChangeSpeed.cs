using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeed : MonoBehaviour
{
    public float maxSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdjustSpeed(float newSpeed)
    {
        maxSpeed = newSpeed;
    }
}
