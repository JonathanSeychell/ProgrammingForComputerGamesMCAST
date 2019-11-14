﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;

    float xMin, xMax, yMin, yMax;

    float padding = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        setUpMoveBoundaries();   
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }
    private void setUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;


        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    private float MoveX()
    {
        // get the distance in input on the x-axis
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
        //set the new x position to the current position + deltaX
        float newXPos = Mathf.Clamp(transform.position.x + deltaX,xMin,xMax);

        return newXPos;

    }
    
    private float MoveY()
    {
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
        float newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        return newYPos;
    }
    private void Move()
    {   
        //move the player
        transform.position = new Vector2(MoveX(), MoveY());
    }
    
}
