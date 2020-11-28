using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//basic script to handle crouching and sprinting control, animations for movement & stamina depletion/regeneration. 

public class PlayerAdvancedMovement : MonoBehaviour
{

    public float sprintSpeed = 10f;
    public float moveSpeed = 5f;
    public float crouchSpeed = 2f;

    private Transform playerCam;
    private float standingHeight = 1f;
    private float crouchingHeight = 0.5f;
    private bool isCrouching;

    public float sprintTreshold = 10f;

    PlayerController pC;

    //reference required components
    private void Awake()
    {
        pC = GetComponent < PlayerController>();
        playerCam = transform.GetChild(0);
    }
    void Update()
    {
        Sprint();
        Crouch();
    }

    //function to handle player sprinting based on input
    //if stamina is greater then zero and player has pushed left shift and isn't crouching
    //change player speed to sprint speed
    void Sprint()
    {
        if(GameManager.currentStamina > 0f)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && !isCrouching)
            {
                pC.speed = sprintSpeed;

            }
        }
        //when player is finished sprinting and isn't crouching
        //change speed back to movespeed
        if (Input.GetKeyUp(KeyCode.LeftShift) && !isCrouching)
        {
            pC.speed = moveSpeed;
        }
        //drain stamina against sprint treshold divided by each frame
        // and if stanima value is less then zero, reset it to zero.
        if (Input.GetKey(KeyCode.LeftShift) && !isCrouching)
        {
            GameManager.currentStamina -= sprintTreshold * Time.deltaTime;

            if (GameManager.currentStamina <= 0f)
            {

                GameManager.currentStamina = 0f;

            }
        }
        else //else regenerate the stamina value accordinly.
        {
            if (GameManager.currentStamina != GameManager.maxStamina)
            {
                GameManager.currentStamina += (sprintTreshold / 2) * Time.deltaTime;
            }
            if (GameManager.currentStamina > GameManager.maxStamina)
            {
                GameManager.currentStamina = GameManager.maxStamina;
            }
        }
    }
    //function to handle player crouching speed and height based on input
    //if keypress is detected and is crouching is toggled
    //reset camera component height and reset speed to normal speed
    //toggle crouching bool
    //else change camera height to half, change movement speed to crouch speed
    //toggle crouching bool
    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isCrouching)
            {
                playerCam.localPosition = new Vector3(0f, standingHeight, 0f); //default standing height is 
                pC.speed = moveSpeed;

                isCrouching = false;
            }
            else
            {
                playerCam.localPosition = new Vector3(0f, crouchingHeight, 0f);
                pC.speed = crouchSpeed;

                isCrouching = true;
            }
        }
    }
}
