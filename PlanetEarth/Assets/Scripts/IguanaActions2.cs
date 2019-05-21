using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IguanaActions2 : MonoBehaviour
{

    private GameObject snake;
    private GameObject[] objs;

    // Start is called before the first frame update
    void Start()
    {
        snake = GameObject.Find("Snakes (3)");
        //gameObject.tag == "snake"

        objs = GameObject.FindGameObjectsWithTag("snake");
    }

    // Update is called once per frame
    void Update()
    {
        // Cycles through the list of Game Objects with the snake tag and enables different behaviours based on the distance
        foreach (var obj in objs)
        {
            //Debug.Log(Vector3.Distance(transform.position, obj.transform.position));
            if (Vector3.Distance(transform.position, obj.transform.position) <= 80)
            {
                //Disable the Flee script
                GetComponent<Flee>().enabled = true;
            }
            else if(Vector3.Distance(transform.position, obj.transform.position) >= 110)
            {
                //Disable the Flee script
                GetComponent<Flee>().enabled = false;
                //Set the velocity to zero
                GetComponent<Boid>().velocity = Vector3.zero;
            }

        }
    }
}
