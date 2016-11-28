using UnityEngine;
using System.Collections.Generic;
using MovementEffects;

[RequireComponent(typeof(GameManager))]
public class Spawner : MonoBehaviour
{
    GameManager gameManager;

    public GameObject[] hackySacks;             //objects the player wants to hit him
    [SerializeField] Vector2 hackySackposition = new Vector2(0, 0);

    [Tooltip("The limit in both max and min values from where an object can spawn. IE '10' will spawn -10 and 10.")]
    public Vector2 spawnValues;                 //Allows you to modify the hazard's position when it is instantiated in the unity editor.
    public GameObject[] avoidables;             //DODGE!

    public int avoidCount;
    public float avoidStartWait = 10; //The amount of time (in seconds) before the first wave of SpawnAvoidables starts in the game. This starts the first wave only.
    public float avoidSpawnWait = 4; //The amount of time (in seconds) before another avoidable fruit is instantiated. If there is 0.5 seconds between each spawn, then one avoidable fruit will spawn every 0.5 seconds until the wave stops.
    public float avoidWaiveWait = 20; //The amount of time (in seconds) before another wave of avoidable fruit starts up again. If there is 4 seconds between each wave, that means there are four seconds after the last avoidable fruit spawned before another wave is started.

    #pragma warning disable 0414
    bool avoidableRunning;
    #pragma warning restore 0414

    /*
        #pragma warning disable 0168 // variable declared but not used.
        #pragma warning disable 0219 // variable assigned but not used.
        #pragma warning disable 0414 // private field assigned but not used.

        #pragma warning restore 0168 // variable declared but not used.
        #pragma warning restore 0219 // variable assigned but not used.
        #pragma warning restore 0414 // private field assigned but not used.
    */

    bool gameOver;
    bool pause;



    void Start()
    {
        gameManager = GetComponent<GameManager>();

        avoidableRunning = true;
        gameOver = gameManager.gameOver;
        pause = gameManager.pause;

        Invoke("SpawnHackySack", 3);                    //Wait three seconds then call this method

        Timing.RunCoroutine(_SpawnAvoidables());        //Only ever starts once, when the game is over this ends.

    }

    void SpawnHackySack()       //Initial Game Start method
    {
        Instantiate(hackySacks[0], hackySackposition, Quaternion.identity);      //Always instantiate the hackysack above the starting player position.
    }


    IEnumerator<float> _SpawnAvoidables()
    {
        //TODO: Logarithilly increase the amound of avoidables that are spawned.
        avoidableRunning = true;

        yield return Timing.WaitForSeconds(avoidStartWait);

        while (gameOver != true && pause != true)
        {
            for (int i = 0; i <= avoidCount; i++)
            {
                GameObject food = avoidables[Random.Range(0, avoidables.Length)];
                Vector2 spawnPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y);         //inserts the values from the unity editor into the hazard's spawnPosition.
                Quaternion spawnRotation = Quaternion.identity;     //Means our food will have no new rotation.
                Instantiate(food, spawnPosition, spawnRotation);
                if (pause == true || gameOver == true)
                { break; }                              //Breaks the loop so fruit will stop spawning in (it finishes it's loop before stopping) DO NOT USE YIELD BREAK UNLESS YOU WANT THE LOOP TO STAY BROKEN UNTIL YOU START THE SCRIPT AGAIN!!!
                yield return Timing.WaitForSeconds(avoidStartWait);
            }
            yield return Timing.WaitForSeconds(avoidWaiveWait);
        }

        avoidableRunning = false;  //In FixedUpdate, one SpawnFood Coroutine is allowed to pass.
    }

    /*
    IEnumerator SpawnFood()
    {
        fruitRunning = true;   //In FixedUpdate, "turns off" the coroutine and stops the FixedUpdate from creating any more instances.

        yield return new WaitForSeconds(avoidStartWait);
        while (gameOver != true && pause != true)
        {
            for (int i = 0; i <= foodCount; i++)
            {
                GameObject food = Foodstuffs[Random.Range(0, Foodstuffs.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);         //inserts the values from the unity editor into the hazard's spawnPosition.
                Quaternion spawnRotation = Quaternion.identity;     //Means our food will have no new rotation.
                Instantiate(food, spawnPosition, spawnRotation);
                if (pause == true || gameOver == true)
                { break; }                              //Breaks the loop so fruit will stop spawning in (it finishes it's loop before stopping) DO NOT USE YIELD BREAK UNLESS YOU WANT THE LOOP TO STAY BROKEN UNTIL YOU START THE SCRIPT AGAIN!!!
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waiveWait);
        }

        fruitRunning = false;  //In FixedUpdate, one SpawnFood Coroutine is allowed to pass.
    }

    IEnumerator SpawnAvoidables()
    {
        avoidableRunning = true;   //In FixedUpdate, "turns off" the coroutine and stops the FixedUpdate from creating any more instances.

        yield return new WaitForSeconds(avoidavoidStartWait);
        while (gameOver != true && pause != true)
        {
            for (int i = 0; i <= avoidCount; i++)
            {
                GameObject avoidable = Avoidables[Random.Range(0, Avoidables.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);         //inserts the values from the unity editor into the hazard's spawnPosition.
                Quaternion spawnRotation = Quaternion.identity;     //Means our food will have no new rotation.
                Instantiate(avoidable, spawnPosition, spawnRotation);
                if (pause == true || gameOver == true)
                { break; }                                  //Breaks the loop so fruit will stop spawning in (it finishes it's loop before stopping) DO NOT USE YIELD BREAK UNLESS YOU WANT THE LOOP TO STAY BROKEN UNTIL YOU START THE SCRIPT AGAIN!!!
                yield return new WaitForSeconds(avoidSpawnWait);
            }
            yield return new WaitForSeconds(avoidWaiveWait);
        }

        avoidableRunning = false;  //In FixedUpdate, one SpawnFood Coroutine is allowed to pass.
    }
    */
}
