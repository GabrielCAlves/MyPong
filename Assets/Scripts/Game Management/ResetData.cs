using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetData : MonoBehaviour
{
    #region CODE
    public void ClearData()
    {
        SaveController.Instance.ClearSave();
    }
    #endregion
}
