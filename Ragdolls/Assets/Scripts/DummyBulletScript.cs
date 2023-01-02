using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DummyBulletScript : MonoBehaviour
{
    Slider strenghtSlider;
    TMP_Text distanceText;

    TMP_Text helpText;

    public Rigidbody ragdollRoot;

    public float DEBUGRadgollDistance;

    public Transform flagBase;

    private Vector3 lastRootPosition;
    private Vector3 rootPosition;

    private Coroutine countdownCoroutine = null;

    private bool isMoving = true;

    // Start is called before the first frame update
    void Start()
    {
        strenghtSlider = GameObject.Find("StrenghtSlider").GetComponent<Slider>();
        distanceText = GameObject.Find("DistanceText").GetComponent<TMP_Text>();

        flagBase = GameObject.Find("FlagBase").transform;
        float strenght = 100 + (strenghtSlider.value * 500);
        ragdollRoot.AddForce(transform.up * strenght, ForceMode.Impulse);
        lastRootPosition = ragdollRoot.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DEBUGRadgollDistance = Vector3.Distance(flagBase.position, ragdollRoot.position);

        if (isMoving)
            distanceText.text = "" + (float)Math.Round(DEBUGRadgollDistance, 2) + "m TO DUMMY";

        rootPosition = ragdollRoot.transform.position;

        if(Vector3.Distance(rootPosition,lastRootPosition) < 0.001f)
        {
            //Debug.Log("NOT Moving");
            isMoving = false;
            if (countdownCoroutine == null) { countdownCoroutine = StartCoroutine(ragdollCountdown()); }
        }
        else
        {
            //Debug.Log("Moving");
            isMoving = true;
            if (countdownCoroutine != null) { StopCoroutine(countdownCoroutine); countdownCoroutine = null; }
        }

        lastRootPosition = rootPosition;
    }

    IEnumerator ragdollCountdown()
    {
        //Debug.Log("Countdown Started");
        yield return new WaitForSeconds(3.0f);
        distanceText.text = "RESULT: " + calculateScore().ToString("F1");
        yield return null;
    }

    float calculateScore()
    {
        float finalScore;
        float truncRagdollDistance = (float)Math.Round(DEBUGRadgollDistance, 2);

        //prendiamo la distanza troncata 
        //dividiamo per 0.5 e tronchiamo per avere le decimali
        //diviso per 10 e sottratto a 10 per la valutazione

        finalScore = Mathf.Clamp(10 - (Mathf.Round(truncRagdollDistance / 0.5f) / 10), 0, 10);


        return finalScore;
    }
}
