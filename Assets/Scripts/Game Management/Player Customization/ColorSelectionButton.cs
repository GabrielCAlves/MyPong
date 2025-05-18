using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelectionButton : MonoBehaviour
{
    [Header("Color Selection Button")]
    #region VARIABLES
    public Button uiButton;
    public Image paddleReference;

    public bool isColorPlayer = false;
    #endregion

    #region CODE
    public void OnButtonClick()
    {
        paddleReference.color = uiButton.colors.normalColor;

        if (isColorPlayer)
        {
            SaveController.Instance.colorPlayer = paddleReference.color;
        }
        else
        {
            SaveController.Instance.colorEnemy = paddleReference.color;
        }
    }
    #endregion
}
