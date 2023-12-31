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
    void Start()
    {
        for (int i = 0; i < poolsize; i++) 
        {
            GameObject bullet = Instantiate(projectilePrefabs, transform.position,transform.rotation, tempObject);
            bullet.SetActive(false);
            projectilePool.Add(bullet);
        }

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
                laser.transform.rotation = transform.rotation;
                laser.SetActive(true);
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
