using UnityEngine;

public class JumpPadControl : MonoBehaviour {

    PlayerMovement playerMovement;

	void Start () {
        playerMovement = FindObjectOfType<PlayerMovement>();

	}

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            playerMovement.Jump();

        }
    }
}
