using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCameraScript : MonoBehaviour
{
    public Transform flagTransform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //WS avanti AD rotazione QE ascesa

        transform.LookAt(flagTransform);

        float distToFlag = Vector3.Distance(transform.position, flagTransform.position);

        if (transform.position.y < 10f && Input.GetKey(KeyCode.E))
        {
            transform.position += transform.up;
        }
        if (transform.position.y > 1 && Input.GetKey(KeyCode.Q))
        {
            transform.position -= transform.up;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right;
        }
        if (distToFlag > 3f && Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward;
        }
        if (distToFlag < 100f && Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward;
        }
    }
}
