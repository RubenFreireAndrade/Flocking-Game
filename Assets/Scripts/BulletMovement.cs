using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    Rigidbody2D rigidBody;

    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        moveSpeed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    // void FixedUpdate() 
    // {
    //     rigidBody.MovePosition(Vector2.up * moveSpeed * Time.fixedDeltaTime);
    // }
}
