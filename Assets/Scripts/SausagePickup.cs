using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sausage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int r= Random.Range(1,3);
        if(r==1)
        {
            transform.position=new Vector3(-7,transform.position.y,transform.position.z);
        }
        else if (r==2)
        {
            transform.position=new Vector3(0,transform.position.y,transform.position.z);
        }

        else 
        {
            transform.position=new Vector3(+7,transform.position.y,transform.position.z);
        }
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other) 
    {
        if(other.tag=="Player")
        {
            Destroy(gameObject);
            Debug.Log("sasig");

        }
    }
   
}
