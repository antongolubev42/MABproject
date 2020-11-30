using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Transform player;
    private Animator[] animators;

    [SerializeField] private int speed =10;
    [SerializeField] private int distance =100;
    // Start is called before the first frame update
    void Start()
    {   
        player=GameObject.Find("PlayerController").transform;
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

        animators=GetComponentsInChildren<Animator>();
    }

   private void Update() {
       //Debug.Log(Vector3.Distance(transform.position,player.position));
       //if player not dead
       if(!GameObject.Find("PlayerController").GetComponent<PlayerController>().IsDead)
       {
           if(Vector3.Distance(transform.position,player.position)<=distance)
           {    
               //move truck toward player. deltaTime makes the movement smooth

               transform.position=new Vector3(transform.position.x,transform.position.y,transform.position.z-speed*Time.deltaTime);
               
                //make each wheel rotate
               foreach (Animator animator in animators)
               {
                   animator.SetTrigger("Move");
               }         
           }
           else
           {
               foreach (Animator animator in animators)
               {
                   animator.SetTrigger("Stop");
               }         
           }
       }
   }
}
