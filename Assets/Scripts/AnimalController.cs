using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    private Transform player;
    private Animator animator;
    private GameObject dog;

    [SerializeField] private int speed =10;
    [SerializeField] private int distance =200;
    [SerializeField] private int runDistance =20;
    [SerializeField] private int xSpeed=20;

    private int barking;
    // Start is called before the first frame update
    void Start()
    {   
        animator=GetComponent<Animator>();
        player=GameObject.Find("PlayerController").transform;
        dog=GameObject.Find("PlayerController");
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
        Run();
       if(!GameObject.Find("PlayerController").GetComponent<PlayerController>().IsDead)
       {
           if(Vector3.Distance(transform.position,player.position)<=distance)
            {    
               //move truck toward player. deltaTime makes the movement smooth

               transform.position=new Vector3(transform.position.x,transform.position.y,transform.position.z-speed*Time.deltaTime);
            }
       }
    }

    public void Run()
    {   
       //barking = GameObject.Find("PlayerController").GetComponent<PlayerController>().barkInput;
        //if(!GameObject.Find("PlayerController").GetComponent<PlayerController>().IsDead)
        //{
           if(Vector3.Distance(transform.position,player.position)<=runDistance )
            {
                animator.SetTrigger("turn");
                speed=0;
                transform.position=new Vector3(transform.position.x+xSpeed*Time.deltaTime,transform.position.y,transform.position.z);
            }
        //}
    } 
}
