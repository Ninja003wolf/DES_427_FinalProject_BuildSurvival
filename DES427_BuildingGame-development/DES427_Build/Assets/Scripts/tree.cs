using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{
   
public int health = 100;

public GameObject woodPickupPrefab;

void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected");
        if(other.gameObject.CompareTag("axe"))
        {
            Debug.Log("Tree hit by axe! ");
            health = health - 20;
            
        }
        if(health <= 0)
        {
            if (woodPickupPrefab != null)
                {

                    Instantiate(woodPickupPrefab, transform.position + new Vector3(0, 5, 0), Quaternion.identity);
                }
            Destroy(gameObject);
            Debug.Log("Tree destroyed");
        }
        
    }

void Update()
{

}
On
}