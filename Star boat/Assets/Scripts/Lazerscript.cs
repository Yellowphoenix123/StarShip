using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazerscript : MonoBehaviour
{
    public float speed;
    private GameObject lazerd;

    protected GameController gameControllerScript;
    // Start is called before the first frame update
    void Start()
    {
     
          GetComponent<Rigidbody>().velocity = Vector3.forward * speed;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
