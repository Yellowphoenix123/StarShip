using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerScript2 : MonoBehaviour
{
    Rigidbody ship;
    public GameObject LazerGun;
    public GameObject LazerGun1;
    public GameObject LazerShot;
    public GameObject EnemyShip1_explosion;
    public GameObject Player_explpsion;
    public GameObject Record;


    public float speed;
    public float tilt;
    public float xMax, xMin, zMax, zMin;

    public float lazerDelay;
    private float nextShot;
    



    protected GameController gameControllerScript;



        // Start is called before the first frame update
        void Start() 
    {
        gameControllerScript = GameObject
.FindGameObjectWithTag("GameController")
.GetComponent<GameController>();
        ship = GetComponent<Rigidbody>();
        


        Record.SetActive(false);

    }

        

            

       
         

    // Update is called once per frame
    void Update()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

        ship.rotation = Quaternion.Euler(moveVertical * tilt, 0, -moveHorizontal * tilt);

        var xPosition = Mathf.Clamp(ship.position.x, xMin, xMax);
        var zPosition = Mathf.Clamp(ship.position.z, zMin, zMax);
        ship.position = new Vector3(xPosition, 0, zPosition);           
            if (!gameControllerScript.getIsStarted())
            {
                return;
            }


            if (Input.GetButton("Fire1") && Time.time > nextShot)
        {
            // LazerShot = Resources.Load("Lazer") as GameObject;
            
            Instantiate(LazerShot, LazerGun.transform.position, Quaternion.identity);
            Instantiate(LazerShot, LazerGun1.transform.position, Quaternion.identity);
            nextShot = Time.time + lazerDelay;



            
        }
        



    }

    //Разрушение игрока    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LazerEnemy" )
        {
            //таблица рекордов                       
            Record.SetActive(true);

            // разрушение игрока
            Instantiate(Player_explpsion, transform.position, Quaternion.identity);
            
            Destroy(other.gameObject);
            Destroy(gameObject);
            Time.timeScale = 0f;

        }
        else if (other.tag == "Enemy")
        {
            //таблица рекордов                       
            Record.SetActive(true);

            // разрушение игрока
            Instantiate(EnemyShip1_explosion, transform.position, Quaternion.identity);
            Instantiate(Player_explpsion, transform.position, Quaternion.identity);

            Destroy(other.gameObject);
            Destroy(gameObject);
            
            Time.timeScale = 0f;

            

                
            
        }

        


    }
   
 
}
