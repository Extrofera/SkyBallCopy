using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperControl : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    public void ActivateBumper() {
        Debug.Log("bumpers activated");
        anim.SetTrigger("ActivateBumper");
    }
}
