using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("Ball Controller")]
    #region VARIABLES
    public GameManager gameManager;
    public Vector2 startingVelocity = new Vector2(-5f, -5f);
    public float speedUp = 1.1f;

    private Rigidbody2D rb;
    #endregion

    #region CODE
    public void ResetBall()
    {
        transform.position = Vector3.zero;

        if(rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        rb.velocity = startingVelocity;
    }
    #endregion

    #region INTERFACES
    private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 newVelocity = rb.velocity;

            newVelocity.y *= -1;
            rb.velocity = newVelocity;
        }else if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            rb.velocity *= speedUp;
        }
        else
        {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = true;

            if (collision.gameObject.CompareTag("WallEnemy"))
            {
                gameManager.ScorePlayer();

                collision.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                yield return new WaitForEndOfFrame();
            }
            else if (collision.gameObject.CompareTag("WallPlayer"))
            {
                gameManager.ScoreEnemy();

                collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                yield return new WaitForEndOfFrame();
            }

            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForEndOfFrame();

            ResetBall();
        }
    }
    #endregion

}
