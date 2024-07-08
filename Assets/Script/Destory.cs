using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Destory : MonoBehaviour
{
     void Start()
    {
        
    }

     void Update()
    {
        
    }
    /*void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player")) 
            {
                Destroy(gameObject);
                Debug.Log("hit");
            }
        }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerManager.numberOfCoins += 1;
            Destroy(gameObject);
            Debug.Log("Score: " + PlayerManager.numberOfCoins);
        }
    }
}
