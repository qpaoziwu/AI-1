using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;
using UnityEngine.AI;

public class FollowPlayer : StateBehaviour
{
    public GameObject Waypoint;
    public ItemPickup Player;
    public SetWaypoint Waypointer;
    NavMeshAgent navMeshAgent;
    // Called when the state is enabled
    void OnEnable () {
		Debug.Log(gameObject.name + " now Following Frodo");
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.stoppingDistance = 6f;
        Waypointer = Waypointer.GetComponent<SetWaypoint>();
    }
 
	// Called when the state is disabled
	void OnDisable () {
        Debug.Log(gameObject.name + " Stops Following Frodo");
 
    }

    // Update is called once per frame
    void Update ()
    {
        Waypoint.transform.position = Player.transform.position;
        CheckPlayerInput();
        if (Waypointer.CurrentWaypoint != null)
        {
            if (Waypointer.CurrentWaypoint.gameObject.tag == gameObject.tag)
            {
                SendEvent("PlayerInput");
            }
        }
        if (Player.GetComponent<ItemPickup>().artifact)
        {
            SendEvent("GetArtifact");

        }
    }

    void CheckPlayerInput()
    {


        if (Input.GetKeyDown(KeyCode.Alpha1))
        { if (gameObject.tag == "Sam")
            {
                SendEvent("PlayerInput");
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (gameObject.tag == "Gollum")
            {
                SendEvent("PlayerInput");
            }
        }

    }

}


