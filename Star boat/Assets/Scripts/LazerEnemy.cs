using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerEnemy : MonoBehaviour
{
    protected GameObject ship;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Player");
        GetComponent<Rigidbody>().velocity = ship.transform.position * speed;
    }

    /*
    public float speed;
     Start is called before the first frame update
    void Start()
    {
        Rigidbody Run = Lazer_for_faer.GetComponent<
        GetComponent<Rigidbody>().velocity = Vector3.forward * speed; 
    }  
    */
    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 7);
    }
    

               
    
}
