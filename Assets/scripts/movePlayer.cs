using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
    public float speed;             //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.


    // variable to hold a reference to our SpriteRenderer component
    private SpriteRenderer mySpriteRenderer;

    // This function is called just one time by Unity the moment the component loads
    private void Awake()
    {
        // get a reference to the SpriteRenderer component on this gameObject
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();

    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            mySpriteRenderer.flipX = true;
            //Debug.Log("left key down");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            mySpriteRenderer.flipX = false;
            //Debug.Log("right key down");
        }

    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //float moveHorizontal = 0f;

        //if (Input.GetKey("left"))
        //{
        //    moveHorizontal = -1f;
        //    Debug.Log("left key pressed");
        //} else if (Input.GetKey("right"))
        //{
        //    moveHorizontal = 1f;
        //    Debug.Log("right key pressed");
        //}
        Debug.Log(Input.GetAxis("Horizontal"));
        Debug.Log(Time.frameCount);

        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");
        
        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, 0);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce(movement * speed);
    }
}