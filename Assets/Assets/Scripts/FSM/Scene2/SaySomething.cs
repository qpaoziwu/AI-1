using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

public class SaySomething : StateBehaviour
{
    public TextToUI textObject;
    public float timer;
    public bool reached;
    // Called when the state is enabled
    void OnEnable () {
        reached = false;
        timer = 0f;
        textObject = textObject.GetComponent<TextToUI>();
        
    }
 
	// Called when the state is disabled
	void OnDisable () {
		Debug.Log("Stopped *State*");
	}
	
	// Update is called once per frame
	void Update ()
    {
        StayTimer();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "SamWaypoint")
        {
            if (gameObject.tag == "Sam")
            {
                reached = true;
                textObject.SetText("??");
            }
        }
        if (other.gameObject.tag == "GollumWaypoint")
        {
            if (gameObject.tag == "Gollum")
            {
                reached = true;
                textObject.SetText("??");
            }
        }
        
    }
    public void StayTimer()
    {
        if (reached)
        {
            timer += Time.deltaTime;
            if (timer > 2f)
            {
                SendEvent("SaidSomething");
            }
        }
    }
}


