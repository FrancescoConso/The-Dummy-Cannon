using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagCameraScript : MonoBehaviour
{
    //con questo script si aumenta / riduce lo zoom della telecamera della flag

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //le distanze sono divise per 10 per via di come è impostato il gameobject relativo alla bandiera
        if (transform.position.y > 1 && Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward;
        }
        if (transform.position.y < 36 && Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward;
        }
    }
}
