using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Shooter : MonoBehaviour
{
    public Rigidbody2D ball;
    Vector3 ballStartPos;

    private void Start()
    {
        ballStartPos = ball.transform.localPosition;
    }

    public void ResetBall() //reset the ball to its start position
    {
        ball.velocity = Vector2.zero;
        ball.angularVelocity = 0;
        ball.simulated = false;


        ball.transform.SetParent(transform, true); //using script to set a parent for the ball
        ball.transform.localPosition = ballStartPos; //relative position to its parent object.
        ball.transform.localRotation = Quaternion.Euler(Vector3.zero);
    }


}
    