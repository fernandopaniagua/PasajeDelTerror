﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVRMover : MonoBehaviour
{
    public Text text;
    public float speed;
    private Vector3 moveDirection;
    private float yInitPos;
    
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            RotateWithMouse();
        }
        if (GameManager.gameActive && (Input.GetMouseButton(0) || Input.touchCount > 0))
        {
            yInitPos = transform.position.y;
            MoveForward();
        }
    }
    private void MoveForward()
    {
        Quaternion currentRotation = transform.rotation;
        transform.rotation = Camera.main.transform.rotation;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.rotation = currentRotation;
        transform.position = new Vector3(transform.position.x, yInitPos, transform.position.z);
    }
    private void RotateWithMouse()
    {
        Camera.main.transform.Rotate(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0, Space.Self);
    }
}