using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [Header("Main Menu Controller")]
    #region VARIABLES
    public TextMeshProUGUI uiWinner;
    #endregion

    #region CODE
    void Start()
    {
        SaveController.Instance.Reset();

        string lastWinner = SaveController.Instance.GetLastWinner();

        if(lastWinner != "")
        {
            uiWinner.text = "Último vencedor: " + lastWinner;
        }
        else
        {
            uiWinner.text = "";
        }
    }
    #endregion
}
