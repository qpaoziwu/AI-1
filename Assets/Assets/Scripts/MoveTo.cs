using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    public Transform destination;
    public bool travelDirection;
    public Vector3 dir;
    public Vector3 distanceDir;
    public float speed;
    [Range (1,100)]
    public float cameraChaseSpeed;

    public float positionThreshold;
    public GameObject timeMaster;
    // Start is called before the first frame update
    void Start()
    {
        positionThreshold = timeMaster.GetComponent<Timers>().carDespawnThreshold;

    }

    // Update is called once per frame
    void Update()
    {
        Move(destination);

    }
    private void Move(Transform destination)
    {

        dir = Vector3.Normalize(destination.position - transform.position);
        Vector3 lerpDir = Vector3.Lerp(transform.position, dir, cameraChaseSpeed);
        speed = timeMaster.GetComponent<Timers>().carSpeed;
        distanceDir = new Vector3(lerpDir.x, 0f, lerpDir.z);
        if (Vector3.Distance(transform.position, destination.position) >= positionThreshold)
        {
        transform.position += distanceDir * Time.deltaTime * speed ;
            //transform.rotation = Quaternion.LookRotation(lerpDir);
        }
    }

}
