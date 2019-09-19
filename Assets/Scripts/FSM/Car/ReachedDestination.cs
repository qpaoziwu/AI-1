using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

public class ReachedDestination : StateBehaviour
{
    public GameObject timemaster;
    public Transform respawnPoint;
    public float timer;


    // Called when the state is enabled
    void OnEnable () {
		Debug.Log("Started *State*");
        timer = timemaster.GetComponent<Timers>().carSpawnTime;
        transform.position = respawnPoint.position;
    }
 
	// Called when the state is disabled
	void OnDisable () {
		Debug.Log("Stopped *State*");
	}
	
	// Update is called once per frame
	void Update () {
        if (timer > 0)
        {
            timer -= 1 * Time.deltaTime;
        }
        if (timer <= 0)
        {

            SendEvent("Respawn");
        }


    }
}


