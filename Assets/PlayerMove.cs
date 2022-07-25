using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rbody;
    public float MoveSpeed = 4;
    public float RunSpeed = 6;
    public float jumpPower = 5;
    public float mouse_x = 100;
    public float mouse_y = 150;
    public float max_angle = 70, min_angle = -70;
    public Transform cam;


    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }
    bool jumpCommand = false;
    float angle = 0;
    void Update()
    {
        jumpCommand |= Input.GetButtonDown("Jump");
        var mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        transform.rotation *= Quaternion.Euler(0, mouseInput.x * mouse_x * Time.deltaTime, 0);

        angle = Mathf.Clamp(angle - mouseInput.y * mouse_y * Time.deltaTime, -max_angle, -min_angle);
        cam.localRotation = Quaternion.Euler(angle, 0, 0);
    }
    private void FixedUpdate()
    {
        var motionInput = transform.rotation * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        motionInput.x += rbody.velocity.x;
        motionInput.z += rbody.velocity.z;
        var speed = Input.GetButton("Fire3") ? RunSpeed : MoveSpeed;
        motionInput.y = rbody.velocity.y;
        if (jumpCommand)
        {
            jumpCommand = false;
            motionInput.y = jumpPower;
        }
        rbody.velocity = motionInput;
    }
}
