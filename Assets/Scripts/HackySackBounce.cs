using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class HackySackBounce : MonoBehaviour
{
    Rigidbody2D rBody;
    [SerializeField] float bouncePower = 10;
    [SerializeField] float bounceMultiplier = 2.0f;

    public Boundary boundary;

    void Start()
    {
        rBody = gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
    }
    
    void FixedUpdate()
    {
        rBody.position = new Vector2
        (
            Mathf.Clamp(rBody.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rBody.position.y, boundary.yMin, boundary.yMax)
        );

        BounceOffBoundary();
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Player")
            BounceOffPlayer();
        
    }

    void BounceOffPlayer()
    {
        rBody.AddForce(Vector2.up * bouncePower, ForceMode2D.Impulse);
    }

    void BounceOffBoundary()
    {
        #region X
        if (rBody.position.x == boundary.xMin)
        {
            rBody.AddForce(Vector2.right * (bouncePower * bounceMultiplier), ForceMode2D.Impulse);
        }
        else if (rBody.position.x == boundary.xMax)
        {
            rBody.AddForce(Vector2.left * (bouncePower * bounceMultiplier), ForceMode2D.Impulse);
        }
        #endregion

        #region Y
        if (rBody.position.y == boundary.yMin)
        {
            Destroy(gameObject, 1.0f);
        }
        else if (rBody.position.y == boundary.yMax)
        {
            rBody.AddForce(Vector2.down * (bouncePower * bounceMultiplier), ForceMode2D.Impulse);
        }
        #endregion
    }
}
