using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wander : SteeringBehaviour
{
    public float distance = 15.0f;
    public float radius = 10;
    public float jitter = 200;

    Vector3 target;
    Vector3 worldTarget;

    public void OnDrawGizmos()
    {
        Vector3 localCP = Vector3.forward * distance;
        Vector3 worldCP = transform.TransformPoint(localCP);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, worldCP);
        Gizmos.DrawWireSphere(worldCP, radius);

       // Gizmos.DrawWireSphere(transform.TransformPoint(Vector3.forward), radius);

        //me
        //Gizmos.color = Color.yellow;
        //Gizmos.DrawLine(worldCP - new Vector3(10, 0, 0), worldCP + new Vector3(10, 0, 0));
        //me
        /*
        Gizmos.color = Color.yellow;
        Vector3 myleft = Vector3.forward - new Vector3(1, 0, 0) * distance;
        Vector3 myright = Vector3.forward + new Vector3(1, 0, 0) * distance;
        Vector3 worldPointLeft = transform.TransformPoint(myleft);
        Vector3 worldPointRight = transform.TransformPoint(myright);
        Gizmos.DrawLine(worldPointLeft, worldPointRight);
        */

        Vector3 localTarget = (Vector3.forward * distance) + target;
        worldTarget = transform.TransformPoint(localTarget);

        Gizmos.color = Color.red;

        Gizmos.DrawSphere(worldTarget, 1);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, worldTarget);

    }

    public override Vector3 Calculate()
    {
        //Same idea as getting a random point on the unit circle, but the y value is always zero becuase we don't need the model to travel up and down that axis
        Vector3 disp = jitter * new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)) * Time.deltaTime;

        //Vector3 v33 = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        //Debug.Log(v33);

        target -= disp;
        target.Normalize();
        target *= radius;

        Vector3 localTarget = (Vector3.forward * distance) + target;

        worldTarget = transform.TransformPoint(localTarget);
        return worldTarget - transform.position;

    }

    // Start is called before the first frame update
    void Start()
    {
        //Same idea as getting a random point on the unit circle, but the y value is always zero becuase we don't need the model to travel up and down that axis
        target = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)) * radius;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

