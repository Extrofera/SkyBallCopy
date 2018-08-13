using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperTrigger : MonoBehaviour {

    BumperControl bumperControl;

    private void Start() {
        bumperControl = GetComponentInParent<BumperControl>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            Debug.Log("player hit bumper trigger");
            bumperControl.ActivateBumper();
        }
    }
}
