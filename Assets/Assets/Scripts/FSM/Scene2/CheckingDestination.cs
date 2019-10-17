using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

public class CheckingDestination : StateBehaviour
{


	// Update is called once per frame
	void Update () {


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Pot")
        {
            if (gameObject.tag == "Sam")
            {
                SendEvent("CookingPot");
            }
        }
        if (collision.gameObject.tag == "Artifact")
        {
            if (gameObject.tag == "Gollum")
            {
                SendEvent("GotArtifact");
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "SamWaypoint")
        {
            if (gameObject.tag == "Sam")
            {
                SendEvent("Null");

            }
        }
        if (other.gameObject.tag == "GollumWaypoint")
        {
            if (gameObject.tag == "Gollum")
            {
                SendEvent("Null");

            }
        }
    }

}


