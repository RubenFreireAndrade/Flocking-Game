using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    private List<GameObject> bulletPrefabs = new List<GameObject>();

    private float destroyRange = 40f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyBulletAfterRange();

        if (Input.GetMouseButtonDown(0))
        {
            var newBulletPrefab = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bulletPrefabs.Add(newBulletPrefab);
        }
    }

    private void DestroyBulletAfterRange()
    {
        foreach (var bullet in bulletPrefabs)
        {
            if (bullet != null)
            {
                if (Vector2.Distance(transform.position, bullet.transform.position) >= destroyRange)
                {
                    Destroy(bullet.gameObject);
                }
            }
        }
    }
}
