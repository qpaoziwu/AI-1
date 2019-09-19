using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

public class Empty : StateBehaviour
{
    public Transform destination;
    public float speed;
    public GameObject timeMaster;

    // Called when the state is enabled
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

      private void OnCollisionEnter(Collision collision)
      {


        if (collision.gameObject.tag == "Red")
        {
            Debug.Log("Hit");
            SendEvent("Blocked");
        }

      }
    private void Move()
    {
        Vector3 dir = Vector3.Normalize(destination.position - transform.position);
       // Vector3 slerpDir = Vector3.Slerp(dir, transform.position,0.2f);
        speed = timeMaster.GetComponent<Timers>().carSpeed;
        
        transform.position += dir * Time.deltaTime ;

    }
}


