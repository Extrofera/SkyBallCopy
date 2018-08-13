using UnityEngine;

public class CameraControl: MonoBehaviour {

    public Transform player;
    public Vector3 offset;

    LevelManager levelManager;

    private void Start() {
        levelManager = FindObjectOfType<LevelManager>();
    }

    void Update () {
        if (levelManager.levelComplete) {
            return;
        } else {
            transform.position = player.position + offset;
        }
	}
}
