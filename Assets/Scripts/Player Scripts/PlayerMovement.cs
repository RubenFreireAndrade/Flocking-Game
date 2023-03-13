using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement;
    //private Rigidbody2D rigidBody;

    [SerializeField] private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //rigidBody = GetComponent<Rigidbody2D>();
        moveSpeed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        transform.position += new Vector3(movement.x, movement.y, 0) * moveSpeed * Time.deltaTime;
    }

    // private void FixedUpdate() 
    // {
    //     rigidBody.MovePosition(rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
    // }
}
