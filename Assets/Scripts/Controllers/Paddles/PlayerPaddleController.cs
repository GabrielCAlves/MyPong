using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddleController : MonoBehaviour
{
    [Header("Player Paddle Controller")]
    #region VARIABLES
    public float speed = 5f;
    public string movementAxisName = "Vertical";

    public bool isPlayer = true;
    public SpriteRenderer spriteRenderer;
    #endregion

    #region CODE
    void Start()
    {
        if (isPlayer)
        {
            spriteRenderer.color = SaveController.Instance.colorPlayer;
        }
        else
        {
            spriteRenderer.color = SaveController.Instance.colorEnemy;
        }
    }

    void Update()
    {
        float moveInput = Input.GetAxis(movementAxisName);

        Vector3 newPosition = transform.position + Vector3.up * moveInput*speed*Time.deltaTime;

        newPosition.y = Mathf.Clamp(newPosition.y, -4.3f, 4.3f);

        transform.position = newPosition;
    }
    #endregion
}
