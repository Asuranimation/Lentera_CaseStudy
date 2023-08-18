using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] int currentCoins;
  
    public void IncreaseCoins(int value)
    {
        currentCoins += value;
    }

    public int GetCurrentCoins()
    {
        return currentCoins;
    }

}
