using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAnim : MonoBehaviour {

    private Animation anim;

	// Use this for initialization
	void Start () {

        anim = gameObject.GetComponent<Animation>();

        //StartCoroutine(Anim());

        Loop();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Loop()
    {
        anim.Play();
    }

  
    
}
