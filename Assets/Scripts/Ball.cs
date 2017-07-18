using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Paddle paddle;
    private bool hasStarted = false;
    private Vector3 paddletoBallVector;

	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddletoBallVector = this.transform.position - paddle.transform.position;
        print(paddletoBallVector.y);

        
	}
	
	// Update is called once per frame
	void Update () {
        //print(paddle.GetComponent<Rigidbody2D>().velocity.magnitude);
        if (!hasStarted)
        {
            this.transform.position = paddle.transform.position + paddletoBallVector;
            if (Input.GetMouseButtonDown(0))
            {
                print("Launch ball");
                //print("CLICK: " + paddle.GetComponent<Rigidbody2D>().velocity);
                this.GetComponent<Rigidbody2D>().velocity =  new Vector2(10 , 10f);
                hasStarted = true;
            }
        }
	}
}
