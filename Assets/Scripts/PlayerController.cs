using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{  
    [SerializeField] private float forwardVelocity=10.0f;
    [SerializeField] private float jumpVelocity=20.0f;
    [SerializeField] private float downAcceleration=0.75f;
    [SerializeField] private float xSpeed=10.0f;

    private Vector3 velocity;
    private Rigidbody rb;
    private Animator animator;
    private int jumpInput=0;
    private bool onGround=false;
    private float xMovement=0f;
    private int slideInput=0;
    public bool IsDead=false;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        animator=GetComponent<Animator>();
        velocity= Vector3.zero;

        
    }

    void Update()
    {
        InputHandler();
    }

    void FixedUpdate()
    {
        Run();
        CheckIfGrounded();
        Jump();
        MoveX();
        Bark();

        rb.velocity=velocity;
    }

    void Run()
    {
        velocity.z=forwardVelocity;
    }

    void InputHandler()
    {
        if(Input.GetKeyDown(KeyCode.Space)) //Jump
        {
            jumpInput=1;
            Debug.Log("Jump");
        }

        else if(Input.GetKeyDown(KeyCode.S)) //Jump
        {
            slideInput=1;
            Debug.Log("Bark");
        }

        else if(Input.GetKeyDown(KeyCode.D)) //Right
        {   
            //if movement is zero that means player is in the middle
            if(xMovement==0)
            {
                xMovement=5;
            }

            else if (xMovement ==-5)
            {
                xMovement=0;
            }
        }

        else if(Input.GetKeyDown(KeyCode.A)) //Left
        {
            if(xMovement==0)
            {
                xMovement=-5;
            }

            else if (xMovement ==5)
            {
                xMovement=0;
            }
        }
    }

    void MoveX()
    {
        transform.position=Vector3.MoveTowards(transform.position,new Vector3(xMovement,transform.position.y,transform.position.z)
                                                ,Time.deltaTime*xSpeed);
    }

    void Jump()
    {
        if(jumpInput==1 && onGround)
        {
            velocity.y=jumpVelocity;
            animator.SetTrigger("Jump");
        }

        else if(jumpInput==0 && onGround)
        {
            velocity.y=0;
        }

        else
        {
            velocity.y-=downAcceleration;
        }
        jumpInput=0;
    }

    void Bark()
    {
        if(slideInput==1)
        {          
            animator.SetTrigger("Slide");
            slideInput=0;
        }
    }
    

    void CheckIfGrounded()
    {
        Ray ray = new Ray(transform.position + Vector3.up * 0.1f, Vector3.down);
        RaycastHit[] hits= Physics.RaycastAll(ray,0.5f);
        onGround=false;
        rb.useGravity=true;

        foreach (var hit in hits)
        {
            if(!hit.collider.isTrigger)
            {
                if(velocity.y <= 0)
                {
                    rb.position = Vector3.MoveTowards(rb.position, 
                        new Vector3(hit.point.x, hit.point.y + 0.1f, hit.point.z), Time.deltaTime*10);
                }
                rb.useGravity=false;
                onGround=true;
                break;
            }
        }
    }

    public void KillPlayer()
    {
        IsDead=true;
        forwardVelocity=0;
        animator.SetTrigger("Death");
    }
    
}
