using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlock : MonoBehaviour
{
    public float gap = 20;

    public float followers = 2;
    public GameObject prefab;

    void Awake()
    {
        GameObject leader = GameObject.Instantiate<GameObject>(prefab);
        leader.transform.position = this.transform.position;
        leader.transform.rotation = this.transform.rotation;

        //FollowPath follow = leader.AddComponent<FollowPath>();
        //follow.path = Add
        //follow.path = FollowPath path = "BirdPath";
        //follow.GetComponent < Path >= "BirdPath";
        //leader.GetComponentInParent<Path>();
        //leader.GetComponentInParent<FollowPath>();
        //follow.path = leader.GetComponentInParent<Bi>


        for (int i = 1; i <= followers; i++)
        {
            Vector3 posRight = new Vector3(i * gap, 0, -i * gap);
            GameObject followerRight = GameObject.Instantiate<GameObject>(prefab, transform.TransformPoint(posRight), transform.rotation);

            Vector3 posLeft = new Vector3(-i * gap, 0, -i * gap);
            GameObject followerLeft = GameObject.Instantiate<GameObject>(prefab, transform.TransformPoint(posLeft), transform.rotation);
        }
    }

    void Update()
    {

    }

}
