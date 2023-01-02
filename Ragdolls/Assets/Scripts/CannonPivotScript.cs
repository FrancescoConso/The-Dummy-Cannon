using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonPivotScript : MonoBehaviour
{

    public Slider xAngleSlider;
    public Slider yAngleSlider;

    public Transform instantiateCapsule;

    public GameObject bulletDummy;
    GameObject instantiatedDummy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Per sapere rotazione su x e y devo leggere i valori degli slider
        float xAngle = 75 - (xAngleSlider.value * 60);
        float yAngle = (yAngleSlider.value - 0.5f) * 90;
        transform.rotation = Quaternion.Euler(xAngle, yAngle, 0);
    }

    public void Fire()
    {
        if (instantiatedDummy != null) Destroy(instantiatedDummy);
        instantiatedDummy = Instantiate(bulletDummy, instantiateCapsule.position - transform.up, instantiateCapsule.rotation);
    }

    public void removeDummy()
    {
        if (instantiatedDummy != null) Destroy(instantiatedDummy);
    }
}
