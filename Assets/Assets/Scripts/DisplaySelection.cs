using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySelection : MonoBehaviour
{

    public GameObject Waypoint1;
    public GameObject Waypoint2;
    public GameObject CurrentWaypoint;
    public MeshRenderer mesh;
    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.enabled = false;
    }
    void Update()
    {
        SelectWaypoint();
        PlaceWaypoint();
    }

    void SelectWaypoint()
    {
        if (Waypoint1 & Waypoint2 != null)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                mesh.enabled = true;
                CurrentWaypoint = Waypoint1;
                print("Waypoint1 Selected");
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                mesh.enabled = true;
                CurrentWaypoint = Waypoint2;
                print("Waypoint2 Selected");
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CurrentWaypoint = null;

                print("Cancel Selection");
                mesh.enabled = false;
            }
        }
        else { print("Waypoint not set in Inspector"); }


    }

    void PlaceWaypoint()
    {
        if (CurrentWaypoint != null)
        {
            gameObject.transform.position = CurrentWaypoint.transform.position+ new Vector3(0,1.01f,0);
        }
    }

}
