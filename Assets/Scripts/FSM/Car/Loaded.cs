using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

public class Loaded : StateBehaviour
{
    public Transform destination;
    public Transform SpawnPoint;

    public float speed;
    public GameObject timeMaster;

    void OnEnable () {

        speed = timeMaster.GetComponent<Timers>().carSpeed;

	}
 
	// Called when the state is disabled
	void OnDisable () {
		Debug.Log("Stopped *State*");
	}
	
	// Update is called once per frame
	void Update () {
        Move();
    }
    private void OnCollisonEnter(Collision collision)
    {
        Debug.Log("Hit");

        SendEvent("Blocked");

    }
    private void Move()
    {
        speed = timeMaster.GetComponent<Timers>().carSpeed;
        Vector3 dir = new Vector3(1f, 0f, 0f);
        transform.position += dir * Time.deltaTime * speed;

    }
}


