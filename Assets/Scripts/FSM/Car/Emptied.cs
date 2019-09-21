using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

public class Emptied : StateBehaviour
{
    public Transform destination;
    public Transform SpawnPoint;
    public Transform DropoffPoint;
    public Transform nextPoint;

    public bool travelDirection;
    public Vector3 dir;
    public float speed;
    public float positionThreshold;
    public GameObject timeMaster;

    void OnEnable()
    {
        nextPoint = destination;
        speed = timeMaster.GetComponent<Timers>().carSpeed;
        positionThreshold = timeMaster.GetComponent<Timers>().carDespawnThreshold;
    }

    // Called when the state is disabled
    void OnDisable()
    {
        //CarEmpty = false;

        Debug.Log("Stopped *State*");
    }

    // Update is called once per frame
    void Update()
    {
        Move(TravelDir(), NextDestination());
        CheckDestination(NextDestination());
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Red") || collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit");
            SendEvent("Blocked");
        }

    }
    public float TravelDir()
    {
        if (dir.x >= 0)
        {
            return 1;
        }
        else return -1;
    }
    private void Move(float dirModifier, Transform destination)
    {

        Vector3 dir = Vector3.Normalize(destination.position - transform.position);
        Vector3 lerpDir = Vector3.Slerp(transform.position, dir, 4f);
        speed = timeMaster.GetComponent<Timers>().carSpeed;

        transform.position += lerpDir * Time.deltaTime * speed * dirModifier;
        transform.rotation = Quaternion.LookRotation(lerpDir);

    }
    //Change Destination
    public Transform NextDestination()
    {
        if ((nextPoint = destination) && timeMaster.GetComponent<Timers>().CarEmpty==true)
        {
            nextPoint = DropoffPoint;
        }

        return DropoffPoint;
    }
    //Check Arrived
    private void CheckDestination(Transform t)
    {
        if (Vector3.Distance(transform.position, t.position) <= positionThreshold)
        {
            if (nextPoint = DropoffPoint)
            {
                SendEvent("Waiting");

            }

            if (nextPoint = destination)
            {
                //SendEvent("Despawn");
            }
        }
    }

}