using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour
{
    bool isCarrying = false;
 private void OnTriggerEnter2D(Collider2D other) {
    
    if (other.tag == "Customer" && isCarrying){
       
        isCarrying = false;
        GetComponent<Driver>().score += 1;
        Debug.Log("Score:   "+GetComponent<Driver>().score);
    }

    if (other.tag == "Cargo" && !isCarrying){
        Debug.Log("Cargo");
        isCarrying = true;
      GameObject[]  cargos = GameObject.FindGameObjectsWithTag("Cargo");
      if(cargos.Length == 1)
        {
           cargos[0].GetComponent<Spawner>().isColeccted = true;
        }
        else if(cargos.Length > 1)
        {
            
        }
    }

    if (other.tag == "SpeedUp")
        {
        GetComponent<Driver>().speed = 5f;
        GetComponent<Driver>().boostTime = 1f;
        
    }


 }
}
