using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle myPaddle;

    //
    [SerializeField] AudioClip[] ballSounds;


    Vector2 paddleToBallDistance;

    bool hasStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallDistance = this.transform.position - myPaddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)//equals to (hasstarted == false)
        {
            LockBallToPaddle();
            LaunchBallOnClick();
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        //generate random number
        int randomNumber = Random.Range(0, ballSounds.Length);

        //read clip from array position = randomNumber
        AudioClip myClip = ballSounds[randomNumber];

        GetComponent<AudioSource>().PlayOneShot(myClip);
    }

    private void LaunchBallOnClick()
    {
        if (Input.GetMouseButtonDown(0)) //left click
        {
            hasStarted = true;
            //shoot the ball
            GetComponent<Rigidbody2D>().velocity = new Vector2(1f, 15f);
            //new Vector2(Random.Range(0f,3f), Random.Range(15f,20f));
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = myPaddle.transform.position;

        this.transform.position = paddlePos + paddleToBallDistance;
    }
}
