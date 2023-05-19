using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement;

    [SerializeField] private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        transform.position += new Vector3(movement.x, movement.y, 0) * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Flock"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
