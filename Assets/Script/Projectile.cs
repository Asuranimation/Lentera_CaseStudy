using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speedProjectile;
    [SerializeField] int damage;
    private void Update()
    {
        transform.Translate(Vector2.right * speedProjectile * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }

        Health health = collision.gameObject.GetComponent<Health>();
        if(health != null)
        {
            health.TakeDamage(damage);
            gameObject.SetActive(false);
        }
    }
}
