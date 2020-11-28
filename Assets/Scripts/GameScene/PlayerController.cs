using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//referencing character controller component
[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    //references
    public CharacterController controller;
    private Camera camera;
    //player variables
    [Header("Player Stats")]
    public int level = 3;
    [Header("Player control")]
    public float speed = 12f;
    [SerializeField]
    private float gravity = -9.81f;   
    [SerializeField]
    private float mouseSensitivity = 100f;
    //movement control variables
    private float xRotation = 0f;
    private Vector3 velocity;

    //intialising character controller component, camera and cursor state
    void Start()
    {
        controller = GetComponent<CharacterController>();
        camera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    //updating movement and control methods
    void Update()
    {
        MouseLook();
        Move();
    }
    /// <summary>
    /// mouse input - rotate the camera up and down and rotate the character left and right
    /// </summary>
    public void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);

    }
    //keyboard movement
    public void Move()
    {
        //x = -1 to 1
        float x = Input.GetAxis("Horizontal");
        //z = -1 to 1
        float z = Input.GetAxis("Vertical");

        //move in direction
        Vector3 move = (transform.right * x) + (transform.forward * z);
        velocity.y += gravity * Time.deltaTime;
        controller.Move((velocity + move) * speed * Time.deltaTime);

    }

    //save/load button functions
    public void Save()
    {
        SaveSystem.SavePlayer(this);
    }
    public void Load()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        level = data.level;
        GameManager.instance.currentHealth = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }


}