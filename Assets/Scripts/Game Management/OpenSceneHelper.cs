using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSceneHelper : MonoBehaviour
{
    [Header("Open Scene Helper")]
    #region VARIABLES
    public string sceneToOpen;
    #endregion

    #region CODE
    public void OpenScene()
    {
        SceneManager.LoadScene(sceneToOpen);
    }
    #endregion
}
