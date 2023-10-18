using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLine : MonoBehaviour
{
    public float speed = 0.5625f;
    public Transform startMarker;
    public Transform endMarker;
    public bool moveDone = false;

    //set a timer from start to end
    float startTime;
    float journeyLength;



    void OnTriggerEnter2D(Collider2D other)
    {
        // This method is called when another object enters the trigger collider
        Debug.Log("Trigger entered by " + other.name);
        // get the collider's GameObject
        GameObject otherGameObject = other.gameObject;
        //if it does not have a MusicPad tag, return
        if (!otherGameObject.CompareTag("MusicPad"))
        {
            return;
        }
        // get the GameObject's SoundPlayer component
        SoundPlayer soundPlayer = otherGameObject.GetComponent<SoundPlayer>();
        // play the audio clip
        soundPlayer.PlayAudio();
    }

    // Start is called before the first frame update
    void Start()
    {
        //set the start time
        startTime = Time.time;

    }

    //on setting this object active, change moveDone to false
    void OnEnable()
    {
        moveDone = false;
    }

    //make a function to move to the end marker
    public void MoveToEnd()
    {
        if (transform.position == endMarker.position)
        {
            moveDone = true;
            //set the end time
            float endTime = Time.time;
            //calculate the journey length
            journeyLength = endTime - startTime;
            Debug.Log("Journey length: " + journeyLength);
        }
        //move the object to the end marker
        transform.position = Vector3.MoveTowards(transform.position, endMarker.position, speed * Time.deltaTime);
    }

    //set position back to start
    public void ResetPosition()
    {
        transform.position = startMarker.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!moveDone)
        {
            MoveToEnd();
        }
    }
}
