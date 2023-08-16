using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] Transform[] wayPoint;
    [SerializeField] float moveSpeed;
    [SerializeField] int currentIndex;
    void Start()
    {
        transform.position = wayPoint[currentIndex].position;
    }

    void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement()
    {
        Vector2 targetPosition = wayPoint[currentIndex].position;
        transform.position = Vector2.MoveTowards(transform.position , targetPosition, moveSpeed * Time.deltaTime);
        if ((Vector2)transform.position == targetPosition)
        {
            if(currentIndex < wayPoint.Length - 1)
            {
                currentIndex++;
            }
            else
            {
                currentIndex = 0;
            }
        }
    }
}
