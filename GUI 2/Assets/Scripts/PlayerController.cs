using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    //mouse input
    ////rotate the camera up and down
    ////rotate the character left and right
    //keyboard input
    ////move the character
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    private Vector3 velocity;
    public float mouseSensitivity = 100f;
    private float xRotation = 0f;
    Camera camera;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        camera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        MouseLook();
        Move();
    }
    private void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);
    }
    private void Move()
    {
        //x = -1 to 1
        float x = Input.GetAxis("Horizontal");
        //z = -1 to 1
        float z = Input.GetAxis("Vertical");
        //we want to move in this direction
        Vector3 move = (transform.right * x) + (transform.forward * z);
        velocity.y += gravity * Time.deltaTime;
        controller.Move((velocity + move) * speed * Time.deltaTime);
    }
}





