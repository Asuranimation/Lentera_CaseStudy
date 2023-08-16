using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUiCondition : MonoBehaviour
{
    [SerializeField] GameObject player, enemy;
    [SerializeField] GameObject winUi, LoseUi;
   
    void Update()
    {
        ShowWinCanvas(); 
    }

    void ShowWinCanvas()
    {
        if(player == null)
        {
            LoseUi.SetActive(true);
        }
        if (enemy == null)
        {
            winUi.SetActive(true);
        }
    }
}
