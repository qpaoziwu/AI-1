using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

public class Loaded : StateBehaviour
{

    public Transform destination;
    public Transform SpawnPoint;
    public Transform DropoffPoint;
    public Transform nextPoint;

    public bool droppedKid;
    public bool travelDirection;
    public Vector3 dir;
    public float kidOffset;
    public float speed;
    public float positionThreshold;
    public GameObject timeMaster;
    public GameObject kid3;

    void OnEnable()
    {
        //droppedKid = false;
        kidOffset = timeMaster.GetComponent<Timers>().kidOffset;
        speed = timeMaster.GetComponent<Timers>().carSpeed;
        positionThreshold = timeMaster.GetComponent<Timers>().carDespawnThreshold;
    }

    // Called when the state is disabled
    void OnDisable()
    {
        //droppedKid = true;
        Debug.Log("Despawn Car");
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

        if (collision.gameObject.CompareTag("Kid"))
        {
            timeMaster.GetComponent<Timers>().CarEmpty = false;
            
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
    public Transform NextDestination()
    {
        if ((nextPoint == DropoffPoint))
        {
            if (droppedKid && (timeMaster.GetComponent<Timers>().CarEmpty == true))
            {
                return destination;
            }
        }
        if (nextPoint == destination)
        {
            if (timeMaster.GetComponent<Timers>().CarEmpty == false)
            {
                return DropoffPoint;
            }
        } 
    return destination;

    }

    private void CheckDestination(Transform t)
    {
        if (Vector3.Distance(transform.position, t.position) <= positionThreshold)
        {
            if (nextPoint = destination)
            {
                SendEvent("Despawn");
            }

            if (nextPoint = DropoffPoint)
            {
                if (timeMaster.GetComponent<Timers>().CarEmpty == false)
                    //!droppedKid)
                    //&& (timeMaster.GetComponent<Timers>().CarEmpty == false) )
                    //nextPoint = destination;
                    //droppedKid = true;
                   // timeMaster.GetComponent<Timers>().CarEmpty = true;
                {
                    //timeMaster.GetComponent<Timers>().CarEmpty = true;
                    //SpawnKid();
                }
            }
        }
    }
    private void SpawnKid()
    {
        Debug.Log("Dropoff Kid");

        Vector3 spawnOffset = new Vector3(DropoffPoint.transform.position.x, DropoffPoint.transform.position.y, DropoffPoint.transform.position.z + kidOffset);
        Instantiate(kid3, spawnOffset, Quaternion.identity);
    }
}


