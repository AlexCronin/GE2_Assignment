using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IguanaActions : MonoBehaviour
{
    Animator iguanaAnimator;

    private GameObject snake;
    // Start is called before the first frame update
    void Start()
    {
        iguanaAnimator = GetComponent<Animator>();
        snake = GameObject.Find("Snakes");
        //iguanaAnimator.SetTrigger("Death");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector3.Distance(transform.position, snake.transform.position));

        if (Vector3.Distance(transform.position, snake.transform.position) <= 6)
        {
            iguanaAnimator.SetTrigger("Death");
            //Disable the FollowPath script
            GetComponent<FollowPath>().enabled = false;
            //Set the velocity to zero
            GetComponent<Boid>().velocity = Vector3.zero;
        }

    }
}
