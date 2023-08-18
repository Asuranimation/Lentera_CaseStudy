using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUiCondition : MonoBehaviour
{
    [SerializeField] GameObject player, enemy;
    [SerializeField] GameObject winUi, LoseUi;
    [SerializeField] Collectible collect;

    private void Awake()
    {
        
    }

    void Update()
    {
        ShowWinCanvas(); 
    }

    void ShowWinCanvas()
    {
        if(player == null && collect.GetCoin() == 3)
        {
            LoseUi.SetActive(true);
        }
        if (enemy == null)
        {
            winUi.SetActive(true);
        }
    }
}
