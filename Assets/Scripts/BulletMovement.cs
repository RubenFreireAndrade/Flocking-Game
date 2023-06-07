using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Flock"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("Hitting Flock");

            this.gameObject.SetActive(false);
            Debug.Log("Disabling Bullet");
        }
    }
}
