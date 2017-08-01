using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 10.0f;
    float xmin = -5f;
    float ymin = -5f;
    float xmax = 5f;
    float ymax = 5f;
    float padding = 1f;

    private void Start()
    {
        float cameraDistance = transform.position.z - Camera.main.transform.position.z;
        Vector3 topleft = Camera.main.ViewportToWorldPoint(new Vector3(0,1,cameraDistance));  //this takes relative values. so 0.5 if the mouse is in the middle
        Vector3 bottomright = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, cameraDistance));
        xmin = topleft.x + padding; xmax = bottomright.x - padding;
        ymin = bottomright.y + padding;  ymax = topleft.y - padding;
        print(ymin);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        float newY = Mathf.Clamp(transform.position.y, ymin, ymax);
        transform.position = new Vector3(newX, newY, transform.position.z);
    }
}
