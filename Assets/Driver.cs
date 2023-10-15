using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField]float rotationSpeed = 0f;
    
    public float speed = 0f;
    [SerializeField]float pressedKeyVertical = 0f;

    [SerializeField] float steerlingSpeed = 200f;

    float maxSpeed = 0.05f;

    public int score = 0;
    // Start is called before the first frame update
    public float boostTime = 0f;
    void Start()
    {
        Debug.Log(Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
       
        // Rotation Code
        float pressedKeyHorizantal = -Input.GetAxis("Horizontal");
        if (pressedKeyHorizantal > 0 )
        {
            rotationSpeed = (rotationSpeed + steerlingSpeed) * Time.deltaTime;
        }
        else if(pressedKeyHorizantal < 0)
        {
            rotationSpeed = (rotationSpeed - steerlingSpeed )* Time.deltaTime;
        }
        else{
            rotationSpeed = 0;
        }
    

        pressedKeyVertical = Input.GetAxis("Vertical");

        if (pressedKeyVertical > 0 )
        {
           if (speed < 0){
                speed += 0.05f * Time.deltaTime;
            }
            else{
                speed += 0.005f * Time.deltaTime;
            }
        }
        else if (pressedKeyVertical < 0)
        {   
            if (speed > 0){
                speed -= 0.05f * Time.deltaTime;
            }
            else{
                speed -= 0.005f * Time.deltaTime;
            }
         
        }
        else 
        {
            if  (speed != 0){

                // abolute value of speed
                float movespeed = Mathf.Abs(speed);

                // slow down
                movespeed -= 0.05f * Time.deltaTime;

                // clamp
                movespeed = Mathf.Clamp(movespeed, 0, 1);

                // assign back to speed
                speed = movespeed * Mathf.Sign(speed);



            }
         
          
           
        }
          if (Math.Abs(speed) > maxSpeed){

                if (boostTime >0){

                speed = maxSpeed*2 * Mathf.Sign(speed);

                boostTime -= Time.deltaTime;
                Debug.Log(boostTime);

           } else{
            speed = maxSpeed * Mathf.Sign(speed);
            }
           
            }
         
        
        // 

       transform.Rotate(0, 0,(float) rotationSpeed);
       transform.Translate(0, speed, 0);
    }
}
