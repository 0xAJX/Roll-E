using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public float smoothTime = 0.3f;
    //public GameObject follower;
    public GameObject sphere;
    public int xOffset;
    Vector3 velocity = Vector3.zero;

   

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Move();

	}

    void Move()
    {
        Vector3 targetPosition = sphere.transform.TransformPoint(new Vector3(xOffset, 0, 0));

        targetPosition = new Vector3(targetPosition.x, 0, 0);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

   
}
