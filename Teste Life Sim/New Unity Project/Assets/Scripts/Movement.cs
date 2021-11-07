using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    //Direction(1 = front, 2 = left, 3 = back, 4 = right)
    Animator animator;
    //The speed value for the player character
    float speedPlayer;
    //A variable to save the Rigidbody to easy access
    Rigidbody2D rPlayer;
    //Variable that receive the movement data
    Vector2 movementAction;
    //The player cash
    public float cash;
    public GameObject money;

    void Start()
    {
        //Starting the animator in a object called animator to simplify the call for other actions
        animator = GetComponent<Animator>();
        //Setting that the rigidbody is the Player's one
        rPlayer = GetComponent<Rigidbody2D>();
        //Setting the Animator Parameters to the idle first to always start in the correct idle animation
        animator.SetBool("Walk", false);
        animator.SetInteger("Direction", 1);

        speedPlayer = 5;

        cash = 1000;
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKey(KeyCode.W))
        {
            //Setting to the correct Direction and Calling the walk cicle animation
            animator.SetInteger("Direction", 3); //back
            animator.SetBool("Walk", true);

        }
        else if (Input.GetKey(KeyCode.A))
        {
            //Setting to the correct Direction and Calling the walk cicle animation
            animator.SetInteger("Direction", 2); //left
            animator.SetBool("Walk", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //Setting to the correct Direction and Calling the walk cicle animation
            animator.SetInteger("Direction", 1); //front
            animator.SetBool("Walk", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //Setting to the correct Direction and Calling the walk cicle animation
            animator.SetInteger("Direction", 4); //right
            animator.SetBool("Walk", true);
        }
        else
        {
            //Setting the parameter to go to the idle animation to the correct side
            animator.SetBool("Walk", false); //Just setting the walk false
        }
        //Getting the movement
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movementAction = new Vector2(x, y);
    }

    private void FixedUpdate()
    {
        rPlayer.velocity = new Vector2(movementAction.x * speedPlayer, movementAction.y * speedPlayer);
    }
}
