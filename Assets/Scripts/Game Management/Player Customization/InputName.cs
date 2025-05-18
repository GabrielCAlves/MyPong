using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputName : MonoBehaviour
{
    [Header("Input Name")]
    #region VARIABLES
    public bool isPlayer;
    public TMP_InputField inputField;
    #endregion

    #region CODE
    private void Start()
    {
        inputField.onValueChanged.AddListener(UpdateName);
    }

    public void UpdateName(string name)
    {
        if (isPlayer)
        {
            SaveController.Instance.namePlayer = name;
        }
        else
        {
            SaveController.Instance.nameEnemy = name;
        }
    }
    #endregion
}
