using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefabs;
    [SerializeField] float speedBullet;
    [SerializeField] float rangeTimeToShoot;

    [SerializeField] int poolsize = 20;
    [SerializeField] List<GameObject> projectilePool = new List<GameObject>();

    [SerializeField] Transform tempObject;

    [SerializeField] Transform handPosition;
    PlayerMovement player;
    void Start()
    {
        for (int i = 0; i < poolsize; i++) 
        {
            GameObject bullet = Instantiate(projectilePrefabs, transform.position, Quaternion.identity, tempObject);
            bullet.SetActive(false);
            projectilePool.Add(bullet);
        }
        player = GetComponent<PlayerMovement>();

    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(FireContinuosly());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopAllCoroutines();
        }
    }

    IEnumerator FireContinuosly()
    {
        while (true) 
        {
            GameObject laser = GetPooledObject();
            if (laser != null)
            {
                laser.transform.position = handPosition.position;
                laser.transform.rotation = handPosition.rotation;
                laser.SetActive(true);
                laser.GetComponent<Rigidbody2D>().velocity = Vector2.right * speedBullet;
               
                yield return new WaitForSeconds(rangeTimeToShoot);
            }
            else
            {
                yield break;
            }
        }
    }

    private GameObject GetPooledObject()
    {
        for(int i = 0; i < projectilePool.Count; i++)
        {
            if (!projectilePool[i].activeInHierarchy)
            {
                return projectilePool[i];
            }
        }
        return null;
    }
}
