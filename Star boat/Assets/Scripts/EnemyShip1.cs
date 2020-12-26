using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip1 : MonoBehaviour
{
    public float minSpeed, maxSpeed;
    public float speedRotation = 5f;
    public float LazerDelay;
    public float nextShot;
    public float Lazerspeed;
    public GameObject EnemyShip1_explosion;
    public GameObject Player_explpsion;
    public GameObject LazerGun;
    public GameObject LazerShot;
    public Transform Playertarget;
    public GameObject Record;
    GameObject player;
    Rigidbody ship;
    protected GameController gameControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody EnemyShip1 = GetComponent<Rigidbody>();
        EnemyShip1.velocity = Vector3.back * Random.Range(minSpeed, maxSpeed);

        gameControllerScript = GameObject
            .FindGameObjectWithTag("GameController")
            .GetComponent<GameController>();



        //поиск игрока
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        //поворот противника к игроку
        transform.LookAt(Playertarget);
       
        //стрельба
        if (Time.time > nextShot)
        {
            Instantiate(LazerShot, LazerGun.transform.position, LazerGun.transform.rotation);
            nextShot = Time.time + LazerDelay;
            
          /* //Создание и запуск снаряда
            Rigidbody Run = LazerShot.GetComponent<Rigidbody>();
       GetComponent<Rigidbody>().velocity = Vector3.forward * Lazerspeed;
            Run.AddForce(LazerShot.transform.forward * 30, ForceMode.Impulse);
          */

        }
        
    }



    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameBoundary" || other.tag == "Enemy" || other.tag == "LazerEnemy")
        {
            return;
        }            
        else if (other.tag == "Player")
        {
            // Instantiate(Player_explpsion, other.transform.position, Quaternion.identity);
            // gameControllerScript.increaseScore(0);
            Record.SetActive(true);

            Time.timeScale = 0f;

            GameObject exp = Instantiate(EnemyShip1_explosion, transform.position, Quaternion.identity);
            Instantiate(Player_explpsion, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
            Destroy(exp, 2);
            //  Destroy(EnemyShip1_explosion, 2);






        }
        else 
        {
            GameObject exp = Instantiate(EnemyShip1_explosion, transform.position, Quaternion.identity);
            gameControllerScript.increaseScore(20);
            Destroy(other.gameObject);
            Destroy(gameObject);
            Destroy(exp, 2);
            //  Destroy(EnemyShip1_explosion, 2);



        }

       
    }
}