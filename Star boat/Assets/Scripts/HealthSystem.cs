using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public int health;
    public int numberOflives;
    public Image[] lives;
    public Sprite fullLive;
    public Sprite emptyLive;
    public GameObject Player;
    public GameObject my_Player;
    public GameObject EnemyShip1_explosion;
    public GameObject Player_explpsion;


    // Start is called before the first frame update
    void Start()
    {
        
        var newPlayerPosition = new Vector3(
                transform.position.x,
                transform.position.y,
                transform.position.z
                );

        


    }

    // жизьки
    void Update()
    {
        if (health > numberOflives)
        {
            health = numberOflives;
        }
        for (int i = 0; i < lives.Length; i++)
        {
            if (i < health)
            {
                lives[i].sprite = fullLive;
            }
            else
            {
                lives[i].sprite = emptyLive;
            }


            if (i < numberOflives)
            {
                lives[i].enabled = true;
            }
            else
            {
                lives[i].enabled = false;
            }
        }
        
        {


            
          
          // рождение игрока
          
            var newPlayerPosition = new Vector3(
                transform.position.x,
                transform.position.y,
                transform.position.z
                );

            if (Player == null)
            {

                if (health > 0)
                {
                    health = -health;
                    Instantiate(Player, newPlayerPosition, Quaternion.identity);
                }
                else
                {
                    Time.timeScale = 0f;
                }



            }

            


        }




    }


    

    /*
    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class coin : MonoBehaviour {

    public GameObject enemy;
    // Use this for initialization
    void Start()
    {
            Instantiate(enemy);
        Destroy(enemy, 5);
    }
       
        // Update is called once per frame
        void Update () {  
        if(enemy)
        {
            enemy.transform.RotateAround(enemy.transform.position, new Vector3(0, 1, 0), 100 * Time.deltaTime);
           
        }
        else
        {
            Instantiate(enemy);
        }
    }
}  

    */
}


