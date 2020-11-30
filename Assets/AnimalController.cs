using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    private Transform player;
    private Animator animator;

    [SerializeField] private int speed =10;
    [SerializeField] private int distance =200;
    [SerializeField] private int dieDistance =10;
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

        animator=GetComponent<Animator>();
    }

    private void Update() 
    {
       if(!GameObject.Find("PlayerController").GetComponent<PlayerController>().IsDead)
       {
           if(Vector3.Distance(transform.position,player.position)<=distance)
            {    
               //move truck toward player. deltaTime makes the movement smooth

               transform.position=new Vector3(transform.position.x,transform.position.y,transform.position.z-speed*Time.deltaTime);
            }
       }
    }

    public void Die()
    {   
        if(!GameObject.Find("PlayerController").GetComponent<PlayerController>().IsDead)
        {
           if(Vector3.Distance(transform.position,player.position)<=dieDistance)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
