using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour
{

    public GameObject[] camerasArray;

    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    public void EnableCamera(int cameraIndex)
    {
        for(int i=0; i<camerasArray.Length; i++)
        {
            if (i == cameraIndex) camerasArray[i].SetActive(true);
            else camerasArray[i].SetActive(false);
        }
    }
}
