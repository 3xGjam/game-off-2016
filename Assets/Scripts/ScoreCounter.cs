using UnityEngine;
using System.Collections;
using System;

public class ScoreCounter : MonoBehaviour
{
    GameManager gameManager;

    HackySackBounce bounce;
    Rigidbody2D rBody;

    int baseScore = 10;
    int wallBonus = 0;

    void Start()
    {
        try
        {
            rBody = GetComponent<Rigidbody2D>();
            bounce = GetComponent<HackySackBounce>();
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("Sorry kid, couldn't find the Rigidbody2D attached to " + transform.name);
            Debug.LogError("Sorry kid, couldn't find the script \"HackySackBounce\" attached to " + transform.name);
            Debug.LogException(e);
        }

        try
        {
            gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("Sorry kid, couldn't find a Game Object with the tag \"GameController\"");
            Debug.LogException(e);
        }
    }

    void FixedUpdate()
    {
        WallBonusDeterminator();
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player")
        {   
            gameManager.score += baseScore + wallBonus;
            wallBonus = 0;
        }
        
    }

    private void WallBonusDeterminator()
    {
        if (rBody.position.x <= bounce.boundary.xMin || rBody.position.x >= bounce.boundary.xMax)
        {
            wallBonus = 25; 
        }
    }
}
