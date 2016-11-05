using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    GameManager gameManager;

    public GameObject[] hackySacks;             //objects the player wants to hit him
    public Vector3 spawnValues;                 //Allows you to modify the hazard's position when it is instantiated in the unity editor.
    public GameObject[] avoidables;             //DODGE!

    void Start()
    {
        gameManager = GetComponent<GameManager>();

    }

    /*
    IEnumerator SpawnFood()
    {
        fruitRunning = true;   //In FixedUpdate, "turns off" the coroutine and stops the FixedUpdate from creating any more instances.

        yield return new WaitForSeconds(startWait);
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

        yield return new WaitForSeconds(avoidStartWait);
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
