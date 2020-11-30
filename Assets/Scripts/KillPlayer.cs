using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        Debug.Log("collision");
        if (other.collider.tag=="Player")
        {    
           Debug.Log("collision");
            if(!other.collider.GetComponent<PlayerController>().IsDead)
            {
               other.collider.GetComponent<PlayerController>().KillPlayer();
            }
        }
   }

   
}
