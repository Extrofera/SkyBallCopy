using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody rb;
    public float jumpPower;
    public float forwardForce = 1000f;
    public float sidewaysForce = 30f;
    public ParticleSystem deathEffect;
    public Transform endPos;
    public float step;
    public float levelDistance;
    public float currentDist;

    private LevelManager levelManager;

	void Start () {
        rb = GetComponent<Rigidbody>();
        levelManager = FindObjectOfType<LevelManager>();
        rb.useGravity = false;
        levelDistance = Vector3.Distance(endPos.position, this.transform.position);
    }

    private void Update() {
        // When touched
        if (!levelManager.levelComplete) {
            if (!levelManager.levelStarted && Input.GetKeyDown(KeyCode.UpArrow)) {
                Debug.Log("StartGame");
                rb.useGravity = true;
                levelManager.levelStarted = true;
            }
        }
    }

    void FixedUpdate () {
        if (levelManager.levelComplete) {
            Debug.Log("level complete -> move control to goal");
            MoveToGoal();
        }
        if (levelManager.levelStarted && !levelManager.levelComplete) {
            Move();
        }
    }

    public void Move() {
        float zMove = forwardForce * Time.deltaTime;
        float xMove = Input.GetAxisRaw("Horizontal") * sidewaysForce * Time.deltaTime;
        Vector3 newVelocity = new Vector3(xMove, rb.velocity.y, zMove);
        rb.velocity = newVelocity;

        if (rb.position.y <= -1f) {
            Death();
        }
    }

    public void Jump() {
        Vector3 jumpDir = new Vector3(0, 100f * jumpPower * Time.deltaTime, 0);
        rb.AddForce(jumpDir);
        Debug.Log("Jump with the force: " + jumpDir);
    }

    public void MoveToGoal() {
        // move player to endPos
        float moveSpeedToGoal = step * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, endPos.position, moveSpeedToGoal);
    }

    void Death() {
        FindObjectOfType<LevelManager>().EndGame();
        ParticleSystem deathEF = Instantiate(deathEffect, this.transform.position, Quaternion.identity);
        deathEF.Play();
        this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag == "Obstacle") {
            Debug.Log("hit obstacle");
            Death();
        }
    }

    public float FindDistanceToGoal() {
        // Find distance to the goal post
        float dist = Vector3.Distance(endPos.position, this.transform.position);
        currentDist = (dist / levelDistance);
        return currentDist;
    }
}
