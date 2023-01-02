using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class FlagScript : MonoBehaviour
{
    public GameObject flagPole;
    public TMP_Text distText;
    public GameObject cannonPivot;

    // Start is called before the first frame update
    void Start()
    {
        MoveFlag();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveFlag()
    {
        cannonPivot.GetComponent<CannonPivotScript>().removeDummy();
        //posizionata in modo casuale rispetto ad angolo (tra -40 e +40) + distanza (tra 10 e 100)
        Vector3 newPos = Quaternion.AngleAxis(UnityEngine.Random.Range(-40f, 40f), Vector3.up) * Vector3.forward * UnityEngine.Random.Range(10, 100);
        transform.position = newPos;
        flagPole.transform.rotation = Quaternion.Euler(0, UnityEngine.Random.Range(0,365f),0);
        distText.text = "" + Math.Round(Vector3.Distance(transform.position, cannonPivot.transform.position), 2) + "m TO CANNON";
        
    }
}
