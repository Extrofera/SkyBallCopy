using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public bool levelStarted = false;
    public GameObject CompletePanel;
    public GameObject DeathPanel;
    public bool levelComplete;
    public string test;
    public Text levelPercentageText;

    private float levelPercentageNum = 10f;

    PlayerMovement playerMovement;
    GameManager gameManager;

    public void Start() {
        levelComplete = false;
        DeathPanel.SetActive(false);
        gameManager = FindObjectOfType<GameManager>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void Update() {
        test = gameManager.sceneName;
        Debug.Log("Calling gameManager from level: " + test);
        UpdateLevelProgress();
    }

    public void UpdateLevelProgress() {
        float distanceToGoal = playerMovement.FindDistanceToGoal();
        levelPercentageText.text = levelPercentageNum.ToString();
        Debug.Log("Current percentage is " + distanceToGoal);
    }

    public void CompleteLevel() {
        Debug.Log("level completed");
        CompletePanel.SetActive(true);
        levelComplete = true;
    }

    public void EndGame() {
        if (levelStarted == true) {
            levelStarted = false;
            Debug.Log("game end");
            ShowDeathPanel();
        }
    }

    public void ShowDeathPanel() {
        DeathPanel.SetActive(true);
    }

    public void BackToMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        levelStarted = true;
    }
}
