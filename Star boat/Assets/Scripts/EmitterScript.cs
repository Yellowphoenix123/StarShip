using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    public GameObject asteroid1;
    public GameObject EnemyShip1;
    public float minDelay, maxDelay;
    private float nextLaunch;

    protected GameController gameControllerScript;
    // Start is called before the first frame update
    void Start()
    {

        gameControllerScript = GameObject
            .FindGameObjectWithTag("GameController")
            .GetComponent<GameController>();
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (!gameControllerScript.getIsStarted())
        {
            return;
        }
        
        if (Time.time > nextLaunch)
        {
            nextLaunch = Time.time + Random.Range(minDelay, maxDelay);

            var halfWidth = transform.localScale.x / 2;
            var positionX = Random.Range(-halfWidth, halfWidth);

            var newAsteroidPosition = new Vector3(
                positionX,
                transform.position.y,
                transform.position.z
                );
           // Instantiate(asteroid1, newAsteroidPosition, Quaternion.identity);

            int random = Random.Range(1, 4);
            if (random == 1)
            {
                GameObject exp = Instantiate(asteroid1, newAsteroidPosition, Quaternion.identity);
                
            }
            else if(random == 2)
            {
                GameObject exp = Instantiate(EnemyShip1, newAsteroidPosition, Quaternion.identity);
                
            }         
            


        }
    } 
}



