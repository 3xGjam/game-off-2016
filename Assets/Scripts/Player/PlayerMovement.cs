using UnityEngine;
using System.Collections;

/*
//Potentially useful way to move sprites
    public Vector2 velocity;
    public Rigidbody2D rb2D;
    void Start() {
        rb2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate() {
        rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);
    }
*/

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb2D;
    GameManager gameManager;

    bool moveRight;
    bool moveLeft;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    void FixedUpdate()
    {
        Turn();
       
    }

    public void Turn()      //Keyboard Controls
    {
        //TODO: Add Sprite animations
        float horizontalMovement = Input.GetAxisRaw("Horizontal");  //sets the horizontal input using the horizontal axis.
        
        rb2D.velocity = new Vector2(horizontalMovement * speed, rb2D.velocity.y);

        if (!moveLeft)
        {
            moveLeft = true;
        }
        if (!moveRight)
        {
            moveRight = true;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        /* === This codeblock is for triggering boundaries === */

        if (other.name == "Right Boundary")
        {
            moveRight = false;
        }
        if (other.name == "Left Boundary")
        {
            moveLeft = false;
        }
        /* === End boundaries codeblock === */
        
    }
}