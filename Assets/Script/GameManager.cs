using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player,enemies, imageWin, imageGameOver;
    [SerializeField] Collectible collectible;

    private void Update()
    {
        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        if(enemies == null && collectible.GetCurrentCoins() == 3)
        {
            Winner();
        }
        else if (player == null)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        if(imageGameOver != null)
        {
            imageGameOver.SetActive(true);
        }
    }

    private void Winner()
    {
        if(imageWin != null) 
        {
            imageWin.SetActive(true);
        }
    }
}
