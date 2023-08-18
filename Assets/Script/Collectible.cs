using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private GameObject coins;
    [SerializeField] int indexCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            coins.SetActive(false);
            indexCoin ++;
        }
    }

    public int GetCoin()
    {
        return indexCoin;
    }

}
