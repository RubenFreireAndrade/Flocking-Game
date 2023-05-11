using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public GameObject playerObj;
    private bool isPlayerActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetObjectActive(bool isObjectActive)
    {
        isPlayerActive = isObjectActive;
        playerObj.SetActive(isPlayerActive);
    }

    public bool IsPlayerActive()
    {
        return isPlayerActive;
    }
}
