using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeActions : MonoBehaviour
{
    private GameObject iguana;
    private GameObject[] objs;

    // Start is called before the first frame update
    void Start()
    {
        iguana = GameObject.Find("Iguana (1)");
        objs = GameObject.FindGameObjectsWithTag("Iguana");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector3.Distance(transform.position, iguana.transform.position));

        // Cycles through the list of Game Objects with the snake tag and enables different behaviours based on the distance
        foreach (var obj in objs)
        {
            Debug.Log(Vector3.Distance(transform.position, obj.transform.position));
            if (Vector3.Distance(transform.position, obj.transform.position) <= 80)
            {
                //Ensable the Pursue script
                GetComponent<Pursue>().enabled = true;

                GetComponent<Wander>().enabled = false;
            }
            else if (Vector3.Distance(transform.position, obj.transform.position) >= 110)
            {
                //Disable the Pursue script
                GetComponent<Pursue>().enabled = false;

                GetComponent<Wander>().enabled = true;

                //Set the velocity to zero
                //GetComponent<Boid>().velocity = Vector3.zero;
            }
        }
        /*
        if (Vector3.Distance(transform.position, iguana.transform.position) <= 100)
        {
            //Ensable the Pursue script
            GetComponent<Pursue>().enabled = true;

            GetComponent<Wander>().enabled = false;
        }
        else if (Vector3.Distance(transform.position, iguana.transform.position) >= 130)
        {
            //Disable the Pursue script
            GetComponent<Pursue>().enabled = false;

            GetComponent<Wander>().enabled = true;

            //Set the velocity to zero
            //GetComponent<Boid>().velocity = Vector3.zero;
        }
        */
    }
}
