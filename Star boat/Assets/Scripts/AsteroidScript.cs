using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float rotation;
    public float minSpeed, maxSpeed;

    public GameObject Asteroid_explosion;
    public GameObject Player_explpsion;

    protected GameController gameControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotation;
        asteroid.velocity = Vector3.back * Random.Range(minSpeed, maxSpeed);

        gameControllerScript =  GameObject
            .FindGameObjectWithTag("GameController")
            .GetComponent<GameController>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameBoundary" || other.tag == "Enemy" || other.tag == "LazerEnemy")
        {
            return;
        }

        GameObject exp = Instantiate(Asteroid_explosion, transform.position, Quaternion.identity);
        Destroy(other.gameObject);
        Destroy(gameObject);
        Destroy(exp, 2);

        //Destroy(Asteroid_explosion, 2);


        if (other.tag == "Player")
        {
            // Instantiate(Player_explpsion, other.transform.position, Quaternion.identity);            
            // gameControllerScript.increaseScore(0);
            return;

        }else
        {
            gameControllerScript.increaseScore(10);
        }

        
    }
}
